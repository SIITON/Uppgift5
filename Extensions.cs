using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Uppgift5
{
    public static class Extensions
    {
        public static IEnumerable<TemperatureData> ParseToTempData(this string filepath)
        {
            var csvLines = File.ReadAllLines(filepath);
            var csvData = csvLines.Select(l => l.Split(';').ToArray());
            var tempData = csvData.Select(data => new TemperatureData
            {
                Timestamp = int.Parse(data[0]),
                Temperature = double.Parse(data[1], CultureInfo.InvariantCulture),
                DateTime = DateTime.Parse(data[2])
            }).AsEnumerable();
            return tempData;
        }
        public static IEnumerable<TemperatureData> TakeColdest(this IEnumerable<TemperatureData> data)
        {
            return (from d in data
                    orderby d.Temperature ascending
                    select d).Take(1);
        }
        public static IEnumerable<TemperatureData> TakeWarmest(this IEnumerable<TemperatureData> data)
        {
            return (from d in data
                    orderby d.Temperature descending
                    select d).Take(1);
        }
        public static IEnumerable<TemperatureData> SelectDayTime(this IEnumerable<TemperatureData> data)
        {
            return from d in data
                   where d.DateTime.Hour >= 8 && d.DateTime.Hour < 17
                   select d;
        }
        public static IEnumerable<TemperatureData> SelectNightTime(this IEnumerable<TemperatureData> data)
        {
            return from d in data
                   where d.DateTime.Hour >= 0 && d.DateTime.Hour < 5
                   select d;
        }
        public static double GetAverageTemp(this IEnumerable<TemperatureData> data)
        {
            var sumOfTemperatures = data.Select(d => d.Temperature).Sum();
            var numOfMeasurements = data.Count();
            return sumOfTemperatures / numOfMeasurements;
        }
    }
}
