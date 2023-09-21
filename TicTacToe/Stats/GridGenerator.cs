using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;

namespace TicTacToe.Stats
{
    public class GridGenerator
    {
        public List<Grid> Grids { get; set; } = new List<Grid>();

        public Grid[] WinningGrids => Grids.Where(w => w.HasWinner()).ToArray();

        public void Generate()
        {
            var start = new Grid();

            Grids.Add(start);

            GenerateInternal(start);

            CountWin();

            MiniMaxCount();

            StatsFileSystemManager.Write(
                Grids.Select(s => s.Stats).ToArray());
        }

        public void GenerateInternal(Grid start)
        {
            var nextSign = start.NextMoveSign();

            for (int i = 0; i < start.Values.Length; i++)
            {
                if (start.Values[i] != Sign.Void)
                {
                    continue;
                }

                var clone = new Grid(start).PutSignAt(i);
                 
                int cloneId = clone.GetId();

                if(cloneId == 9396)
                {
                    int x = 12;
                }    

                var cloneInMemory = Grids.FirstOrDefault(a => a.Stats.Id == cloneId);

                if (cloneInMemory == null)
                {
                    clone.Stats.Id = cloneId;
                    clone.Ancestors.Add(start.Stats.Id);

                    Grids.Add(clone);

                    if (!clone.HasWinner())
                    {
                        GenerateInternal(clone);
                    }
                }
                else
                {
                    cloneInMemory.Ancestors.Add(start.Stats.Id);
                }
            }
        }

        public void CountWin()
        {
            foreach (var grid in WinningGrids)
            {
                var winner = grid.GetWinner();

                if (winner == Sign.Cross)
                {
                    grid.Stats.CrossWinningSuccession = 1;
                }
                else
                {
                    grid.Stats.CircleWinningSuccession = 1;
                }

                CountWinInternal(grid.Ancestors, winner);
            }
        }

        private void CountWinInternal(List<int> ancestors, Sign winner)
        {
            var grids = ancestors.Select(s => Grids.First(f => f.GetId() == s)).ToArray();

            foreach (var grid in grids)
            {
                if (winner == Sign.Cross)
                {
                    grid.Stats.CrossWinningSuccession++;
                }
                else
                {
                    grid.Stats.CircleWinningSuccession++;
                }

                CountWinInternal(grid.Ancestors, winner);
            }
        }

        private void MiniMaxCount()
        { 
            foreach (var grid in WinningGrids)
            {
                grid.Stats.MinMaxScore = grid.GetWinner() == Sign.Cross ? 1 : -1;
            }

            foreach (var grid in WinningGrids)
            {
                AssignMiniMaxCountToAncestors(grid); 
            }
        }

        private void AssignMiniMaxCountToAncestors(Grid grid)
        {
            if(grid.GetId() == 9450)
            {
                int x = 12;
            }

            foreach (var ancestor in grid.Ancestors)
            {
                var ancestorGrid = Grids.First(f => f.Stats.Id == ancestor);

                ancestorGrid.Stats.MinMaxScore = ancestorGrid.NextMoveSign() == Sign.Cross ?
                    Math.Max(grid.Stats.MinMaxScore, ancestorGrid.Stats.MinMaxScore) :
                    Math.Min(grid.Stats.MinMaxScore, ancestorGrid.Stats.MinMaxScore);

                AssignMiniMaxCountToAncestors(ancestorGrid);
            }
        }
    }
}
