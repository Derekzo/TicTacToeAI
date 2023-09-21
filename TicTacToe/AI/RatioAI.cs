using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game; 
using TicTacToe.Stats;

namespace TicTacToe.AI
{
    public class RatioAI : AIInterface
    {
        public GridStats[] Stats { get; set; }
        public Sign Sign { get; set; }

        public RatioAI(Sign sign)
        {
            Stats = StatsFileSystemManager.Stats;
            Sign = sign;
        }

        public int NextMove(Grid grid)
        {
            int iChosen = Array.FindIndex(grid.Values, v => v == Sign.Void), ratio = 0;

            for (int i = 0; i < grid.Values.Length; i++)
            {
                if (grid.Values[i] == Sign.Void)
                {
                    var nextMoveGrid = new Grid(grid);

                    var stats = Stats.First(f => f.Id == nextMoveGrid.GetId());

                    var nextMoveRatio = Sign == Sign.Circle ?
                        (stats.CircleWinningSuccession + 1) / (stats.CrossWinningSuccession + 1) :
                        (stats.CrossWinningSuccession + 1) / (stats.CircleWinningSuccession + 1);

                    if (nextMoveRatio > ratio)
                    {
                        ratio = nextMoveRatio;
                        iChosen = i;
                    }
                }
            }

            return iChosen;
        }
    }
}

