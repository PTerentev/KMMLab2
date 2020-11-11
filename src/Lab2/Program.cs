using Lab2.Infrastructure;
using Lab2.Infrastructure.Abstractions;
using Lab2.Infrastructure.SingleEquation;
using Lab2.Infrastructure.SystemEquations;
using System;

namespace Lab2
{
    class Program
    {
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

            var singleInput = new SingleEquationInput(-2, 2, 0.0001, singleInfo);

            var bisectionResult = bisection.Solve(singleInput);
            Console.WriteLine("Bisection: X={0}; I={1}", bisectionResult.X, bisectionResult.IterationCount);

            var nordResult = nord.Solve(singleInput);
            Console.WriteLine("Nord: X={0}; I={1}", nordResult.X, nordResult.IterationCount);

            var newtonResult = newton.Solve(singleInput);
            Console.WriteLine("Newton: X={0}; I={1}", newtonResult.X, newtonResult.IterationCount);

            var combinedResult = combined.Solve(singleInput);
            Console.WriteLine("Combined: X={0}; I={1}", combinedResult.X, combinedResult.IterationCount);
        }

        private static void ProcessSystemEquations()
        {
            var systemInfo = new SystemEquationsInfo();
            var newton = new NewtonSystemSolver();
            var seidel = new SeidelSystemSolver();
            var iteration = new IterationSystemSolver();

            Console.WriteLine("System equations:");

            var systemInput = new SystemEquationsInput(20, -10, 0.01, systemInfo);

            var newtonResult = newton.Solve(systemInput);
            Console.WriteLine("Newton: X={0}; Y={1}; I={2}", newtonResult.X, newtonResult.Y, newtonResult.IterationCount);

            var seidelResult = seidel.Solve(systemInput);
            Console.WriteLine("Seidel: X={0}; Y={1}; I={2}", seidelResult.X, seidelResult.Y, seidelResult.IterationCount);

            var iterationResult = iteration.Solve(systemInput);
            Console.WriteLine("iteration: X={0}; Y={1}; I={2}", iterationResult.X, iterationResult.Y, iterationResult.IterationCount);
        }
    }
}
