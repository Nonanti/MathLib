using System;
using System.Collections.Generic;

namespace Mathlib.Core.AST
{
    public class VariableNode : ExpressionNode
    {
        public string Name { get; }

        public VariableNode(string name)
        {
            Name = name;
        }

        public override double Evaluate(Dictionary<string, double> variables)
        {
            if (variables != null && variables.TryGetValue(Name, out double value))
                return value;

            throw new Exception($"Variable '{Name}' is not defined.");
        }

        public override string ToInfixString()
        {
            return Name;
        }
    }
}
