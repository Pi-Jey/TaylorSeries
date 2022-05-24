


using System.Numerics;

namespace TaylorSeries
{
    internal class ParallelTaylor
    {
        public ParallelTaylor()
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
        public double Factorial(double x)
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
        public static int[][] Spread(int n, int parts)
        {
            int [][] arrays = new int[parts][];

            int elementsPerPart = n / parts;
            int counter = 0;

            for (int i = 0; i < parts; i++)
            {
                arrays[i] = new int[elementsPerPart];
                if (n % parts != 0)
                {
                    arrays[parts-1] = new int[elementsPerPart + n % parts];
                }
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    if (i == 0) 
                    {
                        arrays[i][j] = (j);
                    }
                    else
                    {
                        arrays[i][j] = arrays[i-1][elementsPerPart-1] + (j+1);
                    }
                }
                counter++;
            }

            return arrays;
        }
        //public double Func ( double x, int n)
        //{
        //    double pow;
        //    double fact;

        //    pow = Power(x, n);
        //    fact = Factorial(n);
        //    double result = pow / fact;

        //    return result;
        //}
        //public double Func (double x, int n)
        //{
        //    double pow;
        //    double fact;

        //    pow = Power(x, 2 * n + 1);
        //    fact = Factorial(2 * n + 1);
        //    double result = Power(-1, n) * pow / fact;

        //    return result;
        //} 
        public double Func (double x, int n)
        {
            double pow;
            if (x > 1 || x < -1)
            {
                throw new ArgumentException("Заданий x знаходиться поза областi визначення функцiї");
            }
            pow = Power(x, n + 1);
            double result = Power(-1, n) * pow / (n + 1);
            return result;
        }
        public double TaylorPar(double x, int n, int parts)
        {
            int[][] arrays = Spread(n, parts);

            double current = 0;

            Parallel.For(0, parts, i =>
            {
                for(int j = 0; j < arrays[i].Length; j++)
                {
                    current += Func(x, arrays[i][j]);
                }
            });
            return current;
        }
    }
}
