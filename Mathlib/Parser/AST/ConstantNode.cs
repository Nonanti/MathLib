using System.Collections.Generic;

namespace Mathlib.Core.AST
{
    public class ConstantNode : ExpressionNode
    {
        public double Value { get; }

        public ConstantNode(double value)
        {
            Value = value;
        }

        public override double Evaluate(Dictionary<string, double> variables)
        {
            return Value;
        }

        public override string ToInfixString()
        {
            return Value.ToString();
        }
    }
}
