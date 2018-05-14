using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.IO;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.IO
{
    [TestClass]
    public class ValidInputTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldRunRepeatedlyForValidInput()
        {
            //Arrange
            FakeRegexBookEnd fakeRegexBookEnd = new FakeRegexBookEnd.Builder().IsMatch(Bool.False, Bool.False, Bool.True).Build();
            FakeWriter fakeWriter = new FakeWriter();
            FakeReader fakeReader = new FakeReader("A", "B", "C");
            FakeValidInputResponseAction<string> fakeValidInputResponseAction = new FakeValidInputResponseAction<string>.Builder().Response("C").Build();
            ValidResponse<string> subject = new ValidResponse<string>(fakeRegexBookEnd, new[] { "", "", "" }, fakeValidInputResponseAction, fakeWriter, fakeReader);

            //Act
            string input = subject.Response();

            //Assert
            fakeValidInputResponseAction.AssertResponseInvokedWith("C");
            fakeRegexBookEnd.AssertIsMatchInvokedCountMatches(3);
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldRunFirstValidInput()
        {
            //Arrange
            FakeRegexBookEnd fakeRegexBookEnd = new FakeRegexBookEnd.Builder().IsMatch(Bool.True).Build();
            FakeWriter fakeWriter = new FakeWriter();
            FakeReader fakeReader = new FakeReader("A", "B", "C");
            FakeValidInputResponseAction<string> fakeValidInputResponseAction = new FakeValidInputResponseAction<string>.Builder().Response("A").Build();
            ValidResponse<string> subject = new ValidResponse<string>(fakeRegexBookEnd, new[] { "", "", "" }, fakeValidInputResponseAction, fakeWriter, fakeReader);

            //Act
            string input = subject.Response();

            //Assert
            fakeRegexBookEnd.AssertIsMatchInvokedCountMatches(1);
            fakeValidInputResponseAction.AssertResponseInvokedWith("A");
        }
    }
}
