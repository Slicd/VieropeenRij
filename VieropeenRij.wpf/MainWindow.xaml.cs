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

           // string imagePathYellow = "Images/Geel.png",
           // imagePathRed = "Images/Rood.png";
            
            Image image = new Image();

           // A1.Source = IntToImageSourceConverter.SetImage(imagePathYellow);     // Zet Geel in Vak A1
           // B1.Source = IntToImageSourceConverter.SetImage(imagePathRed);        // Zet Rood in vak B2
            

            for (int column = 0; column < 7; column++)
            {
                for (int row = 1; row < 7; row++)
                {
                    Image hokje = new Image();
                    hokje.Source = IntToImageSourceConverter.SetImage(IntToImageSourceConverter.imagePathEmpty);
                    this.XAMLGrid.Children.Add(hokje);
                    Grid.SetRow(hokje, row);
                    Grid.SetColumn(hokje, column);
                }
            }

        }


        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            string buttonString = ((Button)e.OriginalSource).CommandParameter.ToString();
            int buttonValue = int.Parse(buttonString);

            GameManager.InsertCoin(buttonValue);
            RefreshUIGrid();

            
            
            if(GameManager.DiagonalCheck() == 1 || GameManager.HorizontalCheck() == 1)
            {
                MessageBox.Show("Good Game " + GameManager.CurrentPlayer());
            }
            
            GameManager.NextTurn();

            lblCurrentPlayer.Content = GameManager.CurrentPlayer();
        }


        private void RefreshUIGrid()
        {
            int[,] uiGrid = GameManager.GetGameGrid();
            XAMLGrid.Children.Clear();

            for (int column = 0; column < 7; column++)
            {
                for (int row = 1; row < 7; row++)
                {
                    Image hokje = new Image();
                    hokje.Source = IntToImageSourceConverter.Convert(uiGrid[column,row]);
                    this.XAMLGrid.Children.Add(hokje);
                    Grid.SetRow(hokje, row);
                    Grid.SetColumn(hokje, column);
                }
            }

        }
    }
}
