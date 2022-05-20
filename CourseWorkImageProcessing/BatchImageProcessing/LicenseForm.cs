using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchImageProcessing
{
    public partial class LicenseForm : Form
    {
        private License _license;

        public LicenseForm()
        {
            InitializeComponent();
        }

        public LicenseForm(License license)
        {
            InitializeComponent();
            _license = license;
            _license.Updated += UpdateLicense;
            ShowLicenseInformation();
        }

        private void ShowLicenseInformation()
        {
            SetLicenseStatus(_license.Status);
            
            if (_license.Status == LicenseStatus.Trial)
            {
                LicenseFoundText.Text = "Лицензия не найдена:";
                usernameTextBox.Text = "";
                usbTextBox.Text = "";
                timeStartTextBox.Text = "";
                timeEndTextBox.Text = "";
            }
            else
            {
                LicenseFoundText.Text = "Лицензия найдена:";
                usernameTextBox.Text = _license.UserName;
                usbTextBox.Text = _license.USB;
                timeStartTextBox.Text = _license.StartDate.ToString();
                timeEndTextBox.Text = _license.EndDate.ToString();
            }
        }

        private void SetLicenseStatus(LicenseStatus status)
        {
            switch (status)
            {
                case LicenseStatus.Active:
                    {
                        LicenseStatusText.Text = "Лицензия активна";
                        LicenseStatusText.BackColor = Color.LightGreen;
                        break;
                    }
                case LicenseStatus.OutOfDate:
                    {
                        LicenseStatusText.Text = "Лицензия истекла";
                        LicenseStatusText.BackColor = Color.LightYellow;
                        break;
                    }
                default:
                    {
                        LicenseStatusText.Text = "Пробная версия";
                        LicenseStatusText.BackColor = Color.PaleVioletRed;
                        break;
                    }
            }
        }

        private void UpdateLicense()
        {
            LicenseStatusText?.Invoke((Action)delegate () {
                ShowLicenseInformation();
            });
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LicenseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _license.Updated -= UpdateLicense;
        }
    }
}
