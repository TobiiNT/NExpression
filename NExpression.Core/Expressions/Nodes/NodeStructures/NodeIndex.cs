using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeIndex : INode
    {
        public INode ArrayNode { set; get; }
        public INode IndexNode { set; get; }
        public IOperation? Operation { set; get; }

        public NodeIndex(INode ArrayNode, INode IndexNode, IOperation? Operation)
        {
            this.ArrayNode = ArrayNode;
            this.IndexNode = IndexNode;
            this.Operation = Operation;
        }

        public object? Evaluate(IContext? ReadContext = null)
        {
            var Array = ArrayNode.Evaluate(ReadContext);
            var Index = IndexNode.Evaluate(ReadContext);
            var Result = Operation?.Evaluate(Array, Index);

            return Result;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            IndexNode.Traverse(ref Nodes);
            ArrayNode.Traverse(ref Nodes);
        }
    }
}
