using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle);
            //Console.WriteLine(Environment.ProcessorCount);
            Parallel.For(0, 100000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
        }
    }
}
