using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.IO;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.IO
{
    [TestClass]
    public class FormattedValidInputTests
    {
        [TestMethod, TestCategory("unit")]
        public void ValidInput_ShouldReturnFormattedValidInput()
        {
            //Arrange

            FakeDelayedFormat fakeDelayedFormatReg = new FakeDelayedFormat.Builder().Value("regex").Build();
            FakeDelayedArrayFormat fakeDelayedArrayFormat = new FakeDelayedArrayFormat.Builder().Value(new[] { "sample", "blort" }).Build();
            FakeValidInputResponseAction<string> fakeValidInputResponseAction = new FakeValidInputResponseAction<string>.Builder().Build();
            FormattedValidInput<string> subject = new FormattedValidInput<string>(fakeDelayedFormatReg, fakeDelayedArrayFormat, fakeValidInputResponseAction);

            //Act
            IValidResponse<string> actual = subject.ValidInput();

            //Assert
            fakeDelayedArrayFormat.AssertValueInvoked();
            fakeDelayedFormatReg.AssertValueInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void AddPromptArg_ShouldAddToArgs()
        {
            //Arrange
            FakeDelayedFormat fakeDelayedFormatReg = new FakeDelayedFormat.Builder().Build();
            FakeDelayedArrayFormat fakeDelayedArrayFormat = new FakeDelayedArrayFormat.Builder().Add().Build();
            FakeValidInputResponseAction<string> fakeValidInputResponseAction = new FakeValidInputResponseAction<string>.Builder().Build();
            FormattedValidInput<string> subject = new FormattedValidInput<string>(fakeDelayedFormatReg, fakeDelayedArrayFormat, fakeValidInputResponseAction);

            //Act
            subject.AddPromptArg("val_here");

            //Assert
            fakeDelayedArrayFormat.AssertAddInvokedWith("val_here");
        }

        [TestMethod, TestCategory("unit")]
        public void AddPatternArg_ShouldAddToArgs()
        {
            //Arrange
            FakeDelayedFormat fakeDelayedFormatReg = new FakeDelayedFormat.Builder().Add().Build();
            FakeDelayedArrayFormat fakeDelayedArrayFormat = new FakeDelayedArrayFormat.Builder().Build();
            FakeValidInputResponseAction<string> fakeValidInputResponseAction = new FakeValidInputResponseAction<string>.Builder().Build();
            FormattedValidInput<string> subject = new FormattedValidInput<string>(fakeDelayedFormatReg, fakeDelayedArrayFormat, fakeValidInputResponseAction);

            //Act
            subject.AddPatternArg("val_here");

            //Assert
            fakeDelayedFormatReg.AssertAddInvokedWith("val_here");
        }
    }
}