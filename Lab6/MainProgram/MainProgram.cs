using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram
{
    public partial class MainProgram : Form
    {
        List<USBFlash> devices;
        BindingSource source;

        private const string keyFileName = "key.key";

        public MainProgram()
        {
            InitializeComponent();
            usernameBox.Text = Environment.UserName;
            ResetAvailabilityOfFunctions();
            devices = new List<USBFlash>();

            // запуск обсервера
            USBObserver.Instance.runAutoUpdate();
            USBObserver.Instance.UpdateDevices += updateDevices;
            // запуск логирования
            USBLogger.Instance.LoadLogs();
            USBLogger.Instance.AddLog($"Application started [{DateTime.Now}]");
            logBox.Text = String.Join("\r\n", USBLogger.Instance.Loggs);
            USBLogger.Instance.AddMessage += newLog;
        }

        public void ResetAvailabilityOfFunctions()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        public void UpdateAvailabilityOfFunctions(bool[] isFuncAvailable)
        {
            button1.Enabled = isFuncAvailable[0];
            button2.Enabled = isFuncAvailable[1];
            button3.Enabled = isFuncAvailable[2];
        }

        private void newLog(string log)
        {
            if (logBox.InvokeRequired)
                logBox.Invoke(new Action<string>(newLog), log);
            else
                logBox.Text += "\r\n" + log;
        }

        void updateDevices(List<USBFlash> newDevices)
        {
            if (devicesTextBox.InvokeRequired)
                devicesTextBox.Invoke(new Action<List<USBFlash>>(updateDevices), newDevices);
            else
            {
                devices = newDevices;
                FindLicense();
                devicesTextBox.Text = String.Join("\r\n", newDevices);
            }
        }

        private Key? FindKeyOnFlashDrives()
        {
            byte[] usernameMD5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(usernameBox.Text));
            byte[] serialMD5;

            foreach (var device in devices)
            {
                serialMD5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(device.SerialNumber));
                EncryptedKey? foundKey = KeyFactory.ReadKey(device.DriveName);
                if (foundKey.HasValue)
                {
                    if (VerifyData(usernameMD5, foundKey.Value.Username) && VerifyData(serialMD5, foundKey.Value.SerialNumber))
                    {
                        Key verifiedKey = new Key(device.Name, device.SerialNumber, foundKey.Value);
                        return verifiedKey;
                    }
                }
            }

            return null;
        }

        public bool VerifyData(byte[] data1, byte[] data2)
        {
            if (data1.Length != data2.Length)
                return false;

            for (int i = 0; i < data1.Length; i++)
            {
                if (data1[i] != data2[i])
                    return false;
            }

            return true;
        }

        void ShowLicenseInfo(Key key)
        {
            usbBox.Text = key.Username;
            serialBox.Text = key.SerialNumber;
            startBox.Text = key.CreatedDate.ToString();
            endBox.Text = key.UntilDate.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            FindLicense();
        }

        private void FindLicense()
        {
            //Найден ключ, который к тому же является подлинным
            Key? foundKey = FindKeyOnFlashDrives();
            if (foundKey.HasValue)
            {
                //Можно произвести вывод информации о полученном ключе
                ShowLicenseInfo(foundKey.Value);

                //Если его лицензия не истекла
                if (foundKey.Value.UntilDate > DateTime.Now)
                {
                    licenseInfoLabel.Text = "Лицензия найдена и еще не истекла";
                    //То можно включить нужные функции
                    UpdateAvailabilityOfFunctions(foundKey.Value.IsFuncsAvailable);
                }
                else
                {
                    licenseInfoLabel.Text = "Лицензия найдена, но уже истекла";
                    ResetAvailabilityOfFunctions();
                }
            }
            else
            {
                licenseInfoLabel.Text = "Лицензия не найдена";
                ResetAvailabilityOfFunctions();
            }
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            USBLogger.Instance.ClearLogs();
            logBox.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            USBObserver.Instance.UpdateDevices -= updateDevices;
            USBObserver.Instance.stopAutoUpdate();

            USBLogger.Instance.AddLog($"Application exited [{DateTime.Now}]");
            USBLogger.Instance.WriteLogs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            button1.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Value = 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abTextBox.Text = aTextBox.Text + bTextBox.Text;
        }
    }
}
