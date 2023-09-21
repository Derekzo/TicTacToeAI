using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.AI;
using TicTacToe.Game;
using TicTacToe.Matches;

namespace TicTacToe
{
    public class Menu
    {
        public static void Game()
        {
            while (true)
            {
                AskForMatch();
            }
        }

        public static void AskForMatch()
        {
            Console.WriteLine("Insert Player 1 (X) type:");
            int typePlayer1 = AskForPlayer();

            Console.WriteLine();
            Console.WriteLine("Insert Player 2 (O) type:");
            int typePlayer2 = AskForPlayer();

            bool firstRandomMove = false;

            if (typePlayer1 != 1)
            {
                Console.WriteLine();
                Console.WriteLine("Should first move be random? (Y/N)");
                firstRandomMove = AskForYN();
            }

            var match = new Match(
                OptionToPlayer(typePlayer1, Sign.Cross),
                OptionToPlayer(typePlayer2, Sign.Circle),
                firstRandomMove);

            Console.WriteLine();

            match.Play();
        }

        private static AIInterface OptionToPlayer(int typePlayer, Sign sign)
            => typePlayer == 1 ? new PlayerAI() :
               typePlayer == 2 ? new RatioAI(sign) :
                            new MinimaxAI(sign);

        private static int AskForPlayer()
        {
            Console.WriteLine("1 - Physical person");
            Console.WriteLine("2 - Ratio AI");
            Console.WriteLine("3 - MiniMax AI");
            Console.WriteLine();

            int answer = AskForPositiveInteger(3, zeroAllowed: false);

            return answer;
        }

        private static int AskForPositiveInteger(int? optionsNumber, bool zeroAllowed = false)
        {
            while (true)
            {
                string? option = Console.ReadLine();
                bool parseSuccess = int.TryParse(option, out int intOption);

                if (!parseSuccess)
                {
                    Console.WriteLine("Inserisci un valore numerico");
                    continue;
                }

                if (intOption <= 0 || (optionsNumber.HasValue && intOption > optionsNumber)
                    || (!zeroAllowed && intOption == 0))
                {
                    Console.WriteLine("Inserisci un valore disponibile");
                    continue;
                }

                return intOption;
            }
        }

        private static bool AskForYN()
        {
            while (true)
            {
                string? answer = Console.ReadLine().ToLower();

                if (answer != "y" && answer != "n")
                {
                    Console.WriteLine("Insert Y (y) or N (no)");
                    continue;
                }


                return answer == "y";
            }
        }

    }
}
