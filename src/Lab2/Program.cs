using Lab2.Infrastructure;
using Lab2.Infrastructure.SingleEquation;
using Lab2.Infrastructure.SystemEquations;
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
            ProcessSingleEquation();
            Console.WriteLine("");
            ProcessSystemEquations();
            Console.ReadKey();
        }

        private static void ProcessSingleEquation()
        {
            var singleInfo = new SingleEquationInfo();
            var bisection = new BisectionSolver();
            var nord = new HordSolver();
            var newton = new NewtonSolver();
            var combined = new CombinedSolver();

            Console.WriteLine("Single equation:");

            var bisectionResult = bisection.Solve(A, B, Accuracy, singleInfo);
            Console.WriteLine("bisection: X={0}; I={1}", bisectionResult.X, bisectionResult.IterationCount);

            var nordResult = nord.Solve(A, B, Accuracy, singleInfo);
            Console.WriteLine("nord: X={0}; I={1}", nordResult.X, nordResult.IterationCount);

            var newtonResult = newton.Solve(A, B, Accuracy, singleInfo);
            Console.WriteLine("newton: X={0}; I={1}", newtonResult.X, newtonResult.IterationCount);

            var combinedResult = combined.Solve(A, B, Accuracy, singleInfo);
            Console.WriteLine("combined: X={0}; I={1}", combinedResult.X, combinedResult.IterationCount);
        }

        private static void ProcessSystemEquations()
        {
            var systemInfo = new SystemEquationsInfo();
            var newton = new NewtonSystemSolver();
            var seidel = new SeidelSystemSolver();
            var iteration = new IterationSystemSolver();

            Console.WriteLine("System equations:");

            var newtonResult = newton.Solve(Accuracy, systemInfo);
            Console.WriteLine("newton: X={0}; Y={1}; I={2}", newtonResult.X, newtonResult.Y, newtonResult.IterationCount);

            var seidelResult = seidel.Solve(Accuracy, systemInfo);
            Console.WriteLine("seidel: X={0}; Y={1}; I={2}", seidelResult.X, seidelResult.Y, seidelResult.IterationCount);

            var iterationResult = iteration.Solve(Accuracy, systemInfo);
            Console.WriteLine("iteration: X={0}; Y={1}; I={2}", iterationResult.X, iterationResult.Y, iterationResult.IterationCount);
        }
    }
}
