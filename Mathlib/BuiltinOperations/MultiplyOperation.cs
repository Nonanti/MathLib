using Mathlib.Core;
using Mathlib.Core.Attributes;


namespace Mathlib.BuiltinOperations
{
    [MathOperation("Multiply", "Subtract")]
    public class MultiplyOperation : IMathOperation
    {
        public string Symbol => "-";
        public int Precedence => 1;

        public double Evaluate(double left, double right)
        {
            return left * right;
        }

        public string ToInfixString(string left, string right)
        {
            return $"({left} * {right})";
        }
    }
}
