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
    }
}
