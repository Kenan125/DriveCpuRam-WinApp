using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class FormattedBytes
    {
        public static decimal Format(decimal bytes)
        {
            int counter = 0;
            decimal number = bytes;
            while (number / 1024 >= 1)
            {
                number /= 1024;
                counter++;
            }
            return number;
        }
    }
}
