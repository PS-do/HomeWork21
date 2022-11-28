using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork21
{
    internal class Program
    {
        const int n = 5;//строки
        const int m = 5;//столбцы

        static int[,] path = new int[n, m];
        static Random random = new Random();
        const int maxRandom = 50;
        static void SetPath()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    path[i, j] = random.Next(maxRandom);
                }
            }
        }
        static void PrintPath(int[,] p)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{path[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            SetPath();
            Console.WriteLine("Исходная матрица:");
            PrintPath(path);

            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Gardner2();


            Console.WriteLine("\nИтоговая матрица:");
            PrintPath(path);

            Console.ReadLine();
        }

        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Gardner2()
        {
            for (int i = n-1; i >=0; i--)
            {
                for (int j = m-1; j >=0; j--)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }



    }
}
