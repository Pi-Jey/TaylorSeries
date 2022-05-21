using System;

class Program
{
    static double Factorial(uint num)
    {
        if (num <= 1)
        {
            return 1d;
        }

        return num * Factorial(num - 1);
    }

    static double Power(double num, int pow)
    {
        if (pow == 0)
        {
            return 1;
        }

        return num * Power(num, pow - 1);
    }

    static double Exp(double x, int n = 0, double precision = 1e-10)
    {
        var current = Power(x, n) / Factorial((uint)n);
        if (current < precision)
        {
            return current;
        }

        return current + Exp(x, n + 1, precision);
    }

    public static void Main()
    {
        Console.Write("x = ");
        var x = double.Parse(Console.ReadLine());
        var result = Exp(x);
        Console.WriteLine("Exp(x)      = {0}", result);
        Console.WriteLine("Math.Exp(x) = {0}", Math.Exp(x));
        Console.ReadKey(true);
    }
}