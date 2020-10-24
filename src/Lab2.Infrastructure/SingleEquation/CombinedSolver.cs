using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SingleEquation
{
    public class CombinedSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(SingleEquationInput input)
        {
            int count = 1;
            double x0, x1, x2, e1;
            var a = input.A;
            var b = input.B;
            var singleEquation = input.SingleEquation;

            if (singleEquation.ExecuteEquation(a) * singleEquation.ExecuteSecondDerivedEquation(a) > 0)
            {
                x0 = a;
            }
            else
            {
                x0 = b;
            }

            x1 = x0 - singleEquation.ExecuteEquation(x0) / singleEquation.ExecuteDerivedEquation(x0);
            x2 = a - ((b - a) * singleEquation.ExecuteEquation(a) / (singleEquation.ExecuteEquation(b) - singleEquation.ExecuteEquation(a)));
            e1 = (x1 + x2) / 2;

            while (Math.Abs(e1 - x1) > input.Accuracy)
            {
                count++;
                a = x1;
                b = x2;
                x1 = a - singleEquation.ExecuteEquation(a) / singleEquation.ExecuteDerivedEquation(a);
                x2 = a - ((b - a) * singleEquation.ExecuteEquation(a) / (singleEquation.ExecuteEquation(b) - singleEquation.ExecuteEquation(a)));
                e1 = (x1 + x2) / 2;
            }

            return new SingleEquationSolvingResult(x1, count);
        }
    }
}
