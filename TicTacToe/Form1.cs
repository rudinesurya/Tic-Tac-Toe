using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public enum Mark
    {
        B,
        X,
        O
    }

    public partial class Form1 : Form
    {
        bool playerTurn = true; //true = X, false = O
        BruteForceAI ai;
        Mark[,] board;
        Button[,] buttons;

        public Form1()
        {
            InitializeComponent();
            
            buttons = new Button[3, 3];
            buttons[0, 0] = btn00;
            buttons[0, 1] = btn01;
            buttons[0, 2] = btn02;
            buttons[1, 0] = btn10;
            buttons[1, 1] = btn11;
            buttons[1, 2] = btn12;
            buttons[2, 0] = btn20;
            buttons[2, 1] = btn21;
            buttons[2, 2] = btn22;

            board = new Mark[3, 3];
        }

        void UpdateBoard()
        {
            for (int r = 0; r < 3; ++r)
            {
                for (int c = 0; c < 3; ++c)
                {
                    if (buttons[r, c].Text == "X")
                        board[r, c] = Mark.X;
                    else if (buttons[r, c].Text == "O")
                        board[r, c] = Mark.O;
                    else
                        board[r, c] = Mark.B;
                }
            }
        }

        public void GetAIMove()
        {
            ai = new BruteForceAI(board, Mark.O);

            KeyValuePair<int,int> move = ai.GetMove();
            AIMakeMove(move.Key, move.Value);
        }

        Button GetButton(int r, int c)
        {
            return buttons[r, c];
        }

        void DisableAllButtons()
        {
            for (int r = 0; r < 3; ++r)
            {
                for (int c = 0; c < 3; ++c)
                {
                    buttons[r, c].Enabled = false;
                }
            }
        }

        void AIMakeMove(int r, int c)
        {
            buttons[r, c].Text = "O";

            UpdateBoard();
            if (CheckWin(ref board))
            {
                DisableAllButtons();
            }
            else
            {
                playerTurn = !playerTurn;
                buttons[r, c].Enabled = false;
            }
        }

        private void BtnOnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (playerTurn)
                btn.Text = "X";
            else
                return;
            

            UpdateBoard();
            if (CheckWin(ref board))
            {
                DisableAllButtons();
            }
            else
            {
                playerTurn = !playerTurn;
                btn.Enabled = false;

                GetAIMove();
            }
        }

        public static bool CheckWin(ref Mark[,] board)
        {
            Mark winner = Mark.B;

            //horizontal
            for (int r = 0; r < 3; ++r)
            {
                if (board[r, 0] == board[r, 1] && board[r, 1] == board[r, 2] && board[r, 0] != Mark.B)
                {
                    winner = board[r, 0];
                    break;
                }
            }

            //vertical
            for (int c = 0; c < 3; ++c)
            {
                if (board[0, c] == board[1, c] && board[1, c] == board[2, c] && board[0, c] != Mark.B)
                {
                    winner = board[0, c];
                    break;
                }
            }

            //diagonal
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != Mark.B)
            {
                winner = board[0, 0];
            }

            if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[0, 0] != Mark.B)
            {
                winner = board[2, 0];
            }

            if (winner != Mark.B)
            {
                MessageBox.Show(winner.ToString() + " wins !");
                return true; //Game Over
            }
            else
                return false;
        }

        void RestartBoard()
        {
            for (int r = 0; r < 3; ++r)
            {
                for (int c = 0; c < 3; ++c)
                {
                    buttons[r, c].Enabled = true;
                    buttons[r, c].Text = "";
                }
            }

            UpdateBoard();
        }

        private void NewGame_P1(object sender, EventArgs e)
        {
            RestartBoard();
            playerTurn = true;
        }

        private void NewGame_AI(object sender, EventArgs e)
        {
            RestartBoard();
            playerTurn = false;
        }
    }
}
