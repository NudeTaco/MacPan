using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MacPan
{
    class AIHandler
    {
        enum direction { up,right,down,left};
        public static List<Node> mapPlacement;
        private Tile[,] gameboard;
        Point start;
        public AIHandler(Tile[,] board)
        {
            this.gameboard = board;
            for(int i = 0; i < gameboard.GetLength(0);i++)
            {
                for(int c = 0; c <gameboard.GetLength(1);c++)
                {
                    if(gameboard[i,c].Equals(Tile.tiles.ghostGate))
                    {
                        recursiveChecker(direction.up, c, i);
                    }
                }
            }
        }
        private void recursiveChecker(direction d,int x,int y)
        {
            bool createNode = true;
            switch(d)
            {
                case direction.up:
                    if(gameboard[y-1,x].Equals(Tile.tiles.blank))
                    {
                        recursiveChecker(d, x, y - 1);
                    }
                    break;
                case direction.right:
                    if (gameboard[y, x+1].Equals(Tile.tiles.blank))
                    {
                        recursiveChecker(d, x+1, y);
                    }
                    break;
                case direction.down:
                    if (gameboard[y + 1, x].Equals(Tile.tiles.blank))
                    {
                        recursiveChecker(d, x, y + 1);
                    }
                    break;
                case direction.left:
                    if (gameboard[y, x-1].Equals(Tile.tiles.blank))
                    {
                        recursiveChecker(d, x-1, y);
                    }
                    break;
            }
        }
    }
}
