using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets
{
    public class TileFinder
    {
        public static List<Node> GetMovableTiles(Node Horse, int diceNumber , TileGrid grid)
        {
            List<Node> movableTiles = new List<Node>();

            List<int> boundaries = new List<int>();

            int tileGridX = grid.gridSizeX;
            int tileGridY = grid.gridSizeY;

            boundaries = GetRangeValue(diceNumber);

            //TODO 직선 거리에 장애물이 있을 때 못 가는 타일이 더 늘어나는 문제 해결하기
            foreach (int boundary in boundaries)
            {
                for (int x = 0; x <= boundary; x++)
                {
                    int y = boundary - x;

                    if (Enumerable.Range(0, tileGridX).Contains(Horse.gridX + x) && Enumerable.Range(0, tileGridY).Contains(Horse.gridY + y))
                        movableTiles.Add(grid.Grid[Horse.gridX + x, Horse.gridY + y]);

                    if (Enumerable.Range(0, tileGridX).Contains(Horse.gridX - x) && Enumerable.Range(0, tileGridY).Contains(Horse.gridY + y))
                        movableTiles.Add(grid.Grid[Horse.gridX - x, Horse.gridY + y]);

                    if (Enumerable.Range(0, tileGridX).Contains(Horse.gridX + x) && Enumerable.Range(0, tileGridY).Contains(Horse.gridY - y))
                        movableTiles.Add(grid.Grid[Horse.gridX + x, Horse.gridY - y]);

                    if (Enumerable.Range(0, tileGridX).Contains(Horse.gridX - x) && Enumerable.Range(0, tileGridY).Contains(Horse.gridY - y))
                        movableTiles.Add(grid.Grid[Horse.gridX - x, Horse.gridY - y]);
                }
            }

            return movableTiles;
        }

        static List<int> GetRangeValue(int dice)
        {
            int value = dice;
            int coordValue;

            List<int> coordinateValues = new List<int>();

            for (int i = 0; i <= value; i++)
            {
                if (value - 2 * i > 0)
                {
                    coordValue = value - 2 * i;
                    coordinateValues.Add(coordValue);
                }
                else
                {
                    break;
                }
            }

            return coordinateValues;
        }

        public static List<Node> RemoveDisableTiles(Point point, int dice, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
