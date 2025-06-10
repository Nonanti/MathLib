using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mathlib.Interfaces
{
    public interface IExpression
    {
        double Evaluate(); 
        string ToInfixString();
    }
}