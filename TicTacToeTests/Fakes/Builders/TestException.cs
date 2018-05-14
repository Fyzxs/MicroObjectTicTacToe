using System;

namespace TicTacToeTests.Fakes.Builders
{
    public class TestException : Exception
    {
        private readonly string _method;

        public TestException(string method) => _method = method;

        public override string Message => $"If you want to use {_method}, configure via Builder.";
    }
}