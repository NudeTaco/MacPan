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
        enum tiles { blank, wall, ghostGate, superPill }

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
        tiles[,] gameboard = { { tiles.wall, tiles.wall, tiles.wall, tiles.wall, tiles.wall },
                                        { tiles.wall, tiles.blank, tiles.blank, tiles.blank, tiles.wall,},
                                        { tiles.wall, tiles.blank, tiles.superPill, tiles.blank, tiles.wall, },
                                         { tiles.wall, tiles.blank, tiles.blank, tiles.blank, tiles.wall,},
                                         { tiles.wall, tiles.wall, tiles.wall, tiles.wall, tiles.wall,}};
        public MainWindow()
        {
            //todo populate pill list
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int c = 0; c < gameboard.GetLength(1); c++)
                {
                    if (gameboard[i, c] == tiles.blank || gameboard[i, c] == tiles.superPill)
                    {
                        //todo have pills location be dynamic
                        Pill p = new Pill(gameboard[i, c] == tiles.superPill, new Point());
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
        }

        private void gameTick(object sender, EventArgs e)
        {
            //todo add game update calls 
            player.update();
        }

    }
}
