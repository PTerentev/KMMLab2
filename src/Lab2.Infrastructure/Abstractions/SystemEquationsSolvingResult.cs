namespace Lab2.Infrastructure.Abstractions
{
    public class SystemEquationsSolvingResult : SingleEquationSolvingResult
    {
        public SystemEquationsSolvingResult(double y, double x, int iterationCount) : base (x, iterationCount)
        {
            Y = y;
        }

        public double Y { get; }
    }
}
