﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                for (int j = 0; j < elementsPerPart; j++)
                {
                    arrays[i][j] = i*10 + (j+1);
                    //Console.WriteLine(arrays[i][j]);
                }
                counter++;
                //Console.WriteLine(arrays[i]);
            }
            //Console.WriteLine(counter);
            return arrays;
        }
        public double Exp(double x, int n, int parts)
        {
            int[][] arrays = Spread(n, parts);

            double current = 0;
            double power;
            double fact;

            Parallel.For(0, parts, i =>
            {
                for(int j = 0; j < n/parts; j++)
                {
                    power = Power(x, j*10 + i);
                    fact = Fact(j*10 + i);
                    current += power / fact;
                }
            });
            return current;
        }
    }
}