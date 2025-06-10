using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathlib.Core;

namespace Mathlib.Interfaces
{
   public interface ILimitOperation : IMathOperation{double CalculateLimit(Func<double, double> function, double approachPoint, bool fromRight = true);}
}