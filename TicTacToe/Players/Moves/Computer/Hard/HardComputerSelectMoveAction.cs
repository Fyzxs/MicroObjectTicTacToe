using System.Collections.Generic;
using System.Linq;
using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;

namespace tictactoe.Players.Moves.Computer.Hard
{
    public sealed class HardComputerSelectMoveAction : ISelectMoveAction
    {
        private static readonly Int DrawScore = new IntOf(0);
        private static readonly Int OpponentWinScore = new IntOf(-10);
        private static readonly Int PlayerWinScore = new IntOf(10);

        public ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer)
        {
            List<Int> scores = new List<Int>();
            List<ICell> cells = new List<ICell>();
            foreach (ICell cell in board.AvailableSpaces())
            {
                IBoard clone = board.Clone();
                clone.ClaimEndsGame(cell, thisPlayer);
                scores.Add(MinMaxRecursion(clone, otherPlayer, thisPlayer, Bool.False));
                cells.Add(cell);
            }

            return cells[ChampionIndex(scores)];
        }
        private int ChampionIndex(IEnumerable<Int> scores)
        {
            return scores
                .Select((value, index) => new { Value = value, Index = index })
                .Aggregate((a, b) => a.Value > b.Value ? a : b)
                .Index;
        }

        private Int MinMaxRecursion(IBoard board, IPlayer activePlayer, IPlayer passivePlayer, Bool activePlayerTurn)
        {
            if (board.GameState().IsGameOver()) return Score(board, activePlayerTurn);

            return ChampionScore(activePlayerTurn, Scores(board, activePlayer, passivePlayer, activePlayerTurn));
        }

        private Int ChampionScore(Bool activePlayerTurn, IEnumerable<Int> scores) => new IntOf(activePlayerTurn ? scores.Max(x => (int)x) : scores.Min(x => (int)x));

        private IEnumerable<Int> Scores(IBoard board, IPlayer activePlayer, IPlayer passivePlayer, Bool activePlayerTurn)
        {
            IList<Int> scores = new List<Int>();
            foreach (ICell cell in board.AvailableSpaces())
            {
                IBoard clone = board.Clone();
                clone.ClaimEndsGame(cell, activePlayer);
                scores.Add(MinMaxRecursion(clone, passivePlayer, activePlayer, activePlayerTurn.Not()));
            }

            return scores;
        }

        private Int Score(IBoard board, Bool opponentScore)
        {
            if (board.GameState().HasWinner()) return opponentScore ? OpponentWinScore : PlayerWinScore;
            return DrawScore;
        }
    }
}