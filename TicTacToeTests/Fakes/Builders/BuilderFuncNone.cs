using System;
using System.Threading.Tasks;

namespace TicTacToeTests.Fakes.Builders
{
    public class BuilderFuncNone : BuilderFunc<Task>
    {
        private Action _action;

        public BuilderFuncNone(string name) : base(name) => _action = () => throw new TestException(name);

        public void UpdateInvocation() => _action = () => { };

        public void Invoke()
        {
            InvokedCount++;
            _action();
        }

        public Task InvokeTask()
        {
            InvokedCount++;
            _action();
            return Task.Run(() => { });
        }

        public override void Assert(Action<Task> assertion) => throw new NotImplementedException("We don't assert against Task methods, I think...");
    }
}