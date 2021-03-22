using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace Uppgift5
{
    public class TemperatureData
    {
        public int Timestamp {get; set;}
        public double Temperature { get; set; }
        public DateTime DateTime { get; set; }
        //public List<double> Temp { get; private set; }
        //public List<int> Seconds { get; private set; }
        //public TemperatureData()
        //{
        //    Temp = new List<double>();
        //}
        //public static TemperatureData Parse(string csvFilepath)
        //{
        //    using (TextFieldParser parser = new TextFieldParser(csvFilepath))
        //    {
        //        parser.TextFieldType = FieldType.Delimited;
        //        parser.SetDelimiters(";");
        //        while (!parser.EndOfData)
        //        {
        //            string[] fields = parser.ReadFields();
        //            //if (double.TryParse(fields[1], out var temp))
        //            //{
        //            //    Temp.Add(temp);
        //            //}


        //        }
        //    }
        //    return new TemperatureData
        //    {
        //        Seconds = int.Parse(fields[0]),
        //        Temp = double.Parse()
        //    }
        //}
    }
}
