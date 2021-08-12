using System;

namespace RockPaperScissors
{
    public class Program
    {
        private const int MaxWins = 2;
        public static IPlayer Player1 { get; private set; }
        public static IPlayer Player2 { get; private set; }

        /// <summary>
        /// The <code>MaxWins</code> constant is used
        /// to determine possible maximum rounds needed.
        /// IPlayer objects are assigned.
        /// </summary>
        private static void BeginGame()
        {
            Console.WriteLine("Welcome to Rock Paper Scissors");
            Console.WriteLine($"Game is best of {2*MaxWins - 1} (Win {MaxWins} rounds)");
            Console.WriteLine("Game Start! \n");

            Player1 = new Human("Player1");
            Player2 = new RandomComputer("Player2(CPU)");
        }

        /// <summary>
        /// Shows current score and then calls <code>UpdateInput()</code> method.
        /// </summary>
        private static void AskForInput()
        {
            Console.WriteLine($"Current Scores: {Player1.Name} - {Player1.Score}, {Player2.Name} - {Player2.Score}");
            UpdateInput(Player1);
            UpdateInput(Player2);
        }

        /// <summary>
        /// Displays text on screen to prompt for input.
        /// </summary>
        /// <param name="player"></param>
        private static void UpdateInput(IPlayer player)
        {
            if (player.GetType() == typeof(RandomComputer))
            {
                Console.WriteLine($"{player.Name} has made random move");
            }
            else
            {
                Console.WriteLine($"{player.Name}, please select a move using number:");
                Console.WriteLine("0 - Rock");
                Console.WriteLine("1 - Paper");
                Console.WriteLine("2 - Scissors");
                var input = Console.ReadKey(true);
                var selection = input.KeyChar;
                CheckInput(player, selection);
            }
        }

        /// <summary>
        /// Checks if selection is within valid range and updates Input property of player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="selection"></param>
        private static void CheckInput(IPlayer player, char selection)
        {
            try
            {
                var num = Convert.ToInt32(selection);
                if (num is >= 0 and <= 2)
                {
                    player.Input = num;
                    Console.WriteLine($"{player.Name} has made move");
                }
                else
                {
                    Console.WriteLine("Detected invalid input \n");
                    UpdateInput(player);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Detected invalid input \n {e}");
                UpdateInput(player);
            }
        }

        /// <summary>
        /// Invoke players move selections and display winner of the round.
        /// </summary>
        private static void CalculateScores()
        {
            var movePlayer1 = Player1.SelectMove();
            var movePlayer2 = Player2.SelectMove();
            var pointDiffPlayer1 = GetOutcome(movePlayer1, movePlayer2);
            if (pointDiffPlayer1 > 0)
            {
                Player1.Score += 1;
                Console.WriteLine($"{Player1.Name} Wins \n");
            }
            else if (pointDiffPlayer1 < 0)
            {
                Player2.Score += 1;
                Console.WriteLine($"{Player2.Name} Wins \n");
            }
            else
            {
                Console.WriteLine("Draw \n");
            }
        }

        /// <summary>
        /// Compares two moves to determine the winning move.
        /// </summary>
        /// <param name="moveA"></param>
        /// <param name="moveB"></param>
        /// <returns>An integer referring to whether or not first parameter is the winning move,
        /// +1 for win, -1 for loss and 0 for draw.</returns>
        public static int GetOutcome(MoveSelection moveA, MoveSelection moveB)
        {
            if (moveA == moveB)
            {
                return 0;
            }
            if (moveA == MoveSelection.Rock && moveB == MoveSelection.Scissors)
            {
                return 1;
            }
            if (moveA == MoveSelection.Scissors && moveB == MoveSelection.Rock)
            {
                return -1;
            }
            if ((int)moveA > (int)moveB)
            {
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// Checks and displays the overall winner, first to reach MaxWins constant
        /// </summary>
        private static void CheckWinner()
        {
            Console.WriteLine($"Final Score: {Player1.Name} - {Player1.Score}, " +
                              $"{Player2.Name} - {Player2.Score}");

            if (Player1.Score >= MaxWins)
            {
                Console.WriteLine($"{Player1.Name} Wins Overall");
            }
            if (Player2.Score >= MaxWins)
            {
                Console.WriteLine($"{Player2.Name} Wins Overall");
            }

        }


        public static void Main(string[] args)
        {
            BeginGame();

            while (Player1.Score < MaxWins && Player2.Score < MaxWins)
            {
                AskForInput();
                CalculateScores();
            }
            CheckWinner();
        }
    }
}
