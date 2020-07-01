using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace GDP
{
    public class Calculations
    {
        public static double MethodOfExponentialSmoothing(double alpha, double value, double forecast)
        {
            double newforecast = forecast switch
            {
                0 => value,
                _ => (alpha * value) + ((1 - alpha) * forecast),
            };
            return newforecast;
        }
        public void RegressionModelForecast(List<int> StoringTheYears, List<double> StoringTheValue, List<double> StoringTheForecast)
        {
            var upperHalfBetaCoeficient = ((StoringTheYears.Count - 1) * Sigma(StoringTheValue, StoringTheForecast)) - (SigmaForecast(StoringTheForecast) * SigmaValue(StoringTheValue));
            var lowerHalfBetaCoeficient = ((StoringTheYears.Count - 1) * SigmaForecastSqr(StoringTheForecast) - Math.Pow(SigmaForecast(StoringTheForecast), 2));
            var betaCoeficient = upperHalfBetaCoeficient / lowerHalfBetaCoeficient;
            var alphaRegressCoef = (SigmaValue(StoringTheValue) / (StoringTheYears.Count - 1)) - ((betaCoeficient * (SigmaForecast(StoringTheForecast)) / (StoringTheYears.Count - 1)));
            Console.WriteLine("For how many years would you like a forecast using the Regression Method?(1,2,3,4...etc.)");
            var regressionForecast = betaCoeficient * StoringTheForecast[StoringTheForecast.Count - 1] + alphaRegressCoef;
            Console.WriteLine($"This is the regression forecast for 2019 {regressionForecast}");
        }
        private double SigmaForecast(List<double> list)
        {
            double sum = 0;
            foreach (var value in list)
            {
                sum += value;
            }
            sum -= list[^1];
            return Math.Round(sum, 3);
        }
        private double SigmaValue(List<double> list)
        {
            double sum = 0;
            foreach (var value in list)
            {
                sum += value;
            }
            sum -= list[0];
            return Math.Round(sum, 3);
        }
        private double Sigma(List<double> GDPvalues, List<double> forecast)
        {
            double sum = 0;
            for (var i = 1; i < GDPvalues.Count; i++)
            {
                sum += GDPvalues[i] * forecast[i - 1];
            }
            return Math.Round(sum, 3);
        }
        private double SigmaForecastSqr(List<double> list)
        {
            double sum = 0;
            foreach (var value in list)
            {
                sum += (Math.Pow(value, 2));
            }
            sum -= list[^1];
            return Math.Round(sum, 3);
        }
    }
}
