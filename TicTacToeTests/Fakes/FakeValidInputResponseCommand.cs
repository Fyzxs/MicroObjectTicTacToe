using FluentAssertions;
using tictactoe.IO;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeValidInputResponseAction<T> : IValidInputResponseAction<T>
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<T> _responseItem = new BuilderFuncReturn<T>("FakeValidInputResponseCommand#Response");

            public Builder Response(T expected)
            {
                _responseItem.UpdateInvocation(expected);
                return this;
            }
            public FakeValidInputResponseAction<T> Build()
            {
                return new FakeValidInputResponseAction<T> { _response = _responseItem };
            }
        }

        private BuilderFuncReturn<T> _response;
        private FakeValidInputResponseAction() { }
        public T Response(string validInput) => _response.Invoke(validInput);

        public void AssertResponseInvokedWith(string expected) => _response.AssertValue(m => m.Should().Be(expected));
    }
}