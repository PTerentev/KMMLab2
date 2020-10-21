using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SystemEquations
{
    public class SeidelSystemSolver : ISystemEquationsSolver
    {
        public SystemEquationsSolvingResult Solve(double accuracy, ISystemEquations systemEquations)
        {
            int count = 0;
            double x = 20;
            double y = -10;
            double nextX = x;
            double nextY = y;

            do
            {
                count++;

                x = nextX;
                y = nextY;

                nextX = systemEquations.GetXFromSecondEquation(y);
                nextY = systemEquations.GetYFromFirstEquation(nextX);
            }
            while (Math.Abs(nextX - x) > accuracy && Math.Abs(nextY - y) > accuracy);

            return new SystemEquationsSolvingResult(y, x, count);
        }
    }
}
