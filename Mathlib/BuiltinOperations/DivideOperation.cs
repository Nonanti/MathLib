using Mathlib.Core;
using Mathlib.Core.Attributes;


namespace Mathlib.BuiltinOperations
{
    [MathOperation("Divide", "Divide")]
    public class DivideOperation : IMathOperation
    {
        public string Symbol => "/";
        public int Precedence => 2;

        public double Evaluate(double left, double right)
        {
            return left / right;
        }

        public string ToInfixString(string left, string right)
        {
            return $"({left} / {right})";
        }
    }
}
