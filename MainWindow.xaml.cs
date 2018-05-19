using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MacPan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //todo add player and ghost variables after making constructors.
        DispatcherTimer gameTimer = new DispatcherTimer();
        public int fps = 60;
        public int lives;
        public int score;
        Ghost Clyde;
        Ghost Pinky;
        Ghost Blinky;
        Ghost Inky;
        Player player;
        List<Pill> pillList = new List<Pill>();
        //todo add logic for reading custom maps
        Tile.tiles[,] board = { { Tile.tiles.wall, Tile.tiles.wall, Tile.tiles.wall, Tile.tiles.wall, Tile.tiles.wall },
                                        { Tile.tiles.wall, Tile.tiles.blank, Tile.tiles.blank, Tile.tiles.blank, Tile.tiles.wall,},
                                        { Tile.tiles.wall, Tile.tiles.blank, Tile.tiles.superPill, Tile.tiles.blank, Tile.tiles.wall, },
                                         { Tile.tiles.wall, Tile.tiles.blank, Tile.tiles.blank, Tile.tiles.blank, Tile.tiles.wall,},
                                         { Tile.tiles.wall, Tile.tiles.wall, Tile.tiles.wall, Tile.tiles.wall, Tile.tiles.wall,}};
        Tile[,] gameboard;
        public MainWindow()
        {
            //todo populate pill list
            gameboard = new Tile[board.GetLength(0), board.GetLength(1)];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if (board[i, c] == Tile.tiles.blank || board[i, c] == Tile.tiles.superPill)
                    {
                        //todo have pills location be dynamic
                        Pill p = new Pill(board[i, c] == Tile.tiles.superPill, new Point());
                        pillList.Add(p);
                    }
                }
            }
            InitializeComponent();
            Clyde = new Ghost(Ghost.ghostNames.Clyde, canvas);
            Pinky = new Ghost(Ghost.ghostNames.Pinky, canvas);
            Blinky = new Ghost(Ghost.ghostNames.Blinky, canvas);
            Inky = new Ghost(Ghost.ghostNames.Inky, canvas);
            player = new Player(canvas);
            gameTimer.Tick += gameTick;
            gameTimer.Interval += new TimeSpan(0, 0, 0, 0, 1000 / fps);
            gameTimer.Start();

            DrawWall(canvas);
        }

        private void DrawWall(Canvas c)
        {
            int tileSize = 100;
            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    if (board[i, ii].Equals(Tile.tiles.wall))
                    {
                        //todo create 2d array for tiles(class)
                        gameboard[i,ii] = new Tile(canvas, Tile.tiles.wall,new Point(tileSize*ii,tileSize*i));
                        
                    }
                }
            }
        }

        private void gameTick(object sender, EventArgs e)
        {
            //todo add game update calls 
            player.update();
        }

    }
}
