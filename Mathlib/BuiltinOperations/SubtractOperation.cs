using Mathlib.Core;
using Mathlib.Core.Attributes;
using Mathlib.Interfaces;


namespace Mathlib.BuiltinOperations
{
    [MathOperation("Subtract", "Subtract")]
    public class SubtractOperation : IMathOperation
    {
        public string Symbol => "-";
        public int Precedence => 1;

        public double Evaluate(double left, double right)
        {
            return left - right;
        }

        public string ToInfixString(string left, string right)
        {
            return $"({left} - {right})";
        }
    }
}
