using System.ComponentModel;
using NUnit.Framework;
using RockPaperScissors;

namespace RockPaperScissorsTest
{
    [TestFixture]
    public class ProgramTest
    {
     
        [Test]
        public void WinTest()
        {
            // Arrange
            var rock = MoveSelection.Rock;
            var paper = MoveSelection.Paper;
            var scissors = MoveSelection.Scissors;

            // Act
            var draw1 = Program.GetOutcome(rock, scissors);
            var draw2 = Program.GetOutcome(paper, rock);
            var draw3 = Program.GetOutcome(scissors, paper);

            // Assert
            Assert.Positive(draw1);
            Assert.Positive(draw2);
            Assert.Positive(draw3);

        }

        [Test]
        public void LoseTest()
        {
            // Arrange
            var rock = MoveSelection.Rock;
            var paper = MoveSelection.Paper;
            var scissors = MoveSelection.Scissors;

            // Act
            var draw1 = Program.GetOutcome(rock, paper);
            var draw2 = Program.GetOutcome(paper, scissors);
            var draw3 = Program.GetOutcome(scissors, rock);

            // Assert
            Assert.Negative(draw1);
            Assert.Negative(draw2);
            Assert.Negative(draw3);

        }

        [Test]
        public void DrawTest()
        {
            // Arrange
            var rock = MoveSelection.Rock;
            var paper = MoveSelection.Paper;
            var scissors = MoveSelection.Scissors;

            // Act
            var draw1 = Program.GetOutcome(rock, rock);
            var draw2 = Program.GetOutcome(paper, paper);
            var draw3 = Program.GetOutcome(scissors, scissors);

            // Assert
            Assert.Zero(draw1);
            Assert.Zero(draw2);
            Assert.Zero(draw3);
        }

    }
}