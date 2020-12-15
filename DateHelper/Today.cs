using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateHelper
{
    public class Today : DateHelperProperties
    {
        public static string DateNow(string format)
        {
            string str = string.Empty;
            try
            {
                DateTime currentDate = DateTime.Now;
                str = currentDate.ToString(format);
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
