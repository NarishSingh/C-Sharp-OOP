using System;
using ConsoleUtilities.BLL;

namespace ConsoleUtilities.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = UserInput.ReadInt("Enter your age: ");

            Console.WriteLine($"Age: {age}", age);
        }
    }
}