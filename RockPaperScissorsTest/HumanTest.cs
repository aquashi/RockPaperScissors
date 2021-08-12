using NUnit.Framework;
using RockPaperScissors;

namespace RockPaperScissorsTest
{
    [TestFixture]
    public class HumanTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MatchMoveTest()
        {
            // Arrange
            var human = new Human("test")
            {
                Input = 1
            };

            //Act
            var move = human.SelectMove();

            //Assert
            Assert.AreEqual(MoveSelection.Paper, move);
        }

        [Test]
        public void MismatchMoveTest()
        {
            // Arrange
            var human = new Human("test")
            {
                Input = 0
            };

            //Act
            var move = human.SelectMove();

            //Assert
            Assert.AreNotEqual(MoveSelection.Paper, move);
            Assert.AreNotEqual(MoveSelection.Scissors, move);

        }
    }
}