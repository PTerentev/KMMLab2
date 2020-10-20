using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SystemEquations
{
    public class SeidelSystemSolver : ISystemEquationsSolver
    {
        public SystemEquationsSolvingResult Solve(double accuracy, ISystemEquations systemEquations)
        {
            int count = 0;
            double x = 0;
            double y = 0;
            double nextX;
            double nextY;

            do
            {
                count++;

                nextX = systemEquations.GetXFromSecondEquation(y);
                nextY = systemEquations.GetYFromFirstEquation(nextX);

                x = nextX;
                y = nextY;
            }
            while (Math.Abs(nextX - x) > accuracy && Math.Abs(nextY - y) > accuracy);

            return new SystemEquationsSolvingResult(y, x, count);
        }
    }
}
