using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathlib.Interfaces;

namespace Mathlib.Parser.AST
{
     public class BinaryOperationExpression : IExpression
    {
        public IExpression Left { get; }
        public IExpression Right { get; }
        public string OperatorSymbol { get; }

        public BinaryOperationExpression(IExpression left, IExpression right, string opSymbol)
        {
            Left = left;
            Right = right;
            OperatorSymbol = opSymbol;
        }

        public double Evaluate()
        {
            return OperatorSymbol switch
            {
                "+" => Left.Evaluate() + Right.Evaluate(),
                "-" => Left.Evaluate() - Right.Evaluate(),
                "*" => Left.Evaluate() * Right.Evaluate(),
                "/" => Left.Evaluate() / Right.Evaluate(),
                "^" => System.Math.Pow(Left.Evaluate(), Right.Evaluate()),
                _ => throw new System.NotImplementedException($"Operator {OperatorSymbol} not supported.")
            };
        }
        public override string ToString() => $"({Left} {OperatorSymbol} {Right})";
        public string ToInfixString() => $"{Left.ToInfixString()} {OperatorSymbol} {Right.ToInfixString()}";
    }
}