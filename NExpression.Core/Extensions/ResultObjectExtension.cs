using NExpression.Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Core.Extensions
{
    public static class ResultObjectExtension
    {
        public static string Identity(this object? Object)
        {
            if (Object == null)
            {
                return "null";
            }
            else if (Object is DynamicContext Dynamic)
            {
                return "Context " + Dynamic.Name;
            }
            else if (Object is string String)
            {
                return $"\"{String}\"";
            }
            else if (Object is char Char)
            {
                return $"\'{Char}\'";
            }
            else return Object.ToString();
        }
    }
}
