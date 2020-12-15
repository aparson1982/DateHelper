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
            //Console.WriteLine(FormatDate.DateFormat("1 1 2021","ddd, MMM dd, yyyy hh:mm:ss tt gg"));
            //Console.WriteLine(FormatDate.DateFormat("Jan 4 2021","MM/dd/yyyy"));
            //Console.WriteLine(DateComparer.CompareDates("01/04/2021 12:20pm", ">", "Jan 4 2021 11:00pm"));
            //string time = DateCalc.CalculateDate("Jan 1 2021 12:20am", "-", "2020/09/07", @"G", "");
            //Console.WriteLine(DateCalc.CalculateDate("Jan 1, 2021 12:20am", "+", "10.00:12", @"MMMM/dd/yyyy hh:mm:ss tt", ""));
            //Console.WriteLine(time);
            //Console.WriteLine(FormatDate.ConvertTimeToDecimal(time,"h"));
            //Console.WriteLine(FormatDate.ConvertTimeToDecimal("12:20","m"));
            //Console.WriteLine(FormatDate.ConvertDecimalToTime(5.31, "hours", @"dd\.hh\:mm"));
            Console.WriteLine(DateComparer.IsDate("9/18"));
        }
    }
}
