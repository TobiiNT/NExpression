using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;
using System.Reflection;

namespace NExpression.Core.Contexts
{
    public class DynamicContext<T> : List<T>, IOperationContext, IFunctionContext, IGetVariableContext, ISetVariableContext
    {
        public string Name { get; }
        private Dictionary<string, object?> Variables { set; get; }
        private Dictionary<string, IOperation?> Operations { set; get; }
        public DynamicContext(DynamicContext<T> ReadWriteContext)
        {
            Name = ReadWriteContext.Name;
            Variables = ReadWriteContext.Variables;
            Operations = ReadWriteContext.Operations;
        }
        public DynamicContext(string ContextName)
        {
            Name = ContextName;
            Variables = new Dictionary<string, object?>();
            Operations = new Dictionary<string, IOperation?>();
        }
        public void RegisterOperation<U>(string Name)
        {
            if (typeof(IOperation).GetTypeInfo().IsAssignableFrom(typeof(U).Ge‌​tTypeInfo()))
            {
                if (!Operations.ContainsKey(Name))
                {
                    Operations.Add(Name, (IOperation?)Activator.CreateInstance<U>());
                }
                else throw new DuplicatedNameException(this, Name);
            }
            else throw new InvalidCastException($"Cannot register non-operation item");
        }

        public object? CallFunction(string Name, object?[] Arguments)
        {
            if (Operations.TryGetValue(Name, out IOperation? Operation) && Operation != null)
            {
                return CallOperation(Operation, Arguments);
            }
            throw new NullOperationException(this.Name, Name);
        }

        public object? CallOperation(IOperation? Operation, object?[] Arguments)
        {
            object? FirstArg = Arguments.Length >= 1 ? Arguments[0] : null;
            object? SecondArg = Arguments.Length >= 2 ? Arguments[1] : null;
            object? ThirdArg = Arguments.Length >= 3 ? Arguments[2] : null;

            return Operation?.Evaluate(FirstArg, SecondArg, ThirdArg);
        }

        public bool ResolveVariable(string? PropertyName, out object? Value)
        {
            if (PropertyName != null && Variables.TryGetValue(PropertyName, out Value))
            {
                return true;
            }
            else
            {
                Value = default;
                return false;
            }
        }
        public bool ResolveVariable<V>(string? PropertyName, out V? Value)
        {
            if (ResolveVariable(PropertyName, out object? CurrentValue))
            {
                Value = (V?)Convert.ChangeType(CurrentValue, typeof(V?));
                return true;
            }
            else
            {
                Value = default;
                return false;
            }
        }

        public void AssignVariable(string? PropertyName, object? Value)
        {
            if (PropertyName != null)
            {
                if (Variables.ContainsKey(PropertyName))
                {
                    Variables[PropertyName] = Value;
                }
                else Variables.Add(PropertyName, Value);
            }
        }

        public T? this[string? PropertyName]
        {
            get
            {
                if (ResolveVariable(PropertyName, out T? Value))
                {
                    return Value;
                }
                return default;
            }
            set
            {
                AssignVariable(PropertyName, value);
            }
        }

        public Dictionary<string, object?> GetAllVariables() => this.Variables.ToDictionary(i => i.Key, j => j.Value);
    }

    public class DynamicContext : DynamicContext<object>
    {
        public DynamicContext() : base("")
        {

        }
        public DynamicContext(string Name) : base(Name)
        {

        }
    }
}
