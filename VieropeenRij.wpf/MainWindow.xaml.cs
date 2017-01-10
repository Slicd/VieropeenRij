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

//using System.ComponentModel;

namespace VieropeenRij.wpf
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameManager GameManager = new GameManager(); // init
        
        
        

        public MainWindow()
        {
            InitializeComponent();

            Image Rood = new Image();
            Image Geel = new Image();

            string imagePathYellow = "Images/Geel.png",
                   imagePathRed = "Images/Rood.png";
            
            Image image = new Image();
            
            A1.Source = IntToImageSourceConverter.SetImage(imagePathYellow);     // Zet Geel in Vak A1
            B1.Source = IntToImageSourceConverter.SetImage(imagePathRed);        // Zet Rood in vak B2

        }


        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            string buttonString = ((Button)e.OriginalSource).CommandParameter.ToString();
            int buttonValue = int.Parse(buttonString);

            GameManager.InsertCoin(buttonValue);

            int Victory = 0;
            Victory = GameManager.DiagonalCheck();
            if(Victory == 1)
            {
                MessageBox.Show("Good Game " + GameManager.CurrentPlayer());
            }

            GameManager.NextTurn();

            lblCurrentPlayer.Content = GameManager.CurrentPlayer();
        }
    }
}
