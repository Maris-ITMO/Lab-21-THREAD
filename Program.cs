using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Lab_21_СамРабота_Многопоточность_класс_THREAD
{
    class Program
    {
        static int[,] garden = new int[10, 10];
        static object lockObject = new object();

        static void Main(string[] args)
        {
            Thread gardener1 = new Thread(() => GardenWorker1());
            Thread gardener2 = new Thread(() => GardenWorker2());

            gardener1.Start();
            gardener2.Start();

            gardener1.Join();
            gardener2.Join();

            Console.WriteLine("Садовые работы завершены.");
            Console.ReadKey();
        }

        static void GardenWorker1()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    lock (lockObject)
                    {
                        if (garden[i, j] == 0)
                        {
                            garden[i, j] = 1;
                            Console.WriteLine("Садовник 1, работающий в: " + i + "," + j);
                        }
                    }
                }
            }
        }

        static void GardenWorker2()
        {
            for (int i = 9; i >= 0; i--)
            {
                for (int j = 9; j >= 0; j--)
                {
                    lock (lockObject)
                    {
                        if (garden[i, j] == 0)
                        {
                            garden[i, j] = 2;
                            Console.WriteLine("Садовник 2, работающий в: " + i + "," + j);
                        }
                    }
                }
            }
        }
    }
}