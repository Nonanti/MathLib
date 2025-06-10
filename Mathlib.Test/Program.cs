using System;
using System.Collections.Generic;
using Mathlib.Core;
using Mathlib.Core.AST;
using Mathlib.Parser;
using Mathlib.BuiltinOperations;
using Mathlib.Interfaces;
using Mathlib.AdvancedOperations;

namespace Mathlib.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var operations = new Dictionary<string, IMathOperation>()
            {
                { "+", new AddOperation() },
                { "-", new SubtractOperation() },
                { "*", new MultiplyOperation() },
                { "/", new DivideOperation() },
                { "^", new PowerOperation() }
            };
            string expression = "(x+2)*(x-2)";
            Console.WriteLine($"0rginal: {expression}");
            var lexer = new Lexer(expression);
            List<Token> tokens = lexer.Tokenize();
            Console.WriteLine("Tokens:");
            foreach (var t in tokens)
            {
                Console.WriteLine($" - {t.Type}: {t.Text}");
            }
            var parser = new Parser.Parser(tokens, operations);
            ExpressionNode ast = parser.ParseExpression();
            Console.WriteLine($"Parse: {ast.ToInfixString()}");
            var expandedAst = ASTUtils.Expand(ast);
            var variables = new Dictionary<string, double> { { "x", 3 } };
            ILimitOperation limitOp = new LimitOperation();
            double limit = limitOp.CalculateLimit(x => (x * x - 4) / (x - 2), 2);
            Console.WriteLine($"Limit (x->2) of (x^2 - 4) / (x - 2): {limit}");
        }
    }
}
