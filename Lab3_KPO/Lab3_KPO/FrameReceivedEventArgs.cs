using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_KPO
{
    public class FrameReceivedEventArgs : EventArgs
    {
        public byte[] Frame { get; set; }
    }
}
