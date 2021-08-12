using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class RandomComputer : IPlayer
    {
        private static readonly Random Rng = new();
        public int Score { get; set; }
        public int Input { get; set; }
        public string Name { get; set; }

        public MoveSelection SelectMove()
        {
            var enums = Enum.GetValues(typeof(MoveSelection));
            Input = Rng.Next(enums.Length);
            var output = (MoveSelection)enums.GetValue(Input);
            Console.WriteLine($"{Name} selected: {output}");
            return output;
        }

        public RandomComputer(string name)
        {
            Score = 0;
            Name = name;
        }
    }
}
