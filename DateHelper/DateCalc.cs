using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DateHelper
{
    public class DateCalc : DateHelperProperties
    {
        public static string CalculateDate(string date1, string operation, string date2, string format, string DaysMonthsYearsHoursMinutesSeconds = null)
        {
            string str = string.Empty;
            bool dmyhms = false;
            bool isTime = false;
            DateTime dDate1 = new DateTime();
            DateTime dDate2 = new DateTime();
            double dblTime = 0;
            TimeSpan time = TimeSpan.Zero;
            if (!string.IsNullOrEmpty(DaysMonthsYearsHoursMinutesSeconds) || !string.IsNullOrWhiteSpace(DaysMonthsYearsHoursMinutesSeconds))
            {
                DaysMonthsYearsHoursMinutesSeconds = Regex.Replace(DaysMonthsYearsHoursMinutesSeconds, @"\s", string.Empty);
                DaysMonthsYearsHoursMinutesSeconds = DaysMonthsYearsHoursMinutesSeconds.Trim();
                dmyhms = true;
            }
            
            var returnFormat = format;
            
            try
            {
                
                if (DateTime.TryParse(date1, out dDate1))
                {
                    string.Format(format, dDate1);
                }
                else
                {
                    throw new Exception("date1 could not be parsed.  It must be a valid date.");
                }
                if (TimeSpan.TryParse(date2, out time) || DateTime.TryParse(date2, out dDate2))
                {
                    try
                    {
                        string.Format(format, dDate2);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    try
                    {
                        string.Format(format, time);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    try
                    {
                        double.TryParse(date2, out dblTime);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                else
                {
                    if (!double.TryParse(date2, out dblTime))
                    {
                        throw new Exception("date2 could not be parsed.  It must be a valid date or int.");
                    }
                }
                
                if (dmyhms == true)
                {
                    switch (operation)
                    {
                        case "+" when DaysMonthsYearsHoursMinutesSeconds.Equals("days", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("day", StringComparison.InvariantCultureIgnoreCase):
                            str = dDate1.AddDays(dblTime).ToString(returnFormat);
                            break;
                        case "+" when DaysMonthsYearsHoursMinutesSeconds.Equals("months", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("month", StringComparison.InvariantCultureIgnoreCase):
                            str = dDate1.AddMonths((int)dblTime).ToString(returnFormat);
                            break;
                        case "+" when DaysMonthsYearsHoursMinutesSeconds.Equals("years", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("year", StringComparison.InvariantCultureIgnoreCase):
                            str = dDate1.AddYears((int)dblTime).ToString(returnFormat);
                            break;
                        case "+" when DaysMonthsYearsHoursMinutesSeconds.Equals("hours", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("hour", StringComparison.InvariantCultureIgnoreCase):
                            str = dDate1.AddHours(dblTime).ToString(returnFormat);
                            break;
                        case "+" when DaysMonthsYearsHoursMinutesSeconds.Equals("minutes", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("minute", StringComparison.InvariantCultureIgnoreCase):
                            str = dDate1.AddMinutes(dblTime).ToString(returnFormat);
                            break;
                        case "+" when DaysMonthsYearsHoursMinutesSeconds.Equals("seconds", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("second", StringComparison.InvariantCultureIgnoreCase):
                            str = dDate1.AddSeconds(dblTime).ToString(returnFormat);
                            break;
                        case "-" when DaysMonthsYearsHoursMinutesSeconds.Equals("days", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("day", StringComparison.InvariantCultureIgnoreCase):
                        {
                            if (dblTime > 0)
                            {
                                str = dDate1.AddDays(-dblTime).ToString(returnFormat);
                            }
                            else if(dDate2 != DateTime.MinValue)
                            {
                                str = (dDate1 - dDate2).ToString(returnFormat);
                            }
                            else if (time != TimeSpan.Zero)
                            {
                                str = dDate1.Add(-time).ToString(returnFormat);
                            }

                            break;
                        }
                        case "-" when (DaysMonthsYearsHoursMinutesSeconds.Equals("months", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("month", StringComparison.InvariantCultureIgnoreCase)):
                        {
                            if (dblTime > 0)
                            {
                                str = dDate1.AddMonths(-(int)dblTime).ToString(returnFormat);
                            }
                            else if (dDate2 != DateTime.MinValue)
                            {
                                str = (dDate1 - dDate2).ToString(returnFormat);
                            }
                            else if (time != TimeSpan.Zero)
                            {
                                str = dDate1.Add(-time).ToString(returnFormat);
                            }
                            //str = dDate1.AddMonths(-(int)dblTime).ToString(returnFormat);
                            break;
                        }
                        case "-" when (DaysMonthsYearsHoursMinutesSeconds.Equals("years", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("year", StringComparison.InvariantCultureIgnoreCase)):
                        {
                            if (dblTime > 0)
                            {
                                str = dDate1.AddYears(-(int)dblTime).ToString(returnFormat);
                            }
                            else if (dDate2 != DateTime.MinValue)
                            {
                                str = (dDate1 - dDate2).ToString(returnFormat);
                            }
                            else if (time != TimeSpan.Zero)
                            {
                                str = dDate1.Add(-time).ToString(returnFormat);
                            }
                            //str = dDate1.AddYears(-(int)dblTime).ToString(returnFormat);
                            break;
                        }
                        case "-" when (DaysMonthsYearsHoursMinutesSeconds.Equals("hours", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("hour", StringComparison.InvariantCultureIgnoreCase)):
                        {
                            if (dblTime > 0)
                            {
                                str = dDate1.AddHours(-dblTime).ToString(returnFormat);
                            }
                            else if (dDate2 != DateTime.MinValue)
                            {
                                str = (dDate1 - dDate2).ToString(returnFormat);
                            }
                            else if (time != TimeSpan.Zero)
                            {
                                str = dDate1.Add(-time).ToString(returnFormat);
                            }
                            //str = dDate1.AddHours(-dblTime).ToString(returnFormat);
                            break;
                        }
                        case "-" when (DaysMonthsYearsHoursMinutesSeconds.Equals("minutes", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("minute", StringComparison.InvariantCultureIgnoreCase)):
                        {
                            if (dblTime > 0)
                            {
                                str = dDate1.AddMinutes(-dblTime).ToString(returnFormat);
                            }
                            else if (dDate2 != DateTime.MinValue)
                            {
                                str = (dDate1 - dDate2).ToString(returnFormat);
                            }
                            else if (time != TimeSpan.Zero)
                            {
                                str = dDate1.Add(-time).ToString(returnFormat);
                            }
                            //str = dDate1.AddMinutes(-dblTime).ToString(returnFormat);
                            break;
                        }
                        case "-" when (DaysMonthsYearsHoursMinutesSeconds.Equals("seconds", StringComparison.InvariantCultureIgnoreCase) || DaysMonthsYearsHoursMinutesSeconds.Equals("second", StringComparison.InvariantCultureIgnoreCase)):
                        {
                            if (dblTime > 0)
                            {
                                str = dDate1.AddSeconds(-dblTime).ToString(returnFormat);
                            }
                            else if (dDate2 != DateTime.MinValue)
                            {
                                str = (dDate1 - dDate2).ToString(returnFormat);
                            }
                            else if (time != TimeSpan.Zero)
                            {
                                str = dDate1.Add(-time).ToString(returnFormat);
                            }
                            //str = dDate1.AddSeconds(-dblTime).ToString(returnFormat);
                            break;
                        }
                    }
                }
                
                else switch (operation)
                {
                    case "+" when ((string.IsNullOrEmpty(DaysMonthsYearsHoursMinutesSeconds) || string.IsNullOrWhiteSpace(DaysMonthsYearsHoursMinutesSeconds)) && time != TimeSpan.Zero):
                        str = dDate1.Add(time).ToString(returnFormat);
                        break;
                    case "-" when ((string.IsNullOrEmpty(DaysMonthsYearsHoursMinutesSeconds) || string.IsNullOrWhiteSpace(DaysMonthsYearsHoursMinutesSeconds)) && dDate2 != DateTime.MinValue):
                        str = (dDate1 - dDate2).ToString(returnFormat);
                        break;
                    case "-" when ((string.IsNullOrEmpty(DaysMonthsYearsHoursMinutesSeconds) || string.IsNullOrWhiteSpace(DaysMonthsYearsHoursMinutesSeconds)) && time != TimeSpan.Zero):
                        str = dDate1.Add(-time).ToString(returnFormat);
                        break;
                }



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
