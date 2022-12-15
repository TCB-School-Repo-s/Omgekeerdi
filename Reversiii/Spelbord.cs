using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversiii
{
    internal class Spelbord : Panel
    {

        int n;
        Color PlayerOneColor;
        Color PlayerTwoColor;
        int[,] boardArray;

        public Spelbord(int size, Color PlayerOneColor, Color PlayerTwoColor)
        {
            this.n = size;
            this.PlayerOneColor = PlayerOneColor;
            this.PlayerTwoColor = PlayerTwoColor;
            this.boardArray = new int[size, size];
            this.Paint += DrawBoard;
            this.MouseClick += MuisClick;
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    boardArray[i, j] = 0;
                }
            }
            boardArray[n / 2 - 1, n / 2 - 1] = 1;
            boardArray[n / 2, n / 2] = 1;
            boardArray[n / 2 - 1, n / 2] = 2;
            boardArray[n / 2, n / 2 - 1] = 2;
        }


        public void MuisClick(object sender, MouseEventArgs e)
        {
            Spelbord board = (Spelbord)sender;
            int x = 0 + (n - 0) * e.X / board.Width;
            int y = 0 + (n - 0) * e.Y / board.Height;
            Debug.WriteLine($"X: {x} en Y: {y}");
            int playingPlayer = 1;
            int opponent = 2;
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
            int x = board.Width / n;
            int y = board.Height / n;
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
                        e.Graphics.FillEllipse(Brushes.Black, i * x + 5, j * y + 5, x - 10, y - 10);
                    }
                    else if (boardArray[i, j] == 2)
                    {
                        e.Graphics.FillEllipse(Brushes.White, i * x + 5, j * y + 5, x - 10, y - 10);
                    }
                }
            }
        }
    }
}
