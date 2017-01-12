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
using System.Windows.Shapes;
using vierOpeenRij.libb;

namespace VieropeenRij.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        Player Speler1 = new Player();
        Player Speler2 = new Player();


        public string player1window1;
        public string player2window1;


        private void btn_play_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txtbx_player1.Text) || string.IsNullOrWhiteSpace(txtbx_player2.Text))
            {
                ShowWarning("Vier Op 'N Rij", "Gelieve een naam te kiezen!");

            }
            else
            {
                Speler1.Name = txtbx_player1.Text;
                Speler2.Name = txtbx_player2.Text;

                MainWindow Newgame = new MainWindow(Speler1, Speler2);

                Newgame.Show();
                this.Close();
            }

        }

        private void ShowWarning(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}