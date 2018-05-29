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

        private bool mapLoaded = false;

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
        Ghost[] ghosts;
        List<Pill> pillList = new List<Pill>();
        //todo add logic for reading custom maps
        Tile.tiles[,] board;
        Tile[,] gameboard;
        public MainWindow()
        {
            InitializeComponent();
            MapParser parser = new MapParser("map1");
            board = parser.readMap();
            //todo populate pill list
            gameboard = new Tile[board.GetLength(0), board.GetLength(1)];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if (board[i, c] == Tile.tiles.blank || board[i, c] == Tile.tiles.superPill)
                    {
                        //todo have pills location be dynamic
                        Pill p = new Pill(board[i, c] == Tile.tiles.superPill, new Point(c * Tile.tileSize, i * Tile.tileSize), canvas);
                        pillList.Add(p);
                    }
                }
            }
            Clyde = new Ghost(Ghost.ghostNames.Clyde, canvas);
            Pinky = new Ghost(Ghost.ghostNames.Pinky, canvas);
            Blinky = new Ghost(Ghost.ghostNames.Blinky, canvas);
            Inky = new Ghost(Ghost.ghostNames.Inky, canvas);
            ghosts = new Ghost[] { Clyde, Pinky, Blinky, Inky };
            player = new Player(canvas);
            gameTimer.Tick += gameTick;
            gameTimer.Interval += new TimeSpan(0, 0, 0, 0, 1000 / fps);

            DrawWalls(canvas);
            gameTimer.Start();
            //Console.WriteLine(gameboard[0, 0].ToString());
            canvas.Background = Brushes.Black;
            Rectangle statusBlock = new Rectangle();
            statusBlock.Height = 100;
            statusBlock.Width = 525;
            statusBlock.Fill = Brushes.Red;
            Canvas.SetBottom(statusBlock, 0);
            Canvas.SetLeft(statusBlock, 0);
            TextBlock txtInfo = new TextBlock();
            txtInfo.Text = "Lives: " + lives.ToString() + "" + "\n" + "Level: " + "n/a";
            txtInfo.FontSize = 20;
            Canvas.SetBottom(txtInfo, statusBlock.Height - txtInfo.FontSize - 10);
            Canvas.SetLeft(txtInfo, 10);
            canvas.Children.Add(statusBlock);
            canvas.Children.Add(txtInfo);
        }

        private void DrawWalls(Canvas c)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    gameboard[i, x] = new Tile(canvas, board[i, x], new Point(Tile.tileSize * x, Tile.tileSize * i));
                }
            }
            mapLoaded = true;
        }

        private void gameTick(object sender, EventArgs e)
        {
            //todo add game update calls 
            //Console.WriteLine(gameboard[0, 0].ToString());
            if (mapLoaded)
            {
                if (pillList.Count == 0) mapLoaded = false;
                player.update(ghosts, gameboard);
                for (int i = 0; i < pillList.Count; i++)
                {
                    if (player.checkCollision(pillList.ElementAt(i)))
                    {
                        pillList.ElementAt(i).eat();
                        pillList.RemoveAt(i);
                    }
                }
            }
            //Console.WriteLine(player.checkCollision(Clyde));
        }

    }
}
