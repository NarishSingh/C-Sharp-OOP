using System;

namespace DateTimeLab
{
    public class DtLabCodes
    {
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            return DateTime.Today;
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            return string.Format($"{month}/{day}/{year.ToString().Substring(2)}");
        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            return DateTime.Parse(date); //apparently .Parse can do all of that...
        }

        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            return DateTime.Parse(date)
                .ToString("MM.dd.yyyy hh:mm tt");
        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            return DateTime.Parse(date)
                .AddMonths(6)
                .ToString("MMMM d, yyyy");
        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>
        public string GetDateThirtyDaysInPast(string date)
        {
            return DateTime.Parse(date)
                .AddDays(-30)
                .ToString("MMMM d, yyyy");
        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>
        public DateTime[] GetNextWednesdays(int count, string startDate)
        {
            DateTime[] weds = new DateTime[count];
            DateTime d = DateTime.Parse(startDate);

            //first addition may be >7, need to find exact
            DayOfWeek day = d.DayOfWeek;
            int[] nextWed = {3, 2, 1, 0, 6, 5, 4}; //starting from sunday, you add arr[(int) DayOfWeek] to get to the next wed

            //build array
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    d = d.AddDays(nextWed[(int) day]); //enums are convertable to int's -> access arr for day's increment
                    weds[i] = d;
                }
                else
                {
                    //remaining iterations will be +7 after first wed is found
                    d = d.AddDays(7);
                    weds[i] = d;
                }
            }

            return weds;
        }
    }
}