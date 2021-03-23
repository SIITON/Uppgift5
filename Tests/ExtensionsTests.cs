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
        [TestMethod]
        public void Takes_Coldest_Data_Correct()
        {
            string[] data = {"1615878151;1.3;2021-03-16 08:02:31",
                             "1615878919;1.8;2021-03-16 08:15:19",
                             "1615879831;2.3;2021-03-16 08:30:31"};
            var csvData = data.Select(l => l.Split(';').ToArray());
            var tempData = csvData.Select(data => new TemperatureData
            {
                Timestamp = int.Parse(data[0]),
                Temperature = double.Parse(data[1], CultureInfo.InvariantCulture),
                DateTime = DateTime.Parse(data[2])
            }).AsEnumerable();
            var coldest = tempData.TakeColdest();
            foreach (var measurement in coldest)
            {
                Assert.AreEqual(1.3, measurement.Temperature);
                Assert.AreEqual(2, measurement.DateTime.Minute);
            }
            
        }
        [TestMethod]
        public void Takes_Warmest_Data_Correct()
        {
            string[] data = {"1615878151;1.3;2021-03-16 08:02:31",
                             "1615878919;1.8;2021-03-16 08:15:19",
                             "1615879831;2.3;2021-03-16 08:30:31"};
            var csvData = data.Select(l => l.Split(';').ToArray());
            var tempData = csvData.Select(data => new TemperatureData
            {
                Timestamp = int.Parse(data[0]),
                Temperature = double.Parse(data[1], CultureInfo.InvariantCulture),
                DateTime = DateTime.Parse(data[2])
            }).AsEnumerable();
            var warmest = tempData.TakeWarmest();
            foreach (var measurement in warmest)
            {
                Assert.AreEqual(2.3, measurement.Temperature);
                Assert.AreEqual(30, measurement.DateTime.Minute);
            }

        }
    }
}
