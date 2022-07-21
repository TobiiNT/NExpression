using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Nodes.NodeStructures;
using NExpression.Core.Helpers;
using System.Text;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Nodes.NodeDatas.Numbers;
using NExpression.Core.Expressions.Nodes.NodeDatas.Strings;
using NExpression.Core.Expressions.Nodes.NodeDatas.Booleans;

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
                var ArgsString = new StringBuilder();
                foreach (var Arguement in Function.Arguments)
                {
                    ArgsString.Append(Arguement.Identity() + ", ");
                }
                if (Function.Arguments.Length > 2)
                {
                    ArgsString.Remove(ArgsString.Length - 2, 2);
                }
              
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
                return $"({Assign.Variable.Identity()} {Assign.MathOperation.Symbol()} {Assign.Value.Identity()})";
            }
            else if (Node is NodeIndex Index)
            {
                return $"({Index.ArrayNode.Identity()} {Index.Operation} {Index.IndexNode.Identity()})";

            }
            else return Node.ToString();
        }
    }
}
