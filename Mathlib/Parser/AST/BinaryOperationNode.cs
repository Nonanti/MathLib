using System.Collections.Generic;
using Mathlib.BuiltinOperations;
using Mathlib.Interfaces;
namespace Mathlib.Core.AST
{
    public class BinaryOperationNode : ExpressionNode
    {
        private ExpressionNode rightExpanded;
        private MultiplyOperation multiplyOperation;

        public ExpressionNode Left { get; }
        public ExpressionNode Right { get; }
        public IMathOperation Operation { get; }
        public BinaryOperationNode(ExpressionNode left, ExpressionNode right, IMathOperation operation)
        {
            Left = left;
            Right = right;
            Operation = operation;
        }

        public BinaryOperationNode(ExpressionNode left, ExpressionNode rightExpanded, MultiplyOperation multiplyOperation)
        {
            Left = left;
            this.rightExpanded = rightExpanded;
            this.multiplyOperation = multiplyOperation;
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
