using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SystemEquations
{
    public class SeidelSystemSolver : ISystemEquationsSolver
    {
        public SystemEquationsSolvingResult Solve(SystemEquationsInput input)
        {
            int count = 0;
            double x = input.X;
            double y = input.Y;
            double nextX = x;
            double nextY = y;

            do
            {
                count++;

                x = nextX;
                y = nextY;

                nextX = input.SystemEquations.GetXFromSecondEquation(y);
                nextY = input.SystemEquations.GetYFromFirstEquation(nextX);
            }
            while (Math.Abs(nextX - x) > input.Accuracy && Math.Abs(nextY - y) > input.Accuracy);

            return new SystemEquationsSolvingResult(y, x, count);
        }
    }
}
