﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Reversiii.Spelbord;

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
        bool help = false;

        int _playingPlayer = 1;
        int _opponent = 2;

        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }


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
        
        public bool ShowHelp
        {
            get {
                return help;
            }
            set
            {
                help = value;
                this.Invalidate();
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

        public bool FindEnclosure(int i, int j, int di, int dj, bool currentlyPlaying = false, bool firstStone = true)
        {
            // Function that finds enclosed stones, and plays the stones if play is true
            if (i < 0 || j < 0 || i > n - 1 || j > n - 1)
            {
                return false; // If it is outside of the board, the move is false;
            }
            if (boardArray[i, j] == 0)
            {
                return false; // if place is empty, cannot enclose, so too bad not enclosed.
            }
            if (boardArray[i, j] == _playingPlayer)
            {
                if (firstStone) return false; // If the first stone it finds is the player, then the move is not valid
                return true; // else it succesfully encloses stone, so true
            }
            if (FindEnclosure(i + di, j + dj, di, dj, currentlyPlaying, false))
            {
                if (currentlyPlaying) // If we are currently playing, then it will change the stones
                {
                    PlayStones(i, j, di, dj);
                }
                return true;
            }
            return false;
        }
        

        //Function that checks if move is legal
        public bool CheckMove(int x, int y)
        {
            if (boardArray[x, y] != 0)
            {
                return false;
            }
            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j<= 1; j++)
                {
                    if(!(i == 0 && j == 0))
                    {
                        if (FindEnclosure(x + i, y+j, i, j, false, true)) // For every x and y in the same direction, it will check if there is an enclosure
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void PlayStones(int x, int y, int dx, int dy)
        {
            if (boardArray[x,y] != _playingPlayer)
            {
                boardArray[x, y] = _playingPlayer;
                PlayStones(x + dx, y + dy, dx, dy); // Changes stones
            }
        }

        public void Play(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 && j == 0)) FindEnclosure(x + i, y + j, i, j, true); // Finds enclosures and changes the stones
                }
            }
        }

        public void SwitchPlayers(int playingPlayer, int opponent, bool secondTry = false)
        {

            _playingPlayer = opponent;
            _opponent = playingPlayer;
            CountScores();
            // Check if there are any moves left, if not switch to other player, if that player has no moves either, then it's game over
            bool moveLeft = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (CheckMove(i, j))
                    {
                        moveLeft = true;
                        break;
                    }
                }
            }

            if(getPlayerOneScore() + getPlayerTwoScore() == n * n)
            {
                if (getPlayerOneScore() == getPlayerTwoScore())
                {
                    Win(playingPlayer, opponent, true);
                }
                else
                {
                    int winningPlayer = getPlayerOneScore() > getPlayerTwoScore() ? 1 : 2;
                    int losingPlayer = getPlayerOneScore() > getPlayerTwoScore() ? 2 : 1;
                    Win(winningPlayer, losingPlayer);
                }
                return;
            }
            
            if (!moveLeft)
            {
                if (secondTry)
                {
                    if(getPlayerOneScore() == getPlayerTwoScore())
                    {
                        Win(playingPlayer, opponent, true);
                    }
                    else
                    {
                        int winningPlayer = getPlayerOneScore() > getPlayerTwoScore() ? 1 : 2;
                        int losingPlayer = getPlayerOneScore() > getPlayerTwoScore() ? 2 : 1;
                        Win(winningPlayer, losingPlayer);
                    }
                    return;
                }
                MessageBox.Show("No moves left for player " + opponent + ", switching to player " + playingPlayer);
                SwitchPlayers(opponent, playingPlayer, true);
            }
            
        }

        public void Win(int winningPlayer, int losingPlayer, bool remise = false)
        {
            if (!remise)
            {
                if (winningPlayer == 1)
                    MessageBox.Show($"Speler {winningPlayer} - {PlayerOneName} heeft gewonnen!");
                else MessageBox.Show($"Speler {winningPlayer} - {PlayerTwoName} heeft gewonnen!");
            }
            else
            {
                MessageBox.Show($"Remise!");
            }
        }


        public void MuisClick(object sender, MouseEventArgs e)
        {
            // Get the board that was clicked on
            Spelbord board = (Spelbord)sender;

            // Calculate x and y coordinates of the click
            int x = n * e.X / board.Width;
            int y = n * e.Y / board.Height;

            if (CheckMove(x, y))
            {
                boardArray[x, y] = _playingPlayer; // Change place to playingplayer
                Play(x, y); // Play the moves
                SwitchPlayers(_playingPlayer, _opponent); this.Invalidate();
            }
            else
            {
                MessageBox.Show("I'm sorry, but that move is not legal! Perhaps try a hint?", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Invalidate();
        }

        public void DrawBoard(object? sender, PaintEventArgs e)
        {
            Spelbord? board = (Spelbord?)sender;

            // Draw 6 x 6 grid using panel1 size
            float x = board.Width / (float)n; // calculate width and height of boxes;
            float y = board.Height / (float)n;
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
                    if (this.ShowHelp) // If showcode is true, then it will check if a move is legal for every place in array, and if it is, it wil draw an ellipse
                    {
                        if (CheckMove(i, j))
                        {
                            e.Graphics.DrawEllipse(new Pen(Color.FromArgb(192, 10, 53), 5), i * x + 5, j * y + 5, x - 10, y - 10);
                        }
                    }
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

        public int[,] getBoard() // gets a board position's player stone value
        {
            return boardArray;
        }

        private void CountScores()
        {
            StonesPlayerOne = 0;
            StonesPlayerTwo = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (boardArray[i, j] == 1) StonesPlayerOne++; else if (boardArray[i, j] == 2) StonesPlayerTwo++;
                }
            }
            this.Invalidate();
        }

        public int getPlayingPlayer()
        {
            return _playingPlayer;
        }
        
        public int getPlayerOneScore() //returns amount of Player One stones
        {
            return StonesPlayerOne;
        }

        public int getPlayerTwoScore() // returns amount of player two stones
        {
            return StonesPlayerTwo;
        }



    }

}
