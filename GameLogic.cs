using System;

public class Gamelogic
{
    int[6, 6] boardArray = new int[6,6];

    public Gamelogic(int[,] boardArray)
    {
        boardArray[2, 2] = 1;

    }

    /*
     *
     * public Object[] LegalMove(int playerPlayer, int opponent, int x, int y)
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
                    DirectionSpace _space = new DirectionSpace(x, y, 1, direction, boardArray, n);
                    if (_space.ReturnSpace() == opponent)
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
                                FlipStones(direction, playerPlayer, opponent, x, y);
                                break;
                            }
                            else
                            {
                                Debug.WriteLine("Player has not yet been found");
                            }
                        }
                    }
                }
            }

            return array;
        }*/

    /*public void FlipStones(Directions direction, int playingPlayer, int opponent, int x, int y)
        {
            for (int j = 1; x + j < boardArray.GetLength(0) && y + j < boardArray.GetLength(1); j++)
            {
                Debug.WriteLine("If this appears everything is going right....");
                DirectionSpace space = new DirectionSpace(x, y, j, direction, boardArray, n);
                if (space.ReturnSpace() == playingPlayer)
                {
                    Debug.WriteLine("Break");
                    break;
                }
                else
                {
                    Debug.WriteLine($"Flipping stones: {space.ReturnCoordinates().X},{space.ReturnCoordinates().Y}");
                    boardArray[space.ReturnCoordinates().X, space.ReturnCoordinates().Y] = playingPlayer;
                    this.Invalidate();
                }
            }
        }

    */

    /*internal class DirectionSpace
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


    }*/


    /*if(i < 0 || j < 0 || i >= n || j >= n)
            {
                return false;
            }
            if (boardArray[i,j] == _playingPlayer)
            {
                if (first == false) return false;

                if (play) PlayStones(-di + i, -dj + j, -di, -dj);
                return true;
            }
            else
            {
                if (boardArray[i, j] == 0) return false;
                i = i + di;
                j = j + dj;

                return FindEnclosure(i, j, di, dj, play, false);
            }*/

    /*if (boardArray[x, y] != 0)
            {
                return false;
            }
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        if (FindEnclosure(x + i, y + j, i, j))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;*/
}
