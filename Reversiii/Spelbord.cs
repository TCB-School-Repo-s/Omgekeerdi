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

        //Game logic functions

        //Check legality of a move
        public bool checkIfLegal(int x, int y, int playingPlayer, int opponent)
        {
            bool legal = false;

            //Check if the field is empty
            if (boardArray[x, y] == 0)
            {
                //Check if the field is surrounded by stones of the opponent
                if (boardArray[x + 1, y] == opponent || boardArray[x - 1, y] == opponent || boardArray[x, y + 1] == opponent || boardArray[x, y - 1] == opponent)
                {
                    legal = true;
                }
            }
            return legal;
        }

        //Check if a move encloses any stones
        public void checkIfEncloses(int x, int y, int playingPlayer, int opponent)
        {
            //Check if the field is surrounded by stones of the opponent
            if (boardArray[x + 1, y] == opponent || boardArray[x - 1, y] == opponent || boardArray[x, y + 1] == opponent || boardArray[x, y - 1] == opponent)
            {
                //Check if the field is surrounded by stones of the player
                if (boardArray[x + 1, y] == playingPlayer || boardArray[x - 1, y] == playingPlayer || boardArray[x, y + 1] == playingPlayer || boardArray[x, y - 1] == playingPlayer)
                {
                    //Enclose all stones of the opponent
                    //encloseStones(x, y, playingPlayer, opponent);
                }
                
            }
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

            // Get the playing player
            int playingPlayer = 1;
            int opponent = 2;

            if(checkIfLegal(x, y, playingPlayer, opponent))
            {
                boardArray[x, y] = 1;
            }

            this.Invalidate();

            // Check if the move encloses any stones
            //checkIfEncloses(x, y, playingPlayer, opponent);
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
        public int[,] getBoardPosition()
        {
            return boardArray;
        }
        
        public int getPlayerOneScore()
        {
            return StonesPlayerOne;
        }

        public int getPlayerTwoScore()
        {
            return StonesPlayerTwo;
        }

        private void setPlayerSCore(int player, int amount)
        {
            if (player == 1) StonesPlayerOne += amount;
            else StonesPlayerTwo += amount;
        }

    }
}
