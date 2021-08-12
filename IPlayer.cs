using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public interface IPlayer
    {
        public int Score { get; set; }
        public int Input { get; set; }
        public string Name { get; set; }
        public MoveSelection SelectMove();
    }
}
