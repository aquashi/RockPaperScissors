using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Human : IPlayer
    {
        public int Input { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public MoveSelection SelectMove()
        {
            var output = (MoveSelection) Input;
            Console.WriteLine($"{Name} selected:{output}");
            return output;
        }

        public Human(string name)
        {
            Score = 0;
            Name = name;
        }
    }
}
