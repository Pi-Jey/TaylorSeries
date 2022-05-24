using System;
using System.Diagnostics;
using TaylorSeries;

class Program
{
    static ParallelTaylor pt = new ParallelTaylor();
    static TaylorWithRecursion tr = new TaylorWithRecursion();
    static Taylor t = new Taylor();

    public static void Main()
    {

        while (true)
        {
            Console.Write("x = ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("n = ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("На скiльки таскiв роздiлити основний потiк?");
            Console.Write("parts = ");
            int parts = int.Parse(Console.ReadLine());

            var sw = new Stopwatch();
            sw.Start();
            var result = pt.TaylorPar(x, n, parts);
            //double result = t.Exp(x, n);
            //var result = tr.Exp(x, n);
            sw.Stop();

            Console.WriteLine("Exp(x)      = {0}", result);
            Console.WriteLine("Math.Exp(x) = {0}", Math.Exp(x));
            Console.WriteLine("Час виконання алгоритму: " + sw.ElapsedMilliseconds + " мс.");
            Console.ReadKey(true);
        }

    }
}