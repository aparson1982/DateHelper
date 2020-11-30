using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateHelper;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Console.WriteLine(FormatDate.DateFormat("Jan 4 2021","MM/dd/yyyy"));
            //Console.WriteLine(DateComparer.CompareDates("01/04/2021", "==", "Jan 4 2021"));
            string time = DateCalc.CalculateDate("Jan 1 2021 12:20am", "-", "5.2:00:01", @"G", "hours");
            Console.WriteLine(DateCalc.CalculateDate("Jan 1 2021 12:20am", "-", "5.2:00:01", @"G", "hours"));
            //Console.WriteLine(FormatDate.ConvertTimeToDecimal(time,"h"));

            //Console.WriteLine(FormatDate.ConvertDecimalToTime(5.31, "hours", @"dd\.hh\:mm"));
        }
    }
}
