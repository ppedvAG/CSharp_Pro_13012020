using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle);
            //Console.WriteLine(Environment.ProcessorCount);
            //Parallel.For(0, 100000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));
            
            Task t1 = new Task(() =>
            {
                Console.WriteLine("T1 gestartet");
                Thread.Sleep(300);
                throw new IndexOutOfRangeException();
                Console.WriteLine("T1 fertig");
            });

            t1.ContinueWith(t =>
             {
                 Console.WriteLine("T1 continue (immer)");
             });

            t1.ContinueWith(t =>
            {
                Console.WriteLine($"T1 ERROR:{t.Exception.InnerException.Message}");
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);

            t1.ContinueWith(t =>
            {
                Console.WriteLine($"T1 OK");
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);

            Task<long> t2 = new Task<long>(() =>
            {
                Console.WriteLine("T2 gestartet");
                Thread.Sleep(1300);
                Console.WriteLine("T2 fertig");
                return 23456789;
            });

            t1.Start();
            t2.Start();

            Console.WriteLine($"Result T2: {t2.Result}"); //-> t2.Wait();


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
