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
            double x = double.Parse(Console.ReadLine());

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("На скiльки потокiв роздiлити основний потiк?");
            Console.Write("parts = ");
            int parts = int.Parse(Console.ReadLine());

            var sw = new Stopwatch();
            sw.Start();
            var result = pt.Exp(x, n, parts);
            //var result = t.Exp(x, n);
            //var result = tr.Exp(x, n);
            sw.Stop();

            //Console.WriteLine("Exp(x)      = {0}", Math.Round(result, 6));
            //Console.WriteLine("Math.Exp(x) = {0}", Math.Exp(x));
            Console.WriteLine("Час виконання алгоритму: " + sw.ElapsedMilliseconds + " мс.");
            Console.ReadKey(true);
        }

    }
}