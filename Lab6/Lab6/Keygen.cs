using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
	public partial class Keygen : Form
	{
		Key loadedKey;
		List<USBFlash> devices;
		BindingSource source;

		public Keygen()
		{
			InitializeComponent();
			
			usernameBox.Text = Environment.UserName;

			// запуск обсервера
			USBObserver.Instance.runAutoUpdate();
			USBObserver.Instance.UpdateDevices += updateDevices;

			source = new BindingSource();
			devicesComboBox.DataSource = source;
			USBObserver.Instance.UpdateDevices += updateDevices;
			updateDevices(USBObserver.Instance.Devices);
		}

		private bool[] GetAvailabilityOfFunctions()
        {
			bool[] isFuncChecked = new bool[funcsLayoutPanel.Controls.Count];
			for (int i = 0; i < funcsLayoutPanel.Controls.Count; i++)
            {
				isFuncChecked[i] = ((CheckBox)funcsLayoutPanel.Controls[i]).Checked;
            }

			return isFuncChecked;
        }

		private void updateDevices(List<USBFlash> newDevices)
		{
			if (devicesComboBox.InvokeRequired)
				devicesComboBox.Invoke(new Action<List<USBFlash>>(updateDevices), newDevices);
			else
			{
				devices = newDevices;
				source.DataSource = devices;
				source.ResetBindings(true);
			}
		}



		private void createKey_Click(object sender, EventArgs e)
		{
			if (endDateTimePicker.Value > DateTime.Now
				&& usernameBox.Text.Length > 0
				&& devicesComboBox.SelectedValue != null)
			{
				var device = (USBFlash)devicesComboBox.SelectedValue;

				Key generatedKey = new Key(GetAvailabilityOfFunctions(), device.SerialNumber, usernameBox.Text, endDateTimePicker.Value);

				serialBox.Text = device.SerialNumber;
				createdBox.Text = generatedKey.CreatedDate.ToString();

				// сохраняю ключ
				KeyFactory.CreateKey(device.DriveName, generatedKey);
			}
		}

        private void Keygen_FormClosing(object sender, FormClosingEventArgs e)
        {
			USBObserver.Instance.UpdateDevices -= updateDevices;
			USBObserver.Instance.stopAutoUpdate();
		}

        private void Keygen_Load(object sender, EventArgs e)
        {

        }
    }
}
