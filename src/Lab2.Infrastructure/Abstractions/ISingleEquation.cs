namespace Lab2.Infrastructure.Abstractions
{
    public interface ISingleEquation
    {
        double ExecuteEquation(double x);

        double ExecuteDerivedEquation(double x);

        double ExecuteSecondDerivedEquation(double x);
    }
}
