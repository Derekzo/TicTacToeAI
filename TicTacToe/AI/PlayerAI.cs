using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;

namespace TicTacToe.AI
{
    //I find the name of the class ironic enough
    public class PlayerAI : AIInterface
    {
        public int NextMove(Grid grid)
        {
            int indexChosen = -1;

            while (indexChosen < 0 || indexChosen > 9 || grid.Values[indexChosen - 1] != Sign.Void)
            {
                Console.WriteLine();
                Console.WriteLine("Insert index from 1 to 9:");

                string answer = Console.ReadLine();

                Int32.TryParse(answer, out indexChosen);
            }

            return indexChosen - 1;
        }
    }
}
