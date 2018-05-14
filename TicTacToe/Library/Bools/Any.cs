using System;
using System.Collections.Generic;
using System.Linq;

namespace tictactoe.Library.Bools
{
    public sealed class Any<T> : Bool
    {
        private readonly IEnumerable<T> _enumerable;
        private readonly Func<T, Bool> _func;

        public Any(IEnumerable<T> enumerable, Func<T, Bool> func)
        {
            _enumerable = enumerable;
            _func = func;
        }

        protected override bool RawValue() => _enumerable.Any(val => _func(val));
    }
}