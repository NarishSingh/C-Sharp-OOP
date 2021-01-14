using System;

namespace DateTimeStructMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime rn = DateTime.Now;
            Console.WriteLine(rn);
            DateTime today = DateTime.Today;
            Console.WriteLine(today);

            DateTime oldYearsDay = DateTime.Parse("12/31/2020 12:00:00 AM");
            DayOfWeek day = oldYearsDay.DayOfWeek;
            Console.WriteLine(oldYearsDay);
            Console.WriteLine(oldYearsDay.DayOfYear); //2020 was a leap yr
            Console.WriteLine(oldYearsDay.TimeOfDay);
            Console.WriteLine(day);
            switch (day)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Weekday");
                    break;
            }

            //use timespan to +/- time periods
            DateTime in1hr = rn + new TimeSpan(0, 1, 0, 0);
            DateTime in2Day = rn + new TimeSpan(2, 0, 0, 0);

            TimeSpan howLongWasToday = rn - today; //math w 2 DateTime obj's produce a TimeSpan
            Console.WriteLine(howLongWasToday);

            //.Add*() method
            DateTime yrAfter = rn.AddYears(1);
            DateTime in2mo = rn.AddMonths(2);
            DateTime inDayAndHalf = rn.AddDays(1.5);
            DateTime sixHrsAgo = rn.AddHours(-6);
            DateTime inMins = rn.AddMinutes(150);
            DateTime inS = rn.AddSeconds(300);
            DateTime inMs = rn.AddMilliseconds(300);
            DateTime inTicks = rn.AddTicks(300);

            Console.WriteLine(yrAfter);
            Console.WriteLine(in2mo);
            Console.WriteLine(inDayAndHalf);
            Console.WriteLine(sixHrsAgo);
            Console.WriteLine(inMins);
            Console.WriteLine(inS);
            Console.WriteLine(inMs);
            Console.WriteLine(inTicks);
        }
    }
}