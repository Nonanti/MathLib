using System;
using Mathlib.Interfaces;
using Mathlib.AdvancedOperations;

namespace Mathlib.AdvancedOperations
{
    public class LimitOperation : ILimitOperation
    {
        public string Name => "Limit";

        public string Symbol => "lim";
        public int Precedence => 100;
        public double CalculateLimit(Func<double, double> function, double approachPoint, bool fromRight = true)
        {
            double h = fromRight ? 1e-1 : -1e-1;
            double lastValue = function(approachPoint + h);

            for (int i = 0; i < 10; i++)
            {
                h /= 10;
                double currentValue = function(approachPoint + h);
                if (Math.Abs(currentValue - lastValue) < 1e-7)
                    return currentValue;
                lastValue = currentValue;
            }

            return lastValue;
        }
        public double Evaluate(double left, double right)
        {
            throw new NotImplementedException();
        }
        public double Execute(params double[] inputs)
        {
            throw new NotImplementedException("Use CalculateLimit with a function delegate.");
        }
        public string ToInfixString(string left, string right)
        {
            throw new NotImplementedException();
        }
    }
}
