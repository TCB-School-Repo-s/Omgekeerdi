using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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

        /*
         * This code checks if the move you're making is legal, 
         * and then returns an array with the first value containing if the move is valid,
         * and the second values represents the direction the stones should be flipped
         *
         * TODO: The code doesn't work when using the 6x6 board, why? No clue, it works on the all the sizes except 6x6
         */
        public Object[] LegalMove(int playerPlayer, int opponent, int x, int y)
        {
            Object[] array = new Object[] { false, null };

            if (boardArray[x, y] != 0)
            {
                array[0] = false;
            }
            else
            {
                foreach (Directions direction in Enum.GetValues(typeof(Directions)))
                {
                    if (GetDirectionalSpace(x, y, 1, direction) == opponent)
                    {
                        Debug.WriteLine("-----------------------------------");
                        Debug.WriteLine($"Space has opponent next to it, Instance UUID: {Guid.NewGuid().ToString()}");
                        Debug.WriteLine($"Direction checking: {direction.ToString()}");
                        array[1] = direction;
                        for (int j = 0; x + j < boardArray.GetLength(0) && y + j < boardArray.GetLength(1); j++)
                        {
                            Debug.WriteLine("i is within range");
                            DirectionSpace space = new DirectionSpace(x, y, j, direction, boardArray, n);
                            if (space.ReturnSpace() == playerPlayer)
                            {
                                Debug.WriteLine("Player found!");
                                array[0] = true;
                                break;
                            }
                            else
                            {
                                Debug.WriteLine("Player has not yet been found");
                            }
                        }
                        break;
                    }
                }
            }

            return array;
        }

        public void FlipStones(Directions direction, int playingPlayer, int opponent, int x, int y)
        {
            for (int j = 0; x + j < boardArray.GetLength(0) && y + j < boardArray.GetLength(1); j++)
            {
                DirectionSpace space = new DirectionSpace(x, y, j, direction, boardArray, n);
                if (space.ReturnSpace() == playingPlayer)
                {
                    break;
                }
                else
                {
                    boardArray[space.ReturnCoordinates().X, space.ReturnCoordinates().Y] = playingPlayer;
                }
            }
        }

        // Returns the value of the space in the array
        public int GetDirectionalSpace(int x, int y, int amount, Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                    if (y == 0) break;
                    return boardArray[x, y - amount];
                case Directions.Down:
                    if (y == n - 1) break;
                    return boardArray[x, y + amount];
                case Directions.UpLeft:
                    if (y == 0 || x == 0) break;
                    return boardArray[x - amount, y - amount];
                case Directions.UpRight:
                    if (y == 0 || x == n - 1) break;
                    return boardArray[x + amount, y - amount];
                case Directions.DownLeft:
                    if (y == n - 1 || x == 0) break;
                    return boardArray[x - amount, y + amount];
                case Directions.DownRight:
                    if (y == n - 1 || x == n - 1) break;
                    return boardArray[x + amount, y + amount];
                case Directions.Left:
                    if (x == 0) break;
                    return boardArray[x - amount, y];
                case Directions.Right:
                    if (x == n - 1) break;
                    return boardArray[x + amount, y];
            }
            return 0;
        }

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

            //makeMove(x, y, _playingPlayer, _opponent

            Object[] legalArray = LegalMove(_playingPlayer, _opponent, x, y);

            if ((bool)legalArray[0])
            {
                boardArray[x, y] = _playingPlayer;
                FlipStones((Directions)legalArray[1], _playingPlayer, _opponent, x, y);
                SwitchPlayers(_playingPlayer, _opponent);
            }
            else
            {
                MessageBox.Show("Illegal move");
            }

            this.Invalidate();
        }

        public void changeSelectedPlace(int x, int y, int player)
        {
            boardArray[x, y] = player;
        }

        public void DrawBoard(object? sender, PaintEventArgs e)
        {
            Spelbord? board = (Spelbord?)sender;

            // Draw 6 x 6 grid using panel1 size
            float x = board.Width / (float)n;
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

        public enum Directions
        {
            Up,
            Down,
            Left,
            Right,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
        }

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



    }

    internal class DirectionSpace
    {
        int x;
        int y;
        int n;
        int amount;
        int[,] array;
        Spelbord.Directions direction;
        //int opponent;

        public DirectionSpace(int x, int y, int amount, Spelbord.Directions direction, int[,] array, int n)
        {
            this.x = x;
            this.y = y;
            this.amount = amount;
            this.direction = direction;
            this.array = array;
            this.n = n;
        }

        public Point ReturnCoordinates()
        {
            int newX;
            int newY;
            switch (direction)
            {
                case Directions.Up:
                    if (y == 0) break;
                    newX = x;
                    newY = y - amount;
                    return new Point(newX, newY);
                case Directions.Down:
                    if (y == n - 1) break;
                    newX = x;
                    newY = y + amount;
                    return new Point(newX, newY);
                case Directions.UpLeft:
                    if (y == 0 || x == 0) break;
                    newX = x - amount;
                    newY = y - amount;
                    return new Point(newX, newY);
                case Directions.UpRight:
                    if (y == 0 || x == n - 1) break;
                    newX = x + amount;
                    newY = y - amount;
                    return new Point(newX, newY);
                case Directions.DownLeft:
                    if (y == n - 1 || x == 0) break;
                    newX = x - amount;
                    newY = y + amount;
                    return new Point(newX, newY);
                case Directions.DownRight:
                    if (y == n - 1 || x == n - 1) break;
                    newX = x + amount;
                    newY = y + amount;
                    return new Point(newX, newY);
                case Directions.Left:
                    if (x == 0) break;
                    newX = x - amount;
                    newY = y;
                    return new Point(newX, newY);
                case Directions.Right:
                    if (x == n - 1) break;
                    newX = x + amount;
                    newY = y;
                    return new Point(newX, newY);
            }
            return new Point(x, y);
        }

        public int ReturnSpace()
        {
            switch (direction)
            {
                case Directions.Up:
                    if (y == 0) break;
                    return array[x, y - amount];
                case Directions.Down:
                    if (y == n - 1) break;
                    return array[x, y + amount];
                case Directions.UpLeft:
                    if (y == 0 || x == 0) break;
                    return array[x - amount, y - amount];
                case Directions.UpRight:
                    if (y == 0 || x == n - 1) break;
                    return array[x + amount, y - amount];
                case Directions.DownLeft:
                    if (y == n - 1 || x == 0) break;
                    return array[x - amount, y + amount];
                case Directions.DownRight:
                    if (y == n - 1 || x == n - 1) break;
                    return array[x + amount, y + amount];
                case Directions.Left:
                    if (x == 0) break;
                    return array[x - amount, y];
                case Directions.Right:
                    if (x == n - 1) break;
                    return array[x + amount, y];
            }
            return 0;
        }


    }

}
