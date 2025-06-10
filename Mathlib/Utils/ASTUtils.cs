using Mathlib.BuiltinOperations;
using Mathlib.Core.AST;

public static class ASTUtils
{
    public static ExpressionNode Expand(ExpressionNode node)
    {
        if (node is BinaryOperationNode binOp)
        {
            var leftExpanded = Expand(binOp.Left);
            var rightExpanded = Expand(binOp.Right);

            if (binOp.Operation is MultiplyOperation)
            {
                if (leftExpanded is BinaryOperationNode leftBin &&
                    (leftBin.Operation is AddOperation || leftBin.Operation is SubtractOperation))
                {
                    var leftPart = new BinaryOperationNode(leftBin.Left, rightExpanded, new MultiplyOperation());
                    var rightPart = new BinaryOperationNode(leftBin.Right, rightExpanded, new MultiplyOperation());
                    return new BinaryOperationNode(Expand(leftPart), Expand(rightPart), leftBin.Operation);
                }
                else if (rightExpanded is BinaryOperationNode rightBin &&
                         (rightBin.Operation is AddOperation || rightBin.Operation is SubtractOperation))
                {
                    var leftPart = new BinaryOperationNode(leftExpanded, rightBin.Left, new MultiplyOperation());
                    var rightPart = new BinaryOperationNode(leftExpanded, rightBin.Right, new MultiplyOperation());
                    return new BinaryOperationNode(Expand(leftPart), Expand(rightPart), rightBin.Operation);
                }
            }
            return new BinaryOperationNode(leftExpanded, rightExpanded, binOp.Operation);
        }
        return node; 
    }
    public static string ToInfixString(ExpressionNode node, int parentPrecedence = 0)
    {
        if (node is ConstantNode constNode)
            return constNode.Value.ToString();

        if (node is VariableNode varNode)
            return varNode.Name;

        if (node is BinaryOperationNode binNode)
        {
            var op = binNode.Operation;
            var leftStr = ToInfixString(binNode.Left, op.Precedence);
            var rightStr = ToInfixString(binNode.Right, op.Precedence);

            var expr = $"{leftStr} {op.Symbol} {rightStr}";

            if (op.Precedence < parentPrecedence)
                return $"({expr})";

            return expr;
        }

        throw new Exception("Unknown node type");
    }
}
