using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Bools;
using tictactoe.Players;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players {
    [TestClass]
    public class PlayerTurnEndsGameTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldExecuteCommand()
        {
            //Arrange
            FakePlayerEndsGameAction fakePlayerEndsGameAction = new FakePlayerEndsGameAction.Builder().Act(Bool.True).Build();
            PlayerTurnEndsGame subject = new PlayerTurnEndsGame(null, null, null, fakePlayerEndsGameAction);

            //Act
            bool actual = subject;

            //Assert
            fakePlayerEndsGameAction.AssertActInvoked();
        }
    }
}