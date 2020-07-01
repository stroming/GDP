using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;

namespace GDP
{
    public class MemoryStorage : IStorage
    {
        private readonly List<int> YearsList;
        private readonly List<double> ValueList;
        public int Year;
        public double Value;
        public MemoryStorage()
        {
            YearsList = new List<int>();
            ValueList = new List<double>();
        }
        public void WriteYearAndValue(int year, double value)
        {
            YearsList.Add(year);
            ValueList.Add(value);
        }
        public void Read(int yearIndex, int valueIndex)
        {
            Year = YearsList[yearIndex];
            Value = ValueList[valueIndex];
        }
    }
}
