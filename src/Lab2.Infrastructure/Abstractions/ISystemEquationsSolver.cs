namespace Lab2.Infrastructure.Abstractions
{
    public interface ISystemEquationsSolver
    {
        SystemEquationsSolvingResult Solve(double accuracy, ISystemEquations systemEquations);
    }
}
