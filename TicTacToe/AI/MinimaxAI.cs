using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;
using TicTacToe.Stats;

namespace TicTacToe.AI
{
    public class MinimaxAI : AIInterface
    {
        public GridStats[] Stats { get; set; }
        public Sign Sign { get; set; }

        public MinimaxAI(Sign sign)
        {
            Stats = StatsFileSystemManager.Stats;
            Sign = sign;
        }

        public int NextMove(Grid grid)
        { 
            int iChosen = Array.FindIndex(grid.Values, v => v == Sign.Void),
                score = Sign == Sign.Cross ? -1 : 1;

            for (int i = iChosen; i < grid.Values.Length; i++)
            {
                if (grid.Values[i] != Sign.Void)
                {
                    continue;
                }

                var nextMoveGrid = new Grid(grid).PutSignAt(i); 

                var stats = Stats.First(f => f.Id == nextMoveGrid.GetId());

                if (Sign == Sign.Cross && score < stats.MinMaxScore ||
                    Sign == Sign.Circle && score > stats.MinMaxScore)
                {
                    score = stats.MinMaxScore;
                    iChosen = i;
                }
            }

            return iChosen;
        }
    }
}
