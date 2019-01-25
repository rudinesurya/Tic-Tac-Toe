using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    

    public abstract class AIPlayer
    {
        protected int maxRow;
        protected int maxCol;
        protected Mark[,] board;

        protected Mark aiMark;
        protected Mark playerMark;

        public AIPlayer(Mark[,] board, Mark aiMark)
        {
            this.board = board;
            this.aiMark = aiMark;
            if (this.aiMark == Mark.O)
                this.playerMark = Mark.X;
            else
                this.playerMark = Mark.O;

            maxRow = this.board.GetLength(0);
            maxCol = this.board.GetLength(1);
        }
        
    }
}
