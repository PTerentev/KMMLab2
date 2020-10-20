using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SingleEquation
{
    public sealed class NewtonSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(double a, double b, double accuracy, ISingleEquation singleEquation)
        {
            int count = 1;
            double x0 = b;
            double x1 = ProcessIteration(x0, singleEquation);

            while (Math.Abs(x1 - x0) > accuracy)
            {
                count++;
                x0 = x1;
                x1 = ProcessIteration(x0, singleEquation);
            }

            return new SingleEquationSolvingResult(x1, count);
        }

        private double ProcessIteration(double x, ISingleEquation singleEquation)
        {
            return x - singleEquation.ExecuteEquation(x) / singleEquation.ExecuteDerivedEquation(x);
        }
    }
}
