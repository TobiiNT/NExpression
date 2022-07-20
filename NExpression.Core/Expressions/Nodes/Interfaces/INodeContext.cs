using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Core.Expressions.Nodes.Interfaces
{
    public interface INodeContext
    {
        public IContext? Context { set; get; }
    }
}
