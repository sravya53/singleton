using System;

namespace FinancialForecasting
{
    class Program
    {
        // Recursive method to calculate future value
        static double ForecastValue(double principal, double rate, int years)
        {
            if (years == 0)
            {
                return principal;
            }
            return ForecastValue(principal, rate, years - 1) * (1 + rate);
        }

        // Iterative method to calculate future value (Optimized)
        static double ForecastValueIterative(double principal, double rate, int years)
        {
            double futureValue = principal;
            for (int i = 0; i < years; i++)
            {
                futureValue *= (1 + rate);
            }
            return futureValue;
        }

        static void Main(string[] args)
        {
            double principal = 1000;  // Initial amount
            double rate = 0.05;       // Growth rate (5%)
            int years = 5;            // Number of years

            // Using Recursive Method
            double futureValueRecursive = ForecastValue(principal, rate, years);
            Console.WriteLine($"Future Value (Recursive) after {years} years: {futureValueRecursive:F2}");

            // Using Iterative Method
            double futureValueIterative = ForecastValueIterative(principal, rate, years);
            Console.WriteLine($"Future Value (Iterative) after {years} years: {futureValueIterative:F2}");
        }
    }
}