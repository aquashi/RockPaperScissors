using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RockPaperScissors;

namespace RockPaperScissorsTest
{
    public class RandomComputerTest
    {

        [Test]
        public void SingleMoveTest()
        {
            // Arrange
            var randomComputer = new RandomComputer("test");

            //Act
            var move = randomComputer.SelectMove();
            
            //Assert
            Assert.IsInstanceOf<MoveSelection>(move);

        }

        [Test]
        public void RandomMoveTest()
        {
            // Arrange
            var randomComputer = new RandomComputer("test");

            //Act
            
            var moveList = new List<MoveSelection>()
            {
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove(),
                randomComputer.SelectMove()
            };
            
            //Assert
            Assert.Greater(moveList.Distinct().Count(), 1);
        }
    }
}