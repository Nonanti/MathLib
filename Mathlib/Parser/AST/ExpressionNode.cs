using System.Collections.Generic;

namespace Mathlib.Core.AST
{
    public abstract class ExpressionNode
    {
        public abstract double Evaluate(Dictionary<string, double> variables);
        public abstract string ToInfixString();
    }
}
