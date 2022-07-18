using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace NExpression.Core.Extensions
{
    public static class MemoizerExtension
    {
        internal static ConditionalWeakTable<object, ConcurrentDictionary<string, object>> _weakCache =
            new ConditionalWeakTable<object, ConcurrentDictionary<string, object>>();

        public static TResult Memoized<T1, TResult>(
            this object context,
            T1 arg,
            Func<T1, TResult> f,
            [CallerMemberName] string? cacheKey = null)
            where T1 : notnull
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (cacheKey == null) throw new ArgumentNullException(nameof(cacheKey));

            var objCache = _weakCache.GetOrCreateValue(context);

            var methodCache = (ConcurrentDictionary<T1, TResult>)objCache
                .GetOrAdd(cacheKey, _ => new ConcurrentDictionary<T1, TResult>());

            return methodCache.GetOrAdd(arg, f);
        }

        public static TResult Memoized<T1, T2, T3, TResult>(
           this object context,
           T1 arg1, T2 arg2, T3 arg3,
           Func<T1, T2, T3, TResult> f,
           [CallerMemberName] string? cacheKey = null)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (cacheKey == null) throw new ArgumentNullException(nameof(cacheKey));

            var objCache = _weakCache.GetOrCreateValue(context);

            Func<Tuple<T1, T2, T3>, TResult> convertedFunc = MyFuncConverter<T1, T2, T3, TResult>.ConvertFunction(f);

            var methodCache = (ConcurrentDictionary<Tuple<T1, T2, T3>, TResult>)objCache
                .GetOrAdd(cacheKey, _ => new ConcurrentDictionary<Tuple<T1, T2, T3>, TResult>());

            return methodCache.GetOrAdd(Tuple.Create(arg1, arg2, arg3), convertedFunc);
        }
    }

    class MyFuncConverter<T1, T2, T3, TResult>
    {
        static Func<T1, T2, T3, TResult> StoredFunction;

        public static Func<Tuple<T1, T2, T3>, TResult> ConvertFunction(Func<T1, T2, T3, TResult> InputFunction)
        {
            StoredFunction = InputFunction;
            return new Func<Tuple<T1, T2, T3>, TResult>(MyFunc);
        }

        private static TResult MyFunc(Tuple<T1, T2, T3> tuple)
        {
            return StoredFunction(tuple.Item1, tuple.Item2, tuple.Item3);
        }
    }
}
