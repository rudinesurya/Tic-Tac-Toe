using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class BruteForceAI : AIPlayer
    {
        public BruteForceAI(Mark[,] board, Mark aiMark) : base(board, aiMark)
        {
        }

        public KeyValuePair<int, int> GetMove()
        {
            KeyValuePair<int, int> move = new KeyValuePair<int, int>(1,1);



            return move;
        }

        //private int MiniMax(int depth, Mark player)
        //{

        //}

        //private int Evaluate()
        //{
        //    if (Form1.CheckWin(ref board))
        //        return 1;
        //    else 
        //}

        private List<KeyValuePair<int, int>> GenerateMoves()
        {
            List<KeyValuePair<int, int>> moves = new List<KeyValuePair<int, int>>();

            for (int r = 0; r < 3; ++r)
            {
                for (int c = 0; c < 3; ++c)
                {
                    if (board[r, c] == Mark.B)
                        moves.Add(new KeyValuePair<int, int>(r,c));
                }
            }

            return moves;
        }
    }
}
