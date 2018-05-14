using System.Collections.Generic;
using System.Linq;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;

// ReSharper disable StaticMemberInGenericType

namespace tictactoe.Library.Random
{
    public sealed class SingleReservoirSample<T> : ISingleReservoirSample<T> where T : class
    {
        private static readonly Int LowerBound = new IntOf(0);
        private readonly T _defaultValue;
        private readonly IEnumerable<T> _enumerable;
        private readonly IRandomBookEnd _randomBookEnd;

        public SingleReservoirSample(IEnumerable<T> enumerable, T defaultValue) : this(enumerable, defaultValue, new RandomBookEnd()) { }

        public SingleReservoirSample(IEnumerable<T> enumerable, T defaultValue, IRandomBookEnd randomBookEnd)
        {
            _enumerable = enumerable;
            _defaultValue = defaultValue;
            _randomBookEnd = randomBookEnd;
        }

        public T Element() => NotChampionable()
            ? _defaultValue
            : Champion();

        private T Champion()
        {
            Int challengers = LowerBound;
            T champion = _enumerable.FirstOrDefault();
            foreach (T challenger in _enumerable)
            {
                challengers = challengers.Incremented();
                champion = ChallengeAccepted(challengers, champion, challenger);
            }

            return champion;
        }
        private T ChallengeAccepted(Int count, T champion, T challenger) =>
            NewChampion(count)
                ? challenger
                : champion;
        private Bool NotChampionable() => new IsCollectionEmpty<T>(_enumerable);
        private Bool NewChampion(Int challengerCount) => _randomBookEnd.NextInt(LowerBound, challengerCount).Equal(LowerBound);
    }

    public interface ISingleReservoirSample<out T>
    {
        T Element();
    }
}