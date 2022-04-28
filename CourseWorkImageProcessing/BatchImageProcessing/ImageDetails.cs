using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageProcessing
{
    public class ImageDetails
    {
        public string ActionName { get; }
        public Bitmap Image { get; set; }

        public ImageDetails(string actionName, Bitmap image)
        {
            ActionName = actionName;
            Image = image;
        }
    }
}
