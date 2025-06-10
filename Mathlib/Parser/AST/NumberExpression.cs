using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathlib.Interfaces;

namespace Mathlib.Parser.AST
{
   public class NumberExpression : IExpression
    {
        public double Value { get; }
        public NumberExpression(double value)
        {
            Value = value;
        }
        public double Evaluate() => Value;
        public override string ToString() => Value.ToString();
        public string ToInfixString() => ToString();
    }
}