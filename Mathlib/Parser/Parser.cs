using System;
using System.Collections.Generic;
using Mathlib.Core.AST;
using Mathlib.BuiltinOperations; 
using Mathlib.Core;
using Mathlib.Interfaces;

namespace Mathlib.Parser
{
    public class Parser
    {
        private readonly List<Token> _tokens;
        private int _pos;
        private Token CurrentToken => _pos < _tokens.Count ? _tokens[_pos] : null;
        private Dictionary<string, IMathOperation> _operations;
        public Parser(List<Token> tokens, Dictionary<string, IMathOperation> operations)
        {
            _tokens = tokens;
            _pos = 0;
            _operations = operations;
        }

        private void Eat(TokenType type)
        {
            if (CurrentToken.Type == type)
                _pos++;
            else
                throw new Exception($"Expected token {type} but got {CurrentToken.Type}");
        }

        public ExpressionNode ParseExpression()
        {
            return ParseAddSubtract();
        }
        private ExpressionNode ParseAddSubtract()
        {
            var node = ParseMultiplyDivide();

            while (CurrentToken.Type == TokenType.Plus || CurrentToken.Type == TokenType.Minus)
            {
                var opToken = CurrentToken;
                Eat(opToken.Type);

                var right = ParseMultiplyDivide();

                IMathOperation op;
                if (opToken.Type == TokenType.Plus)
                    op = _operations["+"];
                else
                    op = _operations["-"];

                node = new BinaryOperationNode(node, right, op);
            }

            return node;
        }
        private ExpressionNode ParseMultiplyDivide()
        {
            var node = ParseFactor();

            while (CurrentToken.Type == TokenType.Multiply || CurrentToken.Type == TokenType.Divide)
            {
                var opToken = CurrentToken;
                Eat(opToken.Type);

                var right = ParseFactor();

                IMathOperation op;
                if (opToken.Type == TokenType.Multiply)
                    op = _operations["*"];
                else
                    op = _operations["/"];

                node = new BinaryOperationNode(node, right, op);
            }

            return node;
        }
        private ExpressionNode ParseFactor()
        {
            var token = CurrentToken;

            if (token.Type == TokenType.Number)
            {
                Eat(TokenType.Number);
                double val = double.Parse(token.Text);
                return new ConstantNode(val);
            }
            else if (token.Type == TokenType.Identifier)
            {
                Eat(TokenType.Identifier);
                return new VariableNode(token.Text);
            }
            else if (token.Type == TokenType.LeftParen)
            {
                Eat(TokenType.LeftParen);
                var node = ParseExpression();
                Eat(TokenType.RightParen);
                return node;
            }
            else if (token.Type == TokenType.Minus)
            {
                Eat(TokenType.Minus);
                var factor = ParseFactor();
                var zero = new ConstantNode(0);
                var op = _operations["-"];
                return new BinaryOperationNode(zero, factor, op);
            }
            else
            {
                throw new Exception($"Unexpected token {token.Type}");
            }
        }
    }
}
