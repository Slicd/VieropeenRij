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
using vierOpeenRij.libb;
namespace VieropeenRij.wpf
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameManager GameManager = new GameManager(); // init
        int CurrentTurn = 1; // begint met speler 1

        public MainWindow()
        {
            InitializeComponent();

            Image Rood = new Image();
            Image Geel = new Image();

           // Rood.Source = new BitmapImage(new Uri("R:///C#/VieropeenRij/Rood.png")); // Dit pad is anders voor elke gebruiker dit moet nog veranderen. (Relative)
          //  Geel.Source = new BitmapImage(new Uri("R:///C#/VieropeenRij/Geel.png"));


            B2.Source = Rood.Source;        // Zet Rood in vak B2
            A1.Source = Geel.Source;        // Zet Geel in vak A1
        }

        private void btnA_Click(object sender, RoutedEventArgs e)
        {
            CurrentTurn = GameManager.CurrentTurnChecker(CurrentTurn);
            lblCurrentPlayer.Content =  GameManager.CurrentPlayer(CurrentTurn);
            
        }

        private void btnB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnE_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnG_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
