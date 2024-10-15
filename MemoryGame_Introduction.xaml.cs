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
    /// Interaction logic for MemoryGame_Introduction.xaml
    /// </summary>
    public partial class MemoryGame_Introduction : Window
    {
        public MemoryGame_Introduction()
        {
            InitializeComponent();
        }

        private void MemoryGame_button_Click(object sender, RoutedEventArgs e)
        {
            MemoryGame memoryGame = new MemoryGame();
            memoryGame.Show();
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
