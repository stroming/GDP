using System.Collections.Generic;

namespace GDP
{
    public class Calculator
    {
        // Using method of exponential smoothing.
        public static List<Year> CalcForecast(double alpha, List<Year> years )
        {
            List<Year> result = new List<Year>();
            for (var i = 0; i < years.Count; i++)
            {
                if (i == 0)
                {
                    years[i].GDPforecast = years[i].GDPvalue;                    
                }
                else
                {
                    years[i].GDPforecast = Formula(alpha, years[i]);
                }
                result.Add(years[i]);
            }
            Year lastYear = new Year(result[^1].year + 1, 0);
            lastYear.GDPforecast = Formula(alpha, years[^1]);
            result.Add(lastYear);
            return result;
        }

        private static double Formula(double alpha,Year year)
        {
            return alpha * year.GDPvalue + (1 - alpha) * year.GDPforecast;
        }
    }
}
