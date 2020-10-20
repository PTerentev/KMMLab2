using Lab2.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Infrastructure.SystemEquations
{
    public class IterationSystemSolver : ISystemEquationsSolver
    {
        public SystemEquationsSolvingResult Solve(double accuracy, ISystemEquations systemEquations)
        {
            //            $eps = $this->eps;
            //$i = 0;
            //$x = 0;
            //$y = 0;

            //    do
            //    {
            //    $i++;

            //    $x_sled = system::f2_get_x($y);
            //    $y_sled = system::f1_get_y($x);

            //        if (abs($x_sled - $x) <= $eps && abs($y_sled - $y) <= $eps) {
            //            break;
            //        }
            //    $x = $x_sled;
            //    $y = $y_sled;

            //    } while ($i < 20);

            //    return [
            //    $x, $y, $i
            //    ];

            int count = 0;

            double x = 0;
            double y = 0;

            double nextX;
            double nextY;

            do
            {
                count++;

                nextX = systemEquations.GetXFromSecondEquation(x);
                nextY = systemEquations.GetYFromFirstEquation(y);
            }
            while (Math.Max(Math.Abs(nextX - x), Math.Abs(nextY - y)) > accuracy);

            return new SystemEquationsSolvingResult(nextY, nextX, count);
        }
    }
}
