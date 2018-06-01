using System;
using System.Collections.Generic;

namespace Assets
{
    public class Board
    {
        public Board(int x, int y)
        {
            Points = new Point[x, y];

            for (int i = 0; i < Points.GetLength(0); i++)
            {
                for (int j = 0; j < Points.GetLength(1); j++)
                {
                    Point point = new Point(i, j);
                    point.isMovable = false;

                    Points[i, j] = point;
                }
            }
        }

        public Point[,] Points { get; private set; }

        public void ShowBoard()
        {
            for (int i = 0; i < Points.GetLength(0); i++)
            {
                for (int j = 0; j < Points.GetLength(1); j++)
                {
                    Console.Write(Points[i, j].isMovable);
                }
                Console.WriteLine();
            }
        }
    }
}
