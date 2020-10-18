namespace Lab2.Infrastructure.Abstractions
{
    public interface ISystemEquations
    {
        double ExecuteFirstEquation(double x, double y);

        double GetYFromFirstEquation(double x);

        double ExecuteSecondEquation(double x, double y);

        double GetXFromSecondEquation(double x);

        double GetDerivedByXFromFirstEquation(double x, double y);

        double GetDerivedByXFromSecondEquation(double x, double y);

        double GetDerivedByYFromFirstEquation(double x, double y);

        double GetDerivedByYFromSecondEquation(double x, double y);
    }
}
