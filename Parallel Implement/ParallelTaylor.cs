
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
                    //Console.WriteLine(arrays[i][j] );
                }

                counter++;
                //Console.WriteLine(arrays[i]);
            }

            return arrays;
        }
        public double Func ( double x, int n)
        {
            double power;
            double fact;

            power = Power(x, n);
            fact = Fact(n);
            double result = power / fact;

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
