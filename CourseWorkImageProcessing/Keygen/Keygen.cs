using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keygen
{
    public partial class Keygen : Form
    {
		Key loadedKey;
		List<USBFlash> devices;
		BindingSource source;

		public Keygen()
		{
			InitializeComponent();

			usernameTextBox.Text = Environment.UserName;

			// запуск обсервера
			USBObserver.Instance.runAutoUpdate();
			USBObserver.Instance.UpdateDevices += updateDevices;

			source = new BindingSource();
			devicesComboBox.DataSource = source;
			USBObserver.Instance.UpdateDevices += updateDevices;
			updateDevices(USBObserver.Instance.Devices);
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



		private void generateKeyButton_Click(object sender, EventArgs e)
		{
			if (endTimeDatePicker.Value > DateTime.Now
				&& usernameTextBox.Text.Length > 0
				&& devicesComboBox.SelectedValue != null)
			{
				var device = (USBFlash)devicesComboBox.SelectedValue;

				Key generatedKey = new Key(usernameTextBox.Text, device.Name, device.SerialNumber, endTimeDatePicker.Value);

				serialTextBox.Text = device.SerialNumber;
				startTimeTextBox.Text = generatedKey.EndTime.ToString();

				// сохраняю ключ
				KeyFactory.CreateKey(device.DriveName, generatedKey);
				MessageBox.Show("Ключ успешно сгенерирован и сохранен на USB накопитель", "Ключ сгенерирован", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
            {
				MessageBox.Show("Некорректно выбрана дата окончания действия лицензии", "Ошибка при выборе даты", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

		private void Keygen_FormClosing(object sender, FormClosingEventArgs e)
		{
			USBObserver.Instance.UpdateDevices -= updateDevices;
			USBObserver.Instance.stopAutoUpdate();
		}
	}
}
