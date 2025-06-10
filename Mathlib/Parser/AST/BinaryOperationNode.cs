using System.Collections.Generic;
using Mathlib.Interfaces;
namespace Mathlib.Core.AST
{
    public class BinaryOperationNode : ExpressionNode
    {
        public ExpressionNode Left { get; }
        public ExpressionNode Right { get; }
        public IMathOperation Operation { get; }
        public BinaryOperationNode(ExpressionNode left, ExpressionNode right, IMathOperation operation)
        {
            Left = left;
            Right = right;
            Operation = operation;
        }
        public override double Evaluate(Dictionary<string, double> variables)
        {
            var leftVal = Left.Evaluate(variables);
            var rightVal = Right.Evaluate(variables);
            return Operation.Evaluate(leftVal, rightVal);
        }
        public override string ToInfixString()
        {
            return Operation.ToInfixString(Left.ToInfixString(), Right.ToInfixString());
        }
    }
}
