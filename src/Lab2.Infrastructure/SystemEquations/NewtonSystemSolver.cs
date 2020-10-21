using Lab2.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Infrastructure.SystemEquations
{
    public class NewtonSystemSolver : ISystemEquationsSolver
    {
        public SystemEquationsSolvingResult Solve(double accuracy, ISystemEquations systemEquations)
        {
            double norm;
            double x = 20;
            double y = -10;
            int count = 0;

            var aMatrix = new double[2, 2];

            do
            {
                count++;

                aMatrix[0, 0] = systemEquations.GetDerivedByXFromFirstEquation(x, y);
                aMatrix[0, 1] = systemEquations.GetDerivedByYFromFirstEquation(x, y);
                aMatrix[1, 0] = systemEquations.GetDerivedByXFromSecondEquation(x, y);
                aMatrix[1, 1] = systemEquations.GetDerivedByYFromSecondEquation(x, y);

                aMatrix = GetInverseMatrix(aMatrix);

                var dx = -aMatrix[0, 0] * systemEquations.ExecuteFirstEquation(x, y) + -1 * aMatrix[0, 1] * systemEquations.ExecuteSecondEquation(x, y);
                var dy = -aMatrix[1, 0] * systemEquations.ExecuteFirstEquation(x, y) + -1 * aMatrix[1, 1] * systemEquations.ExecuteSecondEquation(x, y);

                x += dx;
                y += dy;

                var b1 = systemEquations.ExecuteFirstEquation(x, y);
                var b2 = systemEquations.ExecuteSecondEquation(x, y);
                norm = Math.Sqrt(Math.Pow(b1, 2) + Math.Pow(b2, 2));
            }
            while (norm > accuracy);

            return new SystemEquationsSolvingResult(y, x, count);
        }

        private double[,] GetInverseMatrix(double[,] matrix)
        {
            var inversed = new double[2, 2];

            var determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            inversed[0, 0] = matrix[1, 1] / determinant;
            inversed[1, 1] = matrix[0, 0] / determinant;
            inversed[0, 1] = -1 * matrix[0, 1] / determinant;
            inversed[1, 0] = -1 * matrix[1, 0] / determinant;

            return inversed;
        }
    }
}
