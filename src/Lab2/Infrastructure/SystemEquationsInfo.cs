using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure
{
    internal class SystemEquationsInfo : ISystemEquations
    {
        public double ExecuteFirstEquation(double x, double y)
        {
            return Math.Cos(x + 0.5) + y - 0.8;
        }

        public double ExecuteSecondEquation(double x, double y)
        {
            return Math.Sin(y) - 2 * x - 1.6;
        }

        public double GetDerivedByXFromFirstEquation(double x, double y)
        {
            return -1 * Math.Sin(x + 0.5);
        }

        public double GetDerivedByXFromSecondEquation(double x, double y)
        {
            return -2;
        }

        public double GetDerivedByYFromFirstEquation(double x, double y)
        {
            return 1;
        }

        public double GetDerivedByYFromSecondEquation(double x, double y)
        {
            return Math.Cos(y);
        }

        public double GetXFromSecondEquation(double y)
        {
            return (Math.Sin(y) - 1.6) / 2;
        }

        public double GetYFromFirstEquation(double x)
        {
            return 0.8 - Math.Cos(x + 0.5);
        }
    }
}
