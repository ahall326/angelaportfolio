using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHPortfolio.Models
{
    public class Date
    {
        public void GetElapsedTime(DateTime from_date, DateTime to_date, out int years, out int months, out int days, out int hours, out int minutes, out int seconds, out int milliseconds)
        {
            {
                // If from_date > to_date, switch them around.
                if (from_date > to_date)
                {
                    GetElapsedTime(to_date, from_date,
                        out years, out months, out days, out hours,
                        out minutes, out seconds, out milliseconds);
                    years = -years;
                    months = -months;
                    days = -days;
                    hours = -hours;
                    minutes = -minutes;
                    seconds = -seconds;
                    milliseconds = -milliseconds;
                }
                else
                {
                    // Handle the years.
                    years = to_date.Year - from_date.Year;

                    // See if we went too far.
                    DateTime test_date = from_date.AddMonths(12 * years);
                    if (test_date > to_date)
                    {
                        years--;
                        test_date = from_date.AddMonths(12 * years);
                    }

                    // Add months until we go too far.
                    months = 0;
                    while (test_date <= to_date)
                    {
                        months++;
                        test_date = from_date.AddMonths(12 * years + months);
                    }
                    months--;

                    // Subtract to see how many more days,
                    // hours, minutes, etc. we need.
                    from_date = from_date.AddMonths(12 * years + months);
                    TimeSpan remainder = to_date - from_date;
                    days = remainder.Days;
                    hours = remainder.Hours;
                    minutes = remainder.Minutes;
                    seconds = remainder.Seconds;
                    milliseconds = remainder.Milliseconds;
                }
            }
        }

    }
}