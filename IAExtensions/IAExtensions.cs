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
        /// <summary>
        /// Find neasrest bigger number that consist of the same digits 
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="stopwatch">watch to control an executing time</param>
        /// <returns>neasrest bigger number that consist of the same digits and time, needed for executing</returns>
        public static int NextBiggerNumber(int number, out Stopwatch stopwatch)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            number = ArrayExtensions.SpecialMethods.NextBiggerNumber(number);

            stopwatch.Stop();
            return number;
        }

        /// <summary>
        /// Find neasrest bigger number that consist of the same digits 
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>Tuple that consist of the neasrest bigger number that consist of the same digits and time, needed for executing</returns>
        public static (int, Stopwatch) NextBiggerNumber(int number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            number = ArrayExtensions.SpecialMethods.NextBiggerNumber(number);

            stopwatch.Stop();
            return (number, stopwatch);
        }
        /// <summary>
        /// Count the n-degree root of a number with a given accuracy
        /// </summary>
        /// <param name="number">Users number</param>
        /// <param name="rootPower">n-root</param>
        /// <param name="eps">accurancy</param>
        /// <exception cref="ArgumentException">Root must be greater then 0</exception>
        /// <returns> n-degree root of a number with a given accuracy</returns>
        public static double NRootFromNumber(double number, int rootPower, int eps)
        {
            if(rootPower<=0) throw new ArgumentException($"Value of {nameof(rootPower)} must be greater then 0");
            if(eps<0) throw new ArgumentException($"Value of {nameof(eps)} must be greater then 0");
            if (number < 0) return double.NaN;
            if (number == double.PositiveInfinity || number == double.Epsilon) return double.PositiveInfinity;
            
            
            double x1 = number/rootPower;
            double x2 = 1.0 / rootPower * (((rootPower - 1) * x1) + (number / Math.Pow(x1, rootPower - 1)));

            while (Math.Abs(x2 - x1) > (double)1 / Math.Pow(10.0, eps))
            {
                x1 = x2;
                x2 = 1.0 / rootPower * (((rootPower - 1) * x1) + (number / Math.Pow(x1, rootPower - 1)));
            }

            double scale = Math.Pow(10.0, eps);
            double round = Math.Floor(Math.Abs(x1) * scale + 0.5);
            return (Math.Sign(x1) * round / scale);
        }

    }
}
