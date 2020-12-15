using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DateHelper
{
    public class FormatDate : DateHelperProperties
    {
        public static string DateFormat(string dateInput, string format)
        {
            string str = string.Empty;
            try
            {
                DateTime parseDate = DateTime.Parse(dateInput);
                str = parseDate.ToString(format);
                ReturnStatusCode = 0;
            }
            catch (Exception e)
            {
                ReturnStatusCode = -1;
                str = $"{ErrorIntro} Message:  {e.Message}{Environment.NewLine}";
            }
            return str;
        }

        
        public static string ConvertTimeToDecimal(string time, string daysHoursMinutesSeconds)
        {
            string str = string.Empty;
            try
            {
                TimeSpan dt = TimeSpan.Parse(time);
                double span = 0;
                
                daysHoursMinutesSeconds = Regex.Replace(daysHoursMinutesSeconds, @"\s", string.Empty);
                if (daysHoursMinutesSeconds.Equals("days", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("days", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("d", StringComparison.InvariantCultureIgnoreCase))
                {
                    span = dt.TotalDays;
                }
                else if (daysHoursMinutesSeconds.Equals("hours", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("hour", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("h", StringComparison.InvariantCultureIgnoreCase))
                {
                    span = dt.TotalHours;
                }
                else if (daysHoursMinutesSeconds.Equals("minutes", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("minute", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("m", StringComparison.InvariantCultureIgnoreCase))
                {
                    span = dt.TotalMinutes;
                }
                else if (daysHoursMinutesSeconds.Equals("seconds", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("second", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                {
                    span = dt.TotalSeconds;
                }

                str = span.ToString();
                ReturnStatusCode = 0;
            }
            catch (Exception e)
            {
                ReturnStatusCode = -1;
                str = $"{ErrorIntro} Message:  {e.Message}{Environment.NewLine}";
            }
            return str;
        }


        public static string ConvertDecimalToTime(double time, string daysHoursMinutesSeconds, string format)
        {
            string str = string.Empty;
            try
            {
                TimeSpan span = TimeSpan.Zero;
   

                daysHoursMinutesSeconds = Regex.Replace(daysHoursMinutesSeconds, @"\s", string.Empty);
                if (daysHoursMinutesSeconds.Equals("days", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("days", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("d", StringComparison.InvariantCultureIgnoreCase))
                {
                    span = TimeSpan.FromDays(time);
                }
                else if (daysHoursMinutesSeconds.Equals("hours", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("hour", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("h", StringComparison.InvariantCultureIgnoreCase))
                {
                    span = TimeSpan.FromHours(time);
                }
                else if (daysHoursMinutesSeconds.Equals("minutes", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("minute", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("m", StringComparison.InvariantCultureIgnoreCase))
                {
                    span = TimeSpan.FromMinutes(time);
                }
                else if (daysHoursMinutesSeconds.Equals("seconds", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("second", StringComparison.InvariantCultureIgnoreCase) || daysHoursMinutesSeconds.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                {
                    span = TimeSpan.FromSeconds(time);
                }

                str = span.ToString(format);
                ReturnStatusCode = 0;
            }
            catch (Exception e)
            {
                ReturnStatusCode = -1;
                str = $"{ErrorIntro} Message:  {e.Message}{Environment.NewLine}";
            }
            return str;
        }


    }
}
