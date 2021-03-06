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

            var averageDaytimeTemp = data.SelectDayTime().GetAverageTemp();
            var averageNighttimeTemp = data.SelectNightTime().GetAverageTemp();
            var coldest = data.TakeColdest();
            var warmest = data.TakeWarmest();
            var averageTemp = data.GetAverageTemp();
            PrintItPretty(averageDaytimeTemp, averageNighttimeTemp, averageTemp);
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
        public static void PrintItPretty(double daytemp, double nighttemp, double avgtemp)
        {
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|    Time   :   Temp   |");
            Console.WriteLine("+----------------------+");

            Console.WriteLine($"| Day 8-17  :  {daytemp:N2} °C |");
            Console.WriteLine($"| Night 0-5 :  {nighttemp:N2} °C |");
            Console.WriteLine($"|  Average  :  {avgtemp:N2} °C |");
            Console.WriteLine("+----------------------+");
        }
    }
}
