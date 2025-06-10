using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mathlib.Core.Attributes;

namespace Mathlib.Core
{
    public static class Loader
    {
        public static Dictionary<string, IMathOperation> LoadAllOperations()
        {
            var operations = new Dictionary<string, IMathOperation>();

            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(MathOperationAttribute), true).Length > 0);

            foreach (var type in types)
            {
                if (Activator.CreateInstance(type) is IMathOperation op)
                {
                    operations[op.Symbol] = op;
                }
            }

            return operations;
        }
    }
}
