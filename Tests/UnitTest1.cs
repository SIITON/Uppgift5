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
        public void DateTimeParseWorksAsIntended()
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
    }
}
