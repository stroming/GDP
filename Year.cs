using System;
namespace GDP
{
    public class Year
    {
        public int year { get; private set; }        
        public double GDPvalue { get; private set; }
        public double GDPforecast;

        public Year(int year, double gDPvalue)
        {
            this.year = year;
            GDPvalue = gDPvalue;
        }

        public override string ToString()
        {
            return $"The Year {year} The vaue {GDPvalue} The Forecast {GDPforecast}";
        }
    }    
}
