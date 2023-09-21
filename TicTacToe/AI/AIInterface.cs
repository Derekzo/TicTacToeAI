using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;

namespace TicTacToe.AI
{
    public interface AIInterface
    {
        public int NextMove(Grid grid);
    }
}
