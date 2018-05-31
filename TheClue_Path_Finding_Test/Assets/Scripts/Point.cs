using System;
using System.Collections.Generic;

namespace Assets
{
    public class Point
    {
        public override bool Equals(object obj)
        {
            Point other = (Point) obj;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool isMovable { get; set; }

        //점 이동에 사용
        public Point Translate(Point HorsePos, Point MovePos)
        {
            return new Point(HorsePos.X + MovePos.X, HorsePos.Y + MovePos.Y);
        }

        public bool Equal(Point checkerPoint)
        {
            return X == checkerPoint.X && Y == checkerPoint.Y ? true : false;
        }
    }
}
