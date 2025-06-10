using System;
using System.Collections.Generic;
using System.Text;

namespace Mathlib.Parser
{
    public class Lexer
    {
        private readonly string _text;
        private int _pos;
        private char CurrentChar => _pos < _text.Length ? _text[_pos] : '\0';

        public Lexer(string text)
        {
            _text = text;
            _pos = 0;
        }

        private void Advance() => _pos++;

        private void SkipWhitespace()
        {
            while (char.IsWhiteSpace(CurrentChar))
                Advance();
        }

        private Token Number()
        {
            var sb = new StringBuilder();

            while (char.IsDigit(CurrentChar) || CurrentChar == '.')
            {
                sb.Append(CurrentChar);
                Advance();
            }

            return new Token(TokenType.Number, sb.ToString());
        }

        private Token Identifier()
        {
            var sb = new StringBuilder();

            while (char.IsLetter(CurrentChar))
            {
                sb.Append(CurrentChar);
                Advance();
            }

            return new Token(TokenType.Identifier, sb.ToString());
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (CurrentChar != '\0')
            {
                if (char.IsWhiteSpace(CurrentChar))
                {
                    SkipWhitespace();
                    continue;
                }

                if (char.IsDigit(CurrentChar))
                {
                    tokens.Add(Number());
                    continue;
                }

                if (char.IsLetter(CurrentChar))
                {
                    tokens.Add(Identifier());
                    continue;
                }

                switch (CurrentChar)
                {
                    case '+':
                        tokens.Add(new Token(TokenType.Plus, "+"));
                        Advance();
                        break;
                    case '-':
                        tokens.Add(new Token(TokenType.Minus, "-"));
                        Advance();
                        break;
                    case '*':
                        tokens.Add(new Token(TokenType.Multiply, "*"));
                        Advance();
                        break;
                    case '/':
                        tokens.Add(new Token(TokenType.Divide, "/"));
                        Advance();
                        break;
                    case '(':
                        tokens.Add(new Token(TokenType.LeftParen, "("));
                        Advance();
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.RightParen, ")"));
                        Advance();
                        break;
                    case '^':
                        tokens.Add(new Token(TokenType.Power, "^"));
                        Advance();
                        break;
                    default:
                        throw new Exception($"Unknown character: {CurrentChar}");
                }
            }

            tokens.Add(new Token(TokenType.EOF, ""));
            return tokens;
        }
    }
}
