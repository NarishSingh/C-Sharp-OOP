using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingProj
{
    internal class Program
    {
        private bool _done;
        private static readonly object Locker = new object(); //a reference type, used to contend a lock

        public static void Main(string[] args)
        {
            /*THREADING PROPER*/
            /*
            //separate thread
            Thread t = new Thread(WriteY)
            {
                Name = "---The Y Thread---"
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

            //Shared state (not recommended)- this execute the delegate only once as they shared the _done var
            Program shared = new Program();
            new Thread(shared.FlipTheDoneSwitch).Start();
            shared.FlipTheDoneSwitch();

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

            Console.WriteLine("\n");
            Thread.Sleep(500);

            //Locking threads - one thread locks until the lock becomes available -> thread safety
            shared._done = false;
            new Thread(shared.FlipDoneLocked).Start(); //will only print once thanks to lock
            shared.FlipDoneLocked();

            Console.WriteLine("\n");
            Thread.Sleep(500);

            //Passing data to thread
            //lambda -> pass in ctor
            Thread t3 = new Thread(() => Console.WriteLine("Hello from t3"));
            t3.Start();

            new Thread(() =>
            {
                Console.WriteLine("Hello from multiline lambda");
                Console.WriteLine("We are multiple");
            }).Start();

            //pass in to .Start()
            Thread t4 = new Thread(PrintLine);
            t4.Start("Hello from the .Start()");

            Console.WriteLine("\n");
            Thread.Sleep(500);

            //try catching in threads -> must do so in the delegate
            new Thread(ThrowThis).Start();
            
            Console.WriteLine("\n");
            Thread.Sleep(500);

            //Signalling -> have a thread wait for a notif from other thread before doing anything
            ManualResetEvent signal = new ManualResetEvent(false);

            new Thread(() =>
            {
                Console.WriteLine("Waiting on signal. . .");
                signal.WaitOne(); //wait for a signal
                signal.Dispose(); //release the wait handler
                Console.WriteLine("*Received*");
            }).Start();

            Thread.Sleep(2000);
            signal.Set(); //reopen and allow other threads to proceed
            */

            /*TASKS*/
            //a higher level abstraction of a concurrent operation that may or may not be backed with a thread
            Task.Run(() => Console.WriteLine("This is a task!\n"));

            Thread.Sleep(500);

            //wait
            Task task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("We slept, now the task is done\n");
            });
            Console.WriteLine($"Completed?: {task.IsCompleted}");
            task.Wait();

            Thread.Sleep(500);

            //Task with result
            Task<int> intTask = Task.Run(() =>
            {
                Console.WriteLine("We return a value");
                return 3;
            });
            int result = intTask.Result;
            Console.WriteLine(result);

            Task<int> primes = Task.Run(() => Enumerable.Range(2, 3000000)
                    .Count(n => Enumerable.Range(2, (int) Math.Sqrt(n) - 1).All(i => n % i > 0)));

            Console.WriteLine("\nTask is running. . .");
            Console.WriteLine($"Number of primes between 2 to 3,000,000 is {primes.Result}");
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

        private void FlipTheDoneSwitch()
        {
            if (_done) return;
            _done = true;
            Console.WriteLine("Done!");
        }

        private void FlipDoneLocked()
        {
            if (_done) return;
            lock (Locker)
            {
                if (!_done) Console.WriteLine("Done!");
                _done = true;
            }
        }

        private static void PrintLine(object msgObj)
        {
            Console.WriteLine((string) msgObj);
        }

        private static void ThrowThis()
        {
            try
            {
                throw null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}