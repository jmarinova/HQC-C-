using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods.Numbers
{
    class Numbers
    {
        public static void RoundDoubleToSecondDigit(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintToPercentageNumber(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintNumberToRight(object number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}
