using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathlib.Interfaces;

namespace Mathlib.Parser.AST
{
    public class VariableExpression : IExpression
    {
        public string Name { get; }
        public VariableExpression(string name)
        {
            Name = name;
        }
        public double Evaluate()
        {
            throw new System.NotImplementedException("Variable evaluation not implemented.");
        }
        public override string ToString() => Name;
        public string ToInfixString() => Name;
    }
}