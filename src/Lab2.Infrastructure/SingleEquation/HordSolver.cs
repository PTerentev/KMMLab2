﻿using System;
using Lab2.Infrastructure.Abstractions;

namespace Lab2.Infrastructure.SingleEquation
{
    public class HordSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(SingleEquationInput input)
        {
            int count = 0;
            var a = input.A;
            var b = input.B;
            var singleEquation = input.SingleEquation;

            while (Math.Abs(b - a) > input.Accuracy)
            {
                count++;
                a = b - (b - a) * singleEquation.ExecuteEquation(b) / (singleEquation.ExecuteEquation(b) - singleEquation.ExecuteEquation(a));
                b = a + (a - b) * singleEquation.ExecuteEquation(a) / (singleEquation.ExecuteEquation(a) - singleEquation.ExecuteEquation(b));
            }

            return new SingleEquationSolvingResult(b, count);
        }
    }
}
