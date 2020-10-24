namespace Lab2.Infrastructure.Abstractions
{
    public record SingleEquationSolvingResult(double X, int IterationCount);

    public record SingleEquationInput(double A, double B, double Accuracy, ISingleEquation SingleEquation);

    public interface ISingleEquationSolver
    {
        SingleEquationSolvingResult Solve(SingleEquationInput input);
    }
}
