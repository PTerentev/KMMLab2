using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SingleEquation
{
    public sealed class NewtonSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(SingleEquationInput input)
        {
            int count = 1;
            double x0 = input.B;
            double x1 = ProcessIteration(x0, input.SingleEquation);

            while (Math.Abs(x1 - x0) > input.Accuracy)
            {
                count++;
                x0 = x1;
                x1 = ProcessIteration(x0, input.SingleEquation);
            }

            return new SingleEquationSolvingResult(x1, count);
        }

        private double ProcessIteration(double x, ISingleEquation singleEquation)
        {
            return x - singleEquation.ExecuteEquation(x) / singleEquation.ExecuteDerivedEquation(x);
        }
    }
}
