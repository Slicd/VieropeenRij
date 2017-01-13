using System;
using System.Collections.Generic;
using System.Diagnostics;
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

       public Player Speler1 = new Player();
       public Player Speler2 = new Player();

        public MainWindow(Player Player1, Player Player2)
        {
            InitializeComponent();

            Speler1 = Player1;
            Speler2 = Player2;

            lblCurrentPlayer.Content = Speler1.Name; 

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

            
            if(GameManager.InsertCoin(buttonValue) == true)
            {
                MessageBox.Show("Kies een andere kolom, " + GameManager.CurrentPlayer(Speler1,Speler2));
                return;
            }

            RefreshUIGrid();

            if(GameManager.DiagonalCheck() == true || GameManager.HorizontalCheck() == true || GameManager.VerticalCheck() == true)
            {
                MessageBoxResult result = MessageBox.Show("Good Game " + GameManager.CurrentPlayer(Speler1, Speler2) + Environment.NewLine + "Wil je nog een spel met dezelfde spelers?", "Wie is de beste? " + GameManager.CurrentPlayer(Speler1, Speler2) + " is de beste!", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        GameManager.CreateEmptyGameGrid();
                        RefreshUIGrid();
                        break;
                    case MessageBoxResult.No:
                        RestartGame();
                        break;
                    
                }
               
                
            }
            
            if(GameManager.Tzitvol() == true)
            {
                MessageBox.Show("Spel zit vol, geen winnaar" + Environment.NewLine + "Restarting Game");
                RestartGame();
            }

            GameManager.NextTurn();

            lblCurrentPlayer.Content = GameManager.CurrentPlayer(Speler1, Speler2);

            if (GameManager.CurrentColor == (int)GameManager.color.yellow)
            {
                lblCurrentPlayer.Foreground = System.Windows.Media.Brushes.Yellow;
                lblTurn.Foreground = System.Windows.Media.Brushes.Yellow;
            }
            else
            {
                lblCurrentPlayer.Foreground = System.Windows.Media.Brushes.Red;
                lblTurn.Foreground = System.Windows.Media.Brushes.Red;
            }
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

        private void RestartGame()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        
        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}
