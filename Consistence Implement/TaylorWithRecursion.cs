using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries
{
    internal class TaylorWithRecursion
    {
        public TaylorWithRecursion()
        {

        }
        public double Factorial(uint num)
        {
            if (num <= 1)
            {
                return 1d;
            }

            return num * Factorial(num - 1);
        }

        public double Power(double num, uint pow)
        {
            if (pow == 0)
            {
                return 1d;
            }

            return num * Power(num, pow - 1);
        }

        public double Exp(double x, uint n)
        {
            var current = Power(x, n) / Factorial(n);
            if (n == 0)
            {
                return current;
            }
            
            return current + Exp(x, n-1);
        }

    }
}
