using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace GDP
{
    public class DiskStorage : IStorage
    {            
        public int Year;
        public double Value;
        public DiskStorage()
        {
        }
        public void WriteYearAndValue(int year, double value)
        {
            using (var writer = File.AppendText("Stats.txt"))
            {
                writer.WriteLine($"{year}");
                writer.WriteLine($"{value}");
            }
        }       
        public void Read(int yearIndex, int valueIndex)
        {
            using (var reader = File.OpenText("Stats.txt"))
            {
                var line = reader.ReadLine();
            }
        }
        public static void ClearFile()
        {
            File.WriteAllText("Stats.txt", string.Empty);
        }
    }
}
