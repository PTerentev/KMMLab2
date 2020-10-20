using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure
{
    internal class SingleEquationInfo : ISingleEquation
    {
        public double ExecuteDerivedEquation(double x)
        {
            return Math.Exp(x) - 10;
        }

        public double ExecuteEquation(double x)
        {
            return Math.Exp(x) - 10 * x;
        }

        public double ExecuteSecondDerivedEquation(double x)
        {
            return Math.Exp(x);
        }
    }
}
