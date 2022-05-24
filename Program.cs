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

            Console.WriteLine("На скiльки тасків роздiлити виконання задачі?");
            Console.Write("parts = ");
            int parts = int.Parse(Console.ReadLine());

            var sw = new Stopwatch();
            sw.Start();
            var result = pt.TaylorPar(x, n, parts);
            //double result = t.Exp(x, n);
            //var result = tr.Exp(x, n);
            sw.Stop();

            //Console.WriteLine("Result      = {0}", result);
            //Console.WriteLine("Math.Exp(x) = {0}", Math.Exp(x));
            //Console.WriteLine("Math.Sin(x) = {0}", Math.Sin(x));
            //Console.WriteLine("Math.Log(x+1) = {0}", Math.Log(x + 1));
            Console.WriteLine("Час виконання алгоритму: " + sw.ElapsedMilliseconds + " мс.");
            Console.ReadKey(true);
        }

    }
}