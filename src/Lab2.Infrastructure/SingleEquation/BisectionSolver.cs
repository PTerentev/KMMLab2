using Lab2.Infrastructure.Abstractions;

namespace Lab2.Infrastructure.SingleEquation
{
    public class BisectionSolver : ISingleEquationSolver
    {
        public SingleEquationSolvingResult Solve(SingleEquationInput input)
        {
            int count = 0;
            double c = 0;
            var a = input.A;
            var b = input.B;
            var singleEquation = input.SingleEquation;

            while (b - a > input.Accuracy)
            {
                count++;
                c = (a + b) / 2;

                if (singleEquation.ExecuteEquation(b) * singleEquation.ExecuteEquation(c) < 0)
                {
                    a = c;
                }
                else
                {
                    b = c;
                }
            }

            return new SingleEquationSolvingResult(c, count);
        }
    }
}
