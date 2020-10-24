namespace Lab2.Infrastructure.Abstractions
{
    public record SystemEquationsSolvingResult(double Y, double X, int IterationCount);

    public record SystemEquationsInput(double Y, double X, double Accuracy, ISystemEquations SystemEquations);

    public interface ISystemEquationsSolver
    {
        SystemEquationsSolvingResult Solve(SystemEquationsInput input);
    }
}
