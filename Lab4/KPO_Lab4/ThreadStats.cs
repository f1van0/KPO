using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_Lab4
{
    class ThreadStats
    {
        public int TasksCompleted;
        public int ProceedTime;

        public ThreadStats(int proceedTime)
        {
            TasksCompleted = 1;
            ProceedTime = proceedTime;
        }
    }
}
