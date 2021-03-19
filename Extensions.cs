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
                DateTime = data[2]
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
        public static double GetAverageTemp(this IEnumerable<TemperatureData> data)
        {
            var sumTemperatures = data.Select(d => d.Temperature).Sum();
            var numOfMeasurements = data.Count();
            var timestamps = data.Select(d => d.Timestamp);
            var startTime = timestamps.Take(1).First();
            var endTime = timestamps.TakeLast(1).First();
            var totalTime = endTime - startTime;
            var inhours = (double)totalTime / 3600;
            var indays = inhours / 24;
            Console.WriteLine($"Total time:{totalTime} s = {inhours:N2} h = {indays:N2} days");
            return sumTemperatures / numOfMeasurements;
        }
    }
}
