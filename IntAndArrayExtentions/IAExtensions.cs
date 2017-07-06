using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntAndArrayExtentions
{
    public static class IAExtensions
    {
        public static int NextBiggerNumber(int number,out Stopwatch stopwatch)
        {
            stopwatch=new Stopwatch();
            stopwatch.Start();
            number = ArrayExtensions.SpecialMethods.NextBiggerNumber(number);
            stopwatch.Stop();
            return number;
        }

        public static (int, Stopwatch) NextBiggerNumber(int number)
        {
            Stopwatch stopwatch=new Stopwatch();
            stopwatch.Start();
            number = ArrayExtensions.SpecialMethods.NextBiggerNumber(number);
            stopwatch.Stop();
            return (number, stopwatch);
        }

        public static double NRootFromNumber(int number, int n, double eps)
        {
            double x1 = number / n;
            double x2 = (1 / n) * ((n - 1) * x1 + number / Math.Pow(x1, n - 1));

            while (Math.Abs(x2-x1)>eps)
            {
                x1 = x2;
                x2= (1 / n) * ((n - 1) * x1 + number / Math.Pow(x1, n - 1));
            }
            return x1;
        }
        
    }
}
