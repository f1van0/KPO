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

    public class License
    {
        public delegate void UpdateHandler();
        public event UpdateHandler Updated;

        //Активна ли полная лицензия
        public LicenseStatus Status { get; }
        
        public bool WasFound { get; }

        //Имя пользователя
        public string UserName { get; }
        //Название USB накопителя с ключом
        public string USB { get; }
        //Серийный номер USB накопителя
        public string SerialNumber { get; }
        //Начало действия лицензии
        public DateTime StartDate { get; }
        //Конец действия лицензии
        public DateTime EndDate { get; }

        public License()
        {
            Status = LicenseStatus.Trial;
            WasFound = false;
            UserName = Environment.UserName;
            USB = "-";
            SerialNumber = "-";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        public void Update()
        {
            Updated?.Invoke();
        }

        //public bool TryToActivate()
        //{
        //
        //}
    }
}
