using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode.TurnOrder;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.GameMode.TurnOrder {
    [TestClass]
    public class HumanFirstPlayerTurnTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnHumanFirstOrderGivenMatchingInput()
        {
            //Arrange
            FakePlayerTurnsOrderAction fakePlayerTurnsOrderAction = new FakePlayerTurnsOrderAction.Builder().Build();
            HumanFirstPlayerTurn subject = new HumanFirstPlayerTurn(fakePlayerTurnsOrderAction);

            //Act
            IPlayerOrder actual = subject.Response("1");

            //Assert
            actual.Should().BeOfType<HumanFirstOrder>();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnInvokeNextGivenNotHandled()
        {
            //Arrange
            FakePlayerOrder fakePlayerOrder = new FakePlayerOrder.Builder().Build();
            FakePlayerTurnsOrderAction fakePlayerTurnsOrderAction = new FakePlayerTurnsOrderAction.Builder().Response(fakePlayerOrder).Build();
            HumanFirstPlayerTurn subject = new HumanFirstPlayerTurn(fakePlayerTurnsOrderAction);

            //Act
            IPlayerOrder actual = subject.Response("2");

            //Assert
            actual.Should().Be(fakePlayerOrder);
        }
    }
}