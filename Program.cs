using System;
using System.Collections.Generic;

namespace GDP
{
    class Program
    {
        static void Main()
        {
            List<Year> years = YearInput();

            // 
            Console.WriteLine("What method would you like to use to calculate the forecast?");
            Console.Write("Press 1 for Exponential Smoothing: ");
            switch (Console.ReadLine())
            {
                case "1":
                    CalcExponentialSmoothing(years);
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
        }
        private static void CalcExponentialSmoothing(List<Year> years)
        {
            Console.Write("Please add alpha coef (1 > alpha > 0)");
            if (!double.TryParse(Console.ReadLine(), out double alpha))
            {
                Console.WriteLine("Tough shit");
                return;
            }
            var res = Calculator.CalcForecast(alpha, years);
            foreach (var value in res)
            {
                Console.WriteLine(value);
            }
        }
        static List<Year> YearInput()
        {
            List<Year> years = new List<Year>();
            Console.Write("Please add a startup Year (example : 2008): ");
            int year;
            if (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Tough shit");
                return null;
            }

            for (var i = 0; i < int.MaxValue; i++)
            {
                Console.Write("Please add a GDP value or type q to quit: ");
                var input = Console.ReadLine();
                if (double.TryParse(input, out var GDPvalue))
                {
                    Year y = new Year(year + i, GDPvalue);
                    years.Add(y);
                }
                else if (input.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That's not a valid value!");
                }
            }
            return years;
        }
    }
}
