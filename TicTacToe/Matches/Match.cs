using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.AI;
using TicTacToe.Game; 

namespace TicTacToe.Matches
{
    public class Match
    {
        public AIInterface CrossPlayer { get; set; }
        public AIInterface CirclePlayer { get; set; }

        public Grid Grid { get; set; } = new Grid();
         
        public Match(AIInterface crossPlayer, AIInterface circlePlayer, bool firstRandomMove = false)
        {
            CrossPlayer = crossPlayer;
            CirclePlayer = circlePlayer;

            if (firstRandomMove)
            {
                int rnd = new Random().Next(0, 9);

                Grid.Values[rnd] = Sign.Cross; 
            }
        }

        public Sign Play()
        {
            Grid.Print();

            while (!Grid.HasWinner() && Grid.EmptyPlaces > 0)
            {
                var sign = Grid.NextMoveSign();

                var player = sign == Sign.Cross ? CrossPlayer : CirclePlayer;

                Grid.Values[player.NextMove(Grid)] = sign;
                 
                Grid.Print(); 
            }

            return Grid.GetWinner();
        }
    }
}
