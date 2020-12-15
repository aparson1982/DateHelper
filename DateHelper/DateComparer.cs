using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DateHelper
{
    public class DateComparer : DateHelperProperties
    {
        
        public static string CompareDates(string date1, string comparer, string date2)
        {
            string str = string.Empty;
            try
            {
                DateTime dateInput1 = DateTime.Parse(date1);
                DateTime dateInput2 = DateTime.Parse(date2);

                comparer = Regex.Replace(comparer, @"\s", string.Empty);

                if (comparer.Trim().Equals(">") || comparer.Trim().Equals("greaterthan", StringComparison.InvariantCultureIgnoreCase) || comparer.Trim().Equals("greater", StringComparison.InvariantCultureIgnoreCase) || comparer.Trim().Equals("gt", StringComparison.InvariantCultureIgnoreCase))
                {
                    str = (dateInput1.Date > dateInput2.Date).ToString();
                }
                else if (comparer.Trim().Equals(">=") || comparer.Trim().Equals("=>") || comparer.Trim().Equals("greaterthanequalto", StringComparison.InvariantCultureIgnoreCase) || comparer.Trim().Equals("greaterthanorequalto", StringComparison.InvariantCultureIgnoreCase) || comparer.Trim().Equals("gte", StringComparison.InvariantCultureIgnoreCase))
                {
                    str = (dateInput1.Date >= dateInput2.Date).ToString();
                }
                else if (comparer.Trim().Equals("<=") || comparer.Trim().Equals("=<") || comparer.Trim().Equals("lessthanequalto", StringComparison.InvariantCultureIgnoreCase) || comparer.Trim().Equals("lessthanorequalto", StringComparison.InvariantCultureIgnoreCase) || comparer.Trim().Equals("lte", StringComparison.InvariantCultureIgnoreCase))
                {
                    str = (dateInput1.Date <= dateInput2.Date).ToString();
                }
                else if (comparer.Trim().Equals("<") || comparer.Trim().Equals("lessthan", StringComparison.InvariantCultureIgnoreCase) || comparer.Trim().Equals("less", StringComparison.InvariantCultureIgnoreCase) || comparer.Trim().Equals("lt", StringComparison.InvariantCultureIgnoreCase))
                {
                    str = (dateInput1.Date < dateInput2.Date).ToString();
                }
                else if (comparer.Trim().Equals("=") || comparer.Trim().Equals("==") || comparer.Trim().Equals("equalto") || comparer.Trim().Equals("equal") || comparer.Trim().Equals("eq") || comparer.Trim().Equals("equal"))
                {
                    str = (dateInput1.Date == dateInput2.Date).ToString();
                }
                else
                {
                    throw new ArgumentException("The comparison operator is not valid.");
                }
                ReturnStatusCode = 0;
            }
            catch (Exception e)
            {
                ReturnStatusCode = -1;
                str = $"{ErrorIntro} Message:  {e.Message}{Environment.NewLine}";
            }
            return str;
        }

        
        public static bool IsDate(string date)
        {
            if (DateTime.TryParse(date, out _) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        


    }
}
