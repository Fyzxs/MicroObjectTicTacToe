using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeTests.Fakes.Builders
{
    public class BuilderFuncVoid<T> : BuilderFunc<T>
    {
        private Action[] _actions;
        private readonly List<T> _values = new List<T>();
        private int _actionIndex;
        private int _valueIndex;

        public BuilderFuncVoid(string name) : base(name)
        {
            _actions = new Action[] { () => throw new TestException(name) };
        }

        public void UpdateInvocation() => UpdateInvocation(() => { });

        public void UpdateInvocation(params Action[] action) => _actions = action;

        private void ExecuteAction()
        {
            if (_actions.Length == _actionIndex)
            {
                _actions[_actions.Length - 1]();
                return;
            }

            _actions[_actionIndex++]();
        }

        public void Invoke(T value)
        {
            _values.Add(value);
            InvokedCount++;
            ExecuteAction();
        }

        public Task InvokeTask(T value) => Task.Run(() => Invoke(value));

        private T GetValueInOrderOfExecution()
        {
            if (!_values.Any()) AssertInvoked();
            return _values.Count <= _valueIndex
                ? _values[_valueIndex - 1]
                : _values[_valueIndex++];
        }

        public override void Assert(Action<T> assertion) => assertion(GetValueInOrderOfExecution());

        public void AssertInvokedWith(T expected) => GetValueInOrderOfExecution().Should().Be(expected);
    }
}