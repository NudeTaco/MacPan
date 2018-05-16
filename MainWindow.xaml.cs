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
        public int fps;
        public int lives;
        public int score;
        List<Pill> pillList = new List<Pill>();
        public MainWindow()
        {
            //todo populate pill list

            InitializeComponent();
            gameTimer.Tick += gameTick;
            gameTimer.Interval += new TimeSpan(0, 0, 0, 1 / fps);
            gameTimer.Start();
        }

        private void gameTick(object sender, EventArgs e)
        {
            //todo add game update calls
        }

    }
}
