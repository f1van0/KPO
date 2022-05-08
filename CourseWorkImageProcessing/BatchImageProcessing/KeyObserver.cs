using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private Key FindKeyOnFlashDrives()
        {
            string username = Environment.UserName;
            byte[] usernameMD5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(username));
            byte[] serialMD5;
            byte[] usbMD5;
            
            foreach (var device in devices)
            {
                serialMD5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(device.SerialNumber));
                usbMD5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(device.Name));
                EncryptedKey? foundKey = KeyFactory.ReadKey(device.DriveName);
                if (foundKey.HasValue)
                {
                    if (VerifyData(usernameMD5, foundKey.Value.Username) && VerifyData(serialMD5, foundKey.Value.SerialNumber) && VerifyData(usbMD5, foundKey.Value.USB))
                    {
                        Key verifiedKey = new Key(username, device.Name, device.SerialNumber, foundKey.Value);
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

        private void FindKey()
        {
            //Найден ключ, который к тому же является подлинным
            Key foundKey = FindKeyOnFlashDrives();
            FoundKey?.Invoke(foundKey);
        }

        public void Dispose()
        {
            USBObserver.Instance.UpdateDevices -= updateDevices;
            USBObserver.Instance.stopAutoUpdate();
        }
    }
}
