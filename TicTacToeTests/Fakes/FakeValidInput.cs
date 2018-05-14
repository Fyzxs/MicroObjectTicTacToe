using tictactoe.IO;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeValidResponse<T> : IValidResponse<T>
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<T> _responseItem = new BuilderFuncReturn<T>("FakeValidInput#Input");

            public Builder Response(T expected)
            {
                _responseItem.UpdateInvocation(expected);
                return this;
            }
            public FakeValidResponse<T> Build()
            {
                return new FakeValidResponse<T>
                {
                    _reponse = _responseItem
                };
            }
        }

        private BuilderFuncReturn<T> _reponse;
        private FakeValidResponse() { }
        public T Response() => _reponse.Invoke();

        public void AssertInputInvoked() => _reponse.AssertInvoked();
    }
}