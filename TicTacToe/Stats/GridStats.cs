using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Stats
{
    public class GridStats
    {
        public int Id { get; set; }
        public int CrossWinningSuccession { get; set; }
        public int CircleWinningSuccession { get; set; }

        public int MinMaxScore { get; set; } = 0;
    }
}
