using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Nodes.NodeStructures;
using NExpression.Core.Helpers;
using NExpression.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Nodes.NodeDatas.Numbers;

namespace NExpression.Core.Extensions
{
    public static class NodeExtension
    {
        public static string? Identity(this INode Node)
        {
            if (Node == null)
                return null;
            if (Node is NodeNull)
                return "null";
            else if (Node is NodeBoolean Bool)
                return $"{Bool}";
            else if (Node is NodeNonFloatingDecimal Number)
                return $"{Number}";
            else if (Node is NodeString String)
                return $"\"{String}\"";
            else if (Node is NodeChar Char)
                return $"'{Char}'";
            else if (Node is NodeVariable Variable)
            {
                return $"(var {Variable.VariableName})";
            }
            else if (Node is NodeFunctionCall Function)
            {
                StringBuilder ArgsString = new StringBuilder();
                foreach (var Arguement in Function.Arguments)
                {
                    ArgsString.Append(Arguement.Identity() + ", ");
                }
                ArgsString.Remove(ArgsString.Length - 2, 2);

                return $"({Function.FunctionName}({ArgsString}))";
            }
            else if (Node is NodePostfix Postfix)
            {
                MathOperation? Operation = OperationHelpers.GetMathOperation(Postfix.Operation);
                return $"({Postfix.LeftNode.Identity()} {Operation?.Symbol()})";
            }
            else if (Node is NodeUnaryTree Unary)
            {
                MathOperation? Operation = OperationHelpers.GetMathOperation(Unary.Operation);
                return $"({Operation?.Symbol()} {Unary.RightNode.Identity()})";
            }
            else if (Node is NodeTernaryTree Ternary)
            {
                return $"({Ternary.ConditionNode?.Identity()} ? {Ternary.LeftNode.Identity()} : {Ternary.RightNode.Identity()})";
            }
            else if (Node is NodeBinaryTree Binary)
            {
                MathOperation? Operation = OperationHelpers.GetMathOperation(Binary.Operation);
                return $"({Binary.LeftNode.Identity()} {Operation?.Symbol()} {Binary.RightNode.Identity()})";
            }
            else if (Node is NodeAssignment Assign)
            {
                MathOperation? Operation = OperationHelpers.GetMathOperation(Assign.Operation);
                return $"({Assign.Variable.Identity()} {Operation?.Symbol()} {Assign.Value.Identity()})";
            }
            else return Node.ToString();
        }
    }
}
