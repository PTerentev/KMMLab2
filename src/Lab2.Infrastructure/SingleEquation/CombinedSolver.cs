using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SingleEquation
{
    public class CombinedSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(double a, double b, double accuracy, ISingleEquation singleEquation)
        {
            int count = default;

            while (Math.Abs(a - b) > 2 * accuracy)
            {
                count++;
                if (singleEquation.ExecuteEquation(a) * singleEquation.ExecuteSecondDerivedEquation(a) < 0)
                {
                    a -= singleEquation.ExecuteEquation(a) * ((a - b) / (singleEquation.ExecuteEquation(a) - singleEquation.ExecuteEquation(b)));
                }
                else if (singleEquation.ExecuteEquation(a) * singleEquation.ExecuteSecondDerivedEquation(a) > 0)
                {
                    a -= (singleEquation.ExecuteEquation(a) / singleEquation.ExecuteDerivedEquation(a));
                }

                if (singleEquation.ExecuteEquation(b) * singleEquation.ExecuteSecondDerivedEquation(b) < 0)
                {
                    b -= singleEquation.ExecuteEquation(b) * ((b - a) / (singleEquation.ExecuteEquation(b) - singleEquation.ExecuteEquation(a)));
                }
                else if (singleEquation.ExecuteEquation(b) * singleEquation.ExecuteSecondDerivedEquation(b) > 0)
                {
                    b -= singleEquation.ExecuteEquation(b) / singleEquation.ExecuteDerivedEquation(b);
                }
            }

            var resultX = (a + b) / 2;
            return new SingleEquationSolvingResult(resultX, count);
        }
    }
}
