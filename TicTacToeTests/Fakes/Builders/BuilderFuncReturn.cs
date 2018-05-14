using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicTacToeTests.Fakes.Builders
{
    public class BuilderFuncReturn<T> : BuilderFunc<T>
    {
        private Func<T>[] _funcs;
        private int _funcIndex;
        private int _valueIndex;
        private readonly List<object> _values = new List<object>();

        public BuilderFuncReturn(string name) : base(name) => _funcs = new Func<T>[] { () => throw new TestException(name) };

        public void UpdateInvocation(params T[] valuesToReturn) => UpdateInvocation(FuncWrapper(valuesToReturn));

        private static Func<T>[] FuncWrapper(T[] valuesToReturn)
        {
            int length = valuesToReturn.Length;
            Func<T>[] funcs = new Func<T>[length];
            for (int idx = 0; idx < length; idx++)
            {
                int scopedIdx = idx;
                funcs[idx] = () => valuesToReturn[scopedIdx];
            }
            return funcs;
        }

        private T ExecuteFunc()
        {
            int length = _funcs.Length;
            if (length <= _funcIndex) return _funcs[length - 1]();

            return _funcs[_funcIndex++]();
        }

        private object GetValue()
        {
            int length = _values.Count;
            if (length <= _valueIndex) return _values[length - 1];

            return _values[_valueIndex++];
        }

        public void UpdateInvocation(params Func<T>[] funcs) => _funcs = funcs;

        public T Invoke(object value = null)
        {
            _values.Add(value);
            InvokedCount++;
            return ExecuteFunc();
        }

        public Task<T> InvokeTask(object value = null) => Task.FromResult(Invoke(value));

        public override void Assert(Action<T> assertion) => assertion(ExecuteFunc());

        public void AssertValue(Action<object> assertion) => assertion(GetValue());
    }
}