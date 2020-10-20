using Lab2.Infrastructure;
using Lab2.Infrastructure.SingleEquation;
using System;

namespace Lab2
{
    class Program
    {
        private const double A = -1;
        private const double B = 5;
        private const double Accuracy = 0.0001;

        static void Main(string[] args)
        {
            var singleInfo = new SingleEquationInfo();
            var bisection = new BisectionSolver();
            var nord = new HordSolver();
            var newton = new NewtonSolver();
            var combined = new CombinedSolver();

            var bisectionResult = bisection.Solve(A, B, Accuracy, singleInfo);
            Console.WriteLine("bisection: X={0}; I={1}", bisectionResult.X, bisectionResult.IterationCount);

            var nordResult = nord.Solve(A, B, Accuracy, singleInfo);
            Console.WriteLine("nord: X={0}; I={1}", nordResult.X, nordResult.IterationCount);

            var newtonResult = newton.Solve(A, B, Accuracy, singleInfo);
            Console.WriteLine("newton: X={0}; I={1}", newtonResult.X, newtonResult.IterationCount);

            var combinedResult = combined.Solve(A, B, Accuracy, singleInfo);
            Console.WriteLine("combined: X={0}; I={1}", combinedResult.X, combinedResult.IterationCount);

            Console.ReadKey();
        }
    }
}
