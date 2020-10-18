namespace Lab2.Infrastructure.Abstractions
{
    public class SingleEquationSolvingResult
    {
        public SingleEquationSolvingResult(double x, int iterationCount)
        {
            X = x;
            IterationCount = iterationCount;
        }

        public double X { get; }

        public int IterationCount { get; }
    }
}
