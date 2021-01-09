using System;

namespace Enums
{
    class Program
    {
        public enum FruitA
        {
            Apple = 1
        }

        public enum FruitB
        {
            Apple = 1
        }

        static void Main(string[] args)
        {
            Order o1 = new Order();
            o1.AdvanceStatus();
            Console.WriteLine(o1.Status);
            //casts to int are needed to see the number underneath
            Console.WriteLine((int) o1.Status);

            //when comparing two enums, casts are still needed
            FruitA a = FruitA.Apple;
            FruitB b = FruitB.Apple;

            // Console.WriteLine(a==b); //won't work
            Console.WriteLine((int) a == (int) b);
            
            //outputting the enum label
            Console.WriteLine(Enum.GetName(typeof(OrderStatus), 3));
        }
    }
}