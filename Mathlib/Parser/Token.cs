using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mathlib.Parser
{
    public class Token
    {
        public TokenType Type { get; }
        public string Text { get; }
        public Token(TokenType type, string text)
        {
            Type = type;
            Text = text;
        }
        public override string ToString() => $"{Type}: '{Text}'";
    }
}