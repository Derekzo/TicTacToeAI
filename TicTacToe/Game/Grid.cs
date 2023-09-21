using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Stats;

namespace TicTacToe.Game
{
    public class Grid
    {
        public Sign[] Values { get; set; } = new Sign[]
        {
            Sign.Void, Sign.Void, Sign.Void,
            Sign.Void, Sign.Void, Sign.Void,
            Sign.Void, Sign.Void, Sign.Void,
        };

        public GridStats Stats { get; set; } = new GridStats();

        public List<int> Ancestors { get; set; } = new List<int>();

        public Grid() { }
        public Grid(Grid seed)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = seed.Values[i];
            }
        }

        public Sign GetWinner()
        {
            //Horizontal
            if (Values[0] == Values[1] && Values[1] == Values[2] && Values[0] != Sign.Void)
                return Values[0];

            if (Values[3] == Values[4] && Values[4] == Values[5] && Values[3] != Sign.Void)
                return Values[3];

            if (Values[6] == Values[7] && Values[7] == Values[8] && Values[6] != Sign.Void)
                return Values[6];

            //Vertical
            if (Values[0] == Values[3] && Values[3] == Values[6] && Values[0] != Sign.Void)
                return Values[0];

            if (Values[1] == Values[4] && Values[4] == Values[7] && Values[1] != Sign.Void)
                return Values[1];

            if (Values[2] == Values[5] && Values[5] == Values[8] && Values[2] != Sign.Void)
                return Values[2];

            //Diagonal

            if (Values[0] == Values[4] && Values[4] == Values[8] && Values[0] != Sign.Void)
                return Values[0];

            if (Values[2] == Values[4] && Values[4] == Values[6] && Values[2] != Sign.Void)
                return Values[2];

            return Sign.Void;
        }

        public bool HasWinner()
        {
            return GetWinner() != Sign.Void;
        }

        public int Turn
            => 1 + Values.Count(c => c != Sign.Void);

        public static Sign NextMoveSign(int turn)
            => turn % 2 == 0 ? Sign.Circle : Sign.Cross;

        public Sign NextMoveSign()
            => NextMoveSign(Turn);

        public int GetId()
        {
            int result = 0;

            for (int i = 0; i < Values.Length; i++)
            {
                result = result * 3 + (int)Values[i];
            }

            return result;
        }

        public Grid PutSignAt(int i) 
        {
            Values[i] = NextMoveSign();

            return this;
        }

        public string PrintableValue(int i)
        {
            return Values[i] == Sign.Cross ? "X" :
                   Values[i] == Sign.Circle ? "O" : " ";
        }

        public void Print()
        {
            Console.WriteLine($"{PrintableValue(0)} | {PrintableValue(1)} | {PrintableValue(2)}");
            Console.WriteLine($"{PrintableValue(3)} | {PrintableValue(4)} | {PrintableValue(5)}");
            Console.WriteLine($"{PrintableValue(6)} | {PrintableValue(7)} | {PrintableValue(8)}");
            Console.WriteLine();
        }

        public int EmptyPlaces => Values.Count(c => c == Sign.Void);
    }
}
