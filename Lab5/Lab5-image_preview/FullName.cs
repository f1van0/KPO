using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_image_preview
{
    [Serializable]
    public class FullName : Object
    {
        public string first;
        public string second;
        public string third;

        public FullName(string first, string second, string third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }

        // Creates a property to retrieve or set the value.
        public string MyObjectValue
        {
            get
            {
                return first + ' ' + second + ' ' + third;
            }
            set
            {
                first = value;
            }
        }
    }
}
