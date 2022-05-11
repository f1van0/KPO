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
            
            lock (devices)
            {
                foreach (var device in devices)
                {
                    Key foundKey = KeyFactory.ReadKey(device.DriveName);
                    if (foundKey != null)
                    {
                        if (username == foundKey.Username && device.Name == foundKey.USB && device.SerialNumber == foundKey.SerialNumber)
                        {
                            return foundKey;
                        }
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
