using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries
{
    internal class Taylor
    {
        public Taylor()
        {

        }
        public double Power(double x, long n)
        {
            double pow = 1;
            if (n == 0)
            {
                return 1;
            }
            for (int i = 1; i <= n; i++)
            {
                pow *= x;
            }

            return pow;
        }
        public double Fact(double x)
        {
            double fact = 1;

            if (x == 0)
            {
                return 1;
            }
            for (int i = 1; i <= x; i++)
            {
                fact *= i;
            }

            return fact;
        }
        public double Exp(double x, int n)
        {
            double current = 0;
            double power;
            double fact;

            for (int i = 0; i <= n; i++)
            {
                power = Power(x,i);
                fact = Fact(i);
                current += power / fact;
            }
            return current;
        }
    }
}
