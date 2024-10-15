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

namespace App_Center
{
    /// <summary>
    /// Interaction logic for HangmanGame_Introduction.xaml
    /// </summary>
    public partial class HangmanGame_Introduction : Window
    {
        public HangmanGame_Introduction()
        {
            InitializeComponent();
        }

        private void startHangmanGame_button_Click(object sender, RoutedEventArgs e)
        {
            HangmanGame hangmanGame = new HangmanGame();
            hangmanGame.Show();
            this.Close();
        }

        private void backToMainPage_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
