namespace Lab2.Infrastructure.Abstractions
{
    public interface ISingleEquationSolver
    {
        SingleEquationSolvingResult Solve(double a, double b, double accuracy, ISingleEquation singleEquation);
    }
}
