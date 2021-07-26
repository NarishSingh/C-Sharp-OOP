using System;
using System.Threading;

namespace ThreadingProj
{
    internal class Program
    {
        private bool _done;
        
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
            Thread.Sleep(500); //.5s

            //Joining threads -> wait for another to end
            Thread t2 = new Thread(WriteSlash);
            t2.Start();
            t2.Join(); //wait for it to end
            Console.WriteLine("Thread t2 has ended!");
            
            Console.WriteLine("\n");
            Thread.Sleep(500);
            
            //Local State - each thread has its own mem stack
            //this will perform the delegate twice
            new Thread(WriteQm).Start(); //new thread
            WriteQm(); //on main
            
            Console.WriteLine("\n");
            Thread.Sleep(500);
            
            //Shared state - this will only write done once, they shared the _done var
            Program shared = new Program();
            new Thread(shared.FlipTheSwitch).Start();
            shared.FlipTheSwitch();
            
            //shared state with lambda
            bool isDone = false;
            ThreadStart action = () =>
            {
                if (!isDone)
                {
                    isDone = true;
                    Console.WriteLine("Is Done!");
                }
            };
            new Thread(action).Start();
            action();
        }

        private static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
                if (i == 500) Console.WriteLine(Thread.CurrentThread.Name); //get thread name
            }
        }

        private static void WriteSlash()
        {
            for (int i = 0; i < 100; i++) Console.Write("/");
        }

        private static void WriteQm()
        {
            for (int i = 0; i < 5; i++) Console.Write("?");
            Console.Write("-");
        }

        private void FlipTheSwitch()
        {
            if (_done) return;
            _done = true;
            Console.WriteLine("Done!");
        }
    }
}