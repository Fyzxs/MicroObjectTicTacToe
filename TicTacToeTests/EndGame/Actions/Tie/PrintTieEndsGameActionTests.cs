using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame;
using tictactoe.EndGame.Actions.Tie;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.EndGame.Actions.Tie
{
    [TestClass]
    public class PrintTieEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldPrintWhenTieAndInvokeNext()
        {
            //Arrange
            Bool expected = Bool.True;
            FakePrinter fakePrinter = new FakePrinter.Builder().Print().Build();
            FakeTieEndsGameAction fakeTieEndsGameAction = new FakeTieEndsGameAction.Builder().Act(expected).Build();
            PrintTieEndsGameAction subject = new PrintTieEndsGameAction(fakeTieEndsGameAction, fakePrinter);

            //Act
            Bool actual = subject.Act(expected);

            //Assert
            actual.Should().NotBeNull();
            fakePrinter.AssertPrintInvoked();
            fakeTieEndsGameAction.AssertActInvoked();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldNotPrintWhenNotTieAndInvokeNext()
        {
            //Arrange
            Bool expected = Bool.False;
            FakePrinter fakePrinter = new FakePrinter.Builder().Build();
            FakeTieEndsGameAction fakeTieEndsGameAction = new FakeTieEndsGameAction.Builder().Act(expected).Build();
            PrintTieEndsGameAction subject = new PrintTieEndsGameAction(fakeTieEndsGameAction, fakePrinter);

            //Act
            Bool actual = subject.Act(expected);

            //Assert
            actual.Should().NotBeNull();
            fakeTieEndsGameAction.AssertActInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldValidateDependencyConstructors()
        {
            new ClassVariableTypeValidation()
                .Add<CatsGamePrinter>("_printer")
                .AssertExpectedVariables(new PrintTieEndsGameAction(null));
        }
    }
}