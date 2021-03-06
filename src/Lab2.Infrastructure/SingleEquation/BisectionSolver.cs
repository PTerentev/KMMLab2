﻿using Lab2.Infrastructure.Abstractions;

namespace Lab2.Infrastructure.SingleEquation
{
    public class BisectionSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(double a, double b, double accuracy, ISingleEquation singleEquation)
        {
            int count = 0;
            double c = 0;

            while (b - a > accuracy)
            {
                count++;
                c = (a + b) / 2;

                if (singleEquation.ExecuteEquation(b) * singleEquation.ExecuteEquation(c) < 0)
                {
                    a = c;
                }
                else
                {
                    b = c;
                }
            }

            return new SingleEquationSolvingResult(c, count);
        }
    }
}
