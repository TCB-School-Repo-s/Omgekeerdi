using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversiii
{
    internal class Spelbord : Panel
    {
        // TODO: Game logic
        int n;
        Color ColorOne;
        Color ColorTwo;
        int StonesPlayerOne;
        int StonesPlayerTwo;
        int[,] boardArray;

        int _playingPlayer = 1;
        int _opponent = 2;
        

        public Spelbord()
        {
            this.n = 6;
            this.ColorOne = Color.Black;
            this.ColorTwo = Color.White;
            this.boardArray = new int[n, n];
            this.Paint += DrawBoard;
            this.MouseClick += MuisClick;
            InitializeBoard();
        }

        [DefaultValue(6),
         Category("1 Game Settings"),
         Description("The size of the board")]
        public int BoardSize
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
                boardArray = new int[n, n];
                this.Invalidate();
                InitializeBoard();
            }
        }

        [Category("1 Game Settings"),
         Description("Changes stone color of player one")]
        public Color PlayerOneColor
        {
            get
            {
                return ColorOne;
            }
            set
            {
                ColorOne = value;
                this.Invalidate();
            }
        }

        [Category("1 Game Settings"),
         Description("Changes stone color of player two")]
        public Color PlayerTwoColor
        {
            get
            {
                return ColorTwo;
            }
            set
            {
                ColorTwo = value;
                this.Invalidate();
            }
        }

        public void InitializeBoard()
        {
            // set all elements to 0, which represents an empty field
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    boardArray[i, j] = 0;
                }
            }

            // set the initial stones on the board
            boardArray[n / 2 - 1, n / 2 - 1] = 1;
            boardArray[n / 2, n / 2] = 1;
            boardArray[n / 2 - 1, n / 2] = 2;
            boardArray[n / 2, n / 2 - 1] = 2;

            // set the initial stone counter
            this.StonesPlayerOne = 2;
            this.StonesPlayerTwo = 2;
        }

        public void resetGame()
        {
            boardArray = new int[n, n];
            InitializeBoard();
            this.Invalidate();
        }

        // Reversi game logic functions
        
        


        public void SwitchPlayers(int playingPlayer, int opponent)
        {
            _playingPlayer = opponent;
            _opponent = playingPlayer;
        }
        

        public void MuisClick(object sender, MouseEventArgs e)
        {
            // Get the board that was clicked on
            Spelbord board = (Spelbord)sender;

            // Calculate x and y coordinates of the click
            int x = 0 + (n - 0) * e.X / board.Width;
            int y = 0 + (n - 0) * e.Y / board.Height;

            // Print the coordinates to the console
            Debug.WriteLine($"X: {x} en Y: {y}");

            //makeMove(x, y, _playingPlayer, _opponent);

            this.Invalidate();
        }

        public void changeSelectedPlace(int x, int y, int player)
        {
            // TODO: Draw player on selected space
        }

        public void DrawBoard(object? sender, PaintEventArgs e)
        {
            Spelbord? board = (Spelbord?)sender;

            // Draw 6 x 6 grid using panel1 size
            float x = board.Width / (float)n;
            float y = board.Height / (float)n;
            Debug.WriteLine($"X: {x} en Y: {y}");
            Pen pen = new Pen(Color.Black, 2.5f);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    e.Graphics.DrawRectangle(pen, i * x, j * y, x, y);
                }
            }
            // draw black circle if bord[n,n] is 1 and draw white circle if bord[n,n] is 2
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (boardArray[i, j] == 1)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(ColorOne), i * x + 5, j * y + 5, x - 10, y - 10);
                    }
                    else if (boardArray[i, j] == 2)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(ColorTwo), i * x + 5, j * y + 5, x - 10, y - 10);
                    }
                }
            }
        }

        //Quality of life functions :D
        public int[,] getBoardPosition() // gets a board position's player stone value
        {
            return boardArray;
        }
        
        public int getPlayerOneScore() //returns amount of Player One stones
        {
            return StonesPlayerOne;
        }

        public int getPlayerTwoScore() // returns amount of player two stones
        {
            return StonesPlayerTwo;
        }

        private void setPlayerScore(int player, int amount) // sets player scores
        {
            if (player == 1) StonesPlayerOne += amount;
            else StonesPlayerTwo += amount;
        }

    }
}
