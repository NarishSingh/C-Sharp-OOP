using System;
using System.Threading;

namespace ThreadingProj
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //separate thread
            Thread t = new Thread(WriteY)
            {
                Name = "---The New Thread---"
            }; //basic ctor takes a delegate, basically a ref to a method
            t.Start();

            //on main thread
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Y");
            }

            Console.WriteLine("\n");
            
            //put thread to sleep -> NOTE: if this isn't included, a block of "x"'s would've print in t2's thread
            Thread.Sleep(1000); 

            //Joining threads -> wait for another to end
            Thread t2 = new Thread(Go);
            t2.Start();
            t2.Join(); //wait for it to end
            Console.WriteLine("Thread t2 has ended!");
        }

        private static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
                if (i == 500) Console.WriteLine(Thread.CurrentThread.Name); //get thread name
            }
        }

        private static void Go()
        {
            for (int i = 0; i < 100; i++) Console.Write("/");
        }
    }
}