using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageProcessing
{
    class KeyObserver : IDisposable
    {
        public delegate void KeyHandler(Key key);
        public event KeyHandler FoundKey;

        List<USBFlash> devices;

        public KeyObserver()
        {
            devices = new List<USBFlash>();

            // запуск обсервера
            USBObserver.Instance.runAutoUpdate();
            USBObserver.Instance.UpdateDevices += updateDevices;
        }

        void updateDevices(List<USBFlash> newDevices)
        {
            devices = newDevices;
            FindKey();
        }

        private Key? FindKeyOnFlashDrives()
        {
            //byte[] usernameMD5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(usernameBox.Text));
            //byte[] serialMD5;
            //
            //foreach (var device in devices)
            //{
            //    serialMD5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(device.SerialNumber));
            //    EncryptedKey? foundKey = KeyFactory.ReadKey(device.DriveName);
            //    if (foundKey.HasValue)
            //    {
            //        if (VerifyData(usernameMD5, foundKey.Value.Username) && VerifyData(serialMD5, foundKey.Value.SerialNumber))
            //        {
            //            Key verifiedKey = new Key(device.Name, device.SerialNumber, foundKey.Value);
            //            return verifiedKey;
            //        }
            //    }
            //}

            return null;
        }

        private void FindKey()
        {
            //Найден ключ, который к тому же является подлинным
            Key? foundKey = FindKeyOnFlashDrives();
            if (foundKey.HasValue)
            {
                //FoundKey.Invoke(foundKey);
            }
            else
            {
                //licenseInfoLabel.Text = "Лицензия не найдена";
                //ResetAvailabilityOfFunctions();
            }
        }

        public void Dispose()
        {
            USBObserver.Instance.UpdateDevices -= updateDevices;
            USBObserver.Instance.stopAutoUpdate();
        }
    }
}
