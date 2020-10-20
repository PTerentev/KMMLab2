using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SingleEquation
{
    public class CombinedSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(double a, double b, double accuracy, ISingleEquation singleEquation)
        {
            int count = 1;
            double x0, x1, x2, e1;

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

            while (Math.Abs(e1 - x1) > accuracy)
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
