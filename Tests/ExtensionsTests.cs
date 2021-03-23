using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using Uppgift5;

namespace Tests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void DateTime_Parse_Works_As_Intended()
        {
            string data = "2021-03-11 16:02:34";
            var date = DateTime.Parse(data);

            Assert.AreEqual(2021, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(11, date.Day);
            Assert.AreEqual(16, date.Hour);
            Assert.AreEqual(2, date.Minute);
            Assert.AreEqual(34, date.Second);
        }
        [TestMethod]
        public void Selects_Day_Time_Correct()
        {

            string[] data = { "2021-03-11 16:02:34" ,
                              "2021-03-12 07:19:22" ,
                              "2021-03-14 21:11:20"};
            var dates = data.Select(d => new TemperatureData
            {
                DateTime = DateTime.Parse(d)
            });
            var daytime = dates.SelectDayTime();

            foreach (var timestamp in daytime)
            {
                Assert.AreEqual(16, timestamp.DateTime.Hour);
            }
        }
        [TestMethod]
        public void Selects_Night_Time_Correct()
        {

            string[] data = { "2021-03-11 16:02:34" ,
                              "2021-03-16 01:11:19" ,
                              "2021-03-14 21:11:20"};
            var dates = data.Select(d => new TemperatureData
            {
                DateTime = DateTime.Parse(d)
            });
            var daytime = dates.SelectNightTime();

            foreach (var timestamp in daytime)
            {
                Assert.AreEqual(1, timestamp.DateTime.Hour);
            }
        }
    }
}
