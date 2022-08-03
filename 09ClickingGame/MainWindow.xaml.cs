using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace _09ClickingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int score = 0;
        public static int time = 10;
        public static Random rnd = new Random();
        public static DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void AddRectangle()
        {
            Rectangle temp = new Rectangle();
            temp.Width = 50;
            temp.Height = 50;
            temp.Fill = Brushes.SaddleBrown;
            double x = rnd.Next() % (cnv.Width - 50);
            double y = rnd.Next() % (cnv.Height - 50);
            temp.Margin = new Thickness(x, y, 0, 0);
            temp.MouseDown += Rectangle_MouseDown;
            cnv.Children.Add(temp);
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cnv.Children.Remove((Rectangle)sender);
            score++;
            txbScore.Text = score.ToString();
            AddRectangle();
        }

        private void Timer_Tick(object Sender, EventArgs e)
        {
            time--;
            txbTime.Text=time.ToString();
            if (time == 0)
            {
                timer.Stop();
                cnv.Children.Clear();
            }
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            score = 0;
            time = 10;
            AddRectangle();
        }
    }
}
