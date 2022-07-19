using NExpression.Core.Contexts.Interfaces;

namespace NExpression.Core.Exceptions
{
    public class DuplicatedNameException : Exception
    {
        public DuplicatedNameException(IContext? Context, string MemberName)
            : base($"Context '{Context?.Name}' already defines a member called '{MemberName}'")
        {
        }
    }


}
