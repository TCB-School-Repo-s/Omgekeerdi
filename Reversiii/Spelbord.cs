using System;
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
     * TODO: If one direction provides and illegal move, it doesn't continue to check if the other directions have legal moves.
     */

    public bool FindEnclosure(int i, int j, int di, int dj, bool play = false, bool first = true)
    {
        // Function that finds enclosed stones, and plays the stones if play is true
        if (i == 0 || j == 0 || i == n - 1 || j == n - 1)
        {
            return false;
        }
        if (boardArray[i, j] == 0)
        {
            return false;
        }
        if (boardArray[i, j] == _playingPlayer)
        {
            return true;
        }
        if (FindEnclosure(i + di, j + dj, di, dj, play, false))
        {
            if (play)
            {
                boardArray[i, j] = _playingPlayer;
                if (_playingPlayer == 1)
                {
                    StonesPlayerOne++;
                    StonesPlayerTwo--;
                }
                else
                {
                    StonesPlayerOne--;
                    StonesPlayerTwo++;
                }
            }
            return true;
        }
        return false;
    }

    //Function that checks if move is legal
    public bool CheckMove(int i, int j)
    {
        if (boardArray[i, j] != 0)
        {
            return false;
        }
        if (FindEnclosure(i - 1, j - 1, -1, -1))
        {
            return true;
        }
        if (FindEnclosure(i - 1, j, -1, 0))
        {
            return true;
        }
        if (FindEnclosure(i - 1, j + 1, -1, 1))
        {
            return true;
        }
        if (FindEnclosure(i, j - 1, 0, -1))
        {
            return true;
        }
        if (FindEnclosure(i, j + 1, 0, 1))
        {
            return true;
        }
        if (FindEnclosure(i + 1, j - 1, 1, -1))
        {
            return true;
        }
        if (FindEnclosure(i + 1, j, 1, 0))
        {
            return true;
        }
        if (FindEnclosure(i + 1, j + 1, 1, 1))
        {
            return true;
        }
        return false;
    }

    public void PlayStones(int p, int q, int ddx, int ddy)
    {
        if (boardArray[p,q] != _playingPlayer)
        {
            boardArray[p, q] = _playingPlayer;
            PlayStones(p + ddx, q + ddy, ddx, ddy);
        }
    }

    public void Play(int x, int y)
    {
        for (int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                if (!(i == 0 && j == 0)) FindEnclosure(x + i, y + j, i, j, true);
            }
        }
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
        int x = n * e.X / board.Width;
        int y = n * e.Y / board.Height;

        Debug.WriteLine($"board.Width: {board.Width} en board.Height: {board.Height}");
        Debug.WriteLine($"e.X: {e.X} en e.Y: {e.Y}");
        Debug.WriteLine($"X: {x} en Y: {y}");

        if (CheckMove(x, y))
        {
            boardArray[x, y] = _playingPlayer;
            Play(x, y);
            SwitchPlayers(_playingPlayer, _opponent);
            this.Invalidate();
        }
        else
        {
            MessageBox.Show("De move die wil is niet legaal", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

}
