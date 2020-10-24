using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SystemEquations
{
    public class IterationSystemSolver : ISystemEquationsSolver
    {
        public SystemEquationsSolvingResult Solve(SystemEquationsInput input)
        {
            int count = 0;

            double x = input.X;
            double y = input.Y;

            double nextX = 0;
            double nextY = 0;

            do
            {
                count++;

                x = nextX;
                y = nextY;

                nextX = input.SystemEquations.GetXFromSecondEquation(y);
                nextY = input.SystemEquations.GetYFromFirstEquation(x);
            }
            while (Math.Max(Math.Abs(nextX - x), Math.Abs(nextY - y)) > input.Accuracy);

            return new SystemEquationsSolvingResult(nextY, nextX, count);
        }
    }
}
