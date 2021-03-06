﻿using Lab2.Infrastructure.Abstractions;
using System;

namespace Lab2.Infrastructure.SystemEquations
{
    public class IterationSystemSolver : ISystemEquationsSolver
    {
        public SystemEquationsSolvingResult Solve(double accuracy, ISystemEquations systemEquations)
        {
            int count = 0;

            double x = 20;
            double y = -10;

            double nextX = 0;
            double nextY = 0;

            do
            {
                count++;

                x = nextX;
                y = nextY;

                nextX = systemEquations.GetXFromSecondEquation(y);
                nextY = systemEquations.GetYFromFirstEquation(x);
            }
            while (Math.Max(Math.Abs(nextX - x), Math.Abs(nextY - y)) > accuracy);

            return new SystemEquationsSolvingResult(nextY, nextX, count);
        }
    }
}
