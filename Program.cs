using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Uppgift5
{
    class Program
    {
        static void Main(string[] args)
        {
            var filepath = @"C:\Users\simon.tonnes\source\repos\CODE_IS_KING\Uppgift5\temperatures.csv";
            Console.WriteLine($"Data source: {filepath}");
            var data = filepath.ParseToTempData();
            //var daytime = from d in data
            //              where d.DateTime is 
            var coldest = data.TakeColdest();
            var warmest = data.TakeWarmest();
            var averageTemp = data.GetAverageTemp();
            Console.WriteLine($"Average temp: {averageTemp:N2} °C");
            PrintData(coldest, "Coldest");
            PrintData(warmest, "Warmest");
        }
        public static void PrintData(IEnumerable<TemperatureData> datapoint, string identifier)
        {
            foreach (var info in datapoint)
            {
                Console.WriteLine($"{identifier}: {info.DateTime}  Temp: {info.Temperature} °C");
            }
        }
    }
}
