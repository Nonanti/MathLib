using Mathlib.Core.Attributes;
using Mathlib.Core;
using Mathlib.Interfaces;

[MathOperation("power", "Calculates power operation")]
public class PowerOperation : IMathOperation
{
    public string Symbol => "^";
    public int Precedence => 4;

    public double Evaluate(double left, double right)
    {
        return Math.Pow(left, right);
    }

    public string ToInfixString(string left, string right)
    {
        return $"({left} ^ {right})";
    }
}
