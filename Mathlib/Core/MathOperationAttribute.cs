using System;

namespace Mathlib.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MathOperationAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }

        public MathOperationAttribute(string name, string description = "")
        {
            Name = name;
            Description = description;
        }
    }
}
