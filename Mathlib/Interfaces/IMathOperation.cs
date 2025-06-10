using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mathlib.Interfaces
{
    public interface IMathOperation
    {
        string Symbol { get; }
        int Precedence { get; }
        double Evaluate(double left, double right);
        string ToInfixString(string left, string right); 
    }
}