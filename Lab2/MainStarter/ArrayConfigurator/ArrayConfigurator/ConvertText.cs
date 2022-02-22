using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConfigurator
{
    static class ConvertText
    {
        public static int[] ConvertTextToIntArray(string text)
        {
            string[] strArray = text.Split(' ');
            List<int> listArray = new List<int>();
            int currentValue;
            foreach (var str in strArray)
            {
                if (int.TryParse(str, out currentValue))
                    listArray.Add(currentValue);
            }

            return listArray.ToArray();
        }

        public static string ConvertIntArrayToText(int[] arr)
        {
            string text = "";
            for (int i = 0; i < arr.Length; i++)
                text += arr[i].ToString() + ' ';
            return text;
        }
    }
}
