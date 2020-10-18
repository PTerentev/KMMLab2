using System;
using Lab2.Infrastructure.Abstractions;

namespace Lab2.Infrastructure.SingleEquation
{
    public class HordSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(double a, double b, double accuracy, ISingleEquation singleEquation)
        {
            int count = default;
            while (Math.Abs(b - a) > accuracy)
            {
                count++;
                a = b - (b - a) * singleEquation.ExecuteEquation(b) / (singleEquation.ExecuteEquation(b) - singleEquation.ExecuteEquation(a));
                b = a + (a - b) * singleEquation.ExecuteEquation(a) / (singleEquation.ExecuteEquation(a) - singleEquation.ExecuteEquation(b));
            }

            return new SingleEquationSolvingResult(b, count);
        }
    }
}
