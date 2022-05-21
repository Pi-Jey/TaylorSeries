using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries
{
    internal class ConsistenceImplement
    {
        public ConsistenceImplement()
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

        public double Power(double num, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }

            return num * Power(num, pow - 1);
        }

        public double Exp(double x, int n = 0, double precision = 1e-10)
        {
            var current = Power(x, n) / Factorial((uint)n);
            if (current < precision)
            {
                return current;
            }

            return current + Exp(x, n + 1, precision);
        }

    }
}
