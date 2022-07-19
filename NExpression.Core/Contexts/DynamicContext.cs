using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;
using System.Reflection;

namespace NExpression.Core.Contexts
{
    public class DynamicContext : IOperationContext, IFunctionContext, IGetVariableContext, ISetVariableContext
    {
        public string Name { get; }
        private Dictionary<string, object?> Variables { set; get; }
        private Dictionary<string, IOperation?> Operations { set; get; }

        public DynamicContext() : this("")
        {

        }
        public DynamicContext(DynamicContext ReadWriteContext)
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

        public bool ContainVariable(string? PropertyName) => Variables.ContainsKey(PropertyName ?? "");
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
        public void DeclareVariable(string? PropertyName, Type? Type)
        {
            if (PropertyName != null)
            {
                if (!Variables.ContainsKey(PropertyName))
                {
                    Variables.Add(PropertyName, new Tuple<Type?, object?>(Type, null));
                }
                else throw new DuplicatedNameException(this, PropertyName);
            }
        }
        public void AssignVariable(string? PropertyName, object? Value)
        {
            if (PropertyName != null)
            {
                if (Variables.TryGetValue(PropertyName, out var ExistVariable))
                {
                    Variables[PropertyName] = Value;
                }
                else throw new NullVariableException(this, PropertyName);
            }
        }

        public object? this[string? PropertyName]
        {
            get
            {
                if (ResolveVariable(PropertyName, out object? Value))
                {
                    return Value;
                }
                return default;
            }
            set
            {
                if (!ContainVariable(PropertyName))
                    DeclareVariable(PropertyName, typeof(object));

                AssignVariable(PropertyName, value);
            }
        }

        public Dictionary<string, object?> GetAllVariables() => this.Variables.ToDictionary(i => i.Key, j => j.Value);
    }
}
