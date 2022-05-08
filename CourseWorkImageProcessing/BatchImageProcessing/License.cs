using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageProcessing
{
    public enum LicenseStatus
    {
        Active = 0,
        OutOfDate,
        Trial
    }

    public class License : IDisposable
    {
        public delegate void UpdateHandler();
        public event UpdateHandler Updated;

        private KeyObserver _keyObserver;

        //Активна ли полная лицензия
        public LicenseStatus Status { get; private set; }
        
        public bool WasFound { get; private set; }

        //Имя пользователя
        public string UserName { get; private set; }
        //Название USB накопителя с ключом
        public string USB { get; private set; }
        //Серийный номер USB накопителя
        public string SerialNumber { get; private set; }
        //Начало действия лицензии
        public DateTime StartDate { get; private set; }
        //Конец действия лицензии
        public DateTime EndDate { get; private set; }

        public License()
        {
            _keyObserver = new KeyObserver();
            _keyObserver.FoundKey += UpdateLicense;
        }

        public void UpdateLicense(Key key)
        {
            if (key == null)
            {
                Status = LicenseStatus.Trial;
                WasFound = false;
                UserName = Environment.UserName;
                USB = "-";
                SerialNumber = "-";
                StartDate = DateTime.Now;
                EndDate = DateTime.Now;
            }
            else
            {
                if (DateTime.Now > key.StartTime && DateTime.Now < key.EndTime)
                {
                    Status = LicenseStatus.Active;
                }
                else
                {
                    Status = LicenseStatus.OutOfDate;
                }

                WasFound = true;
                UserName = key.Username;
                USB = key.USB;
                SerialNumber = key.SerialNumber;
                StartDate = key.StartTime;
                EndDate = key.EndTime;
            }

            Updated?.Invoke();
        }

        public void Dispose()
        {
            _keyObserver.FoundKey -= UpdateLicense;
        }
    }
}
