using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App_Center
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CountriesAPI_Click(object sender, RoutedEventArgs e)
        {
            CountriesAPI_Introduction countriesAPI_Introduction = new CountriesAPI_Introduction();
            countriesAPI_Introduction.Show();
            this.Close();
        }

        private void HangmanGame_Click(object sender, RoutedEventArgs e)
        {
            HangmanGame_Introduction hangmanGame_Introduction = new HangmanGame_Introduction();
            hangmanGame_Introduction.Show();
            this.Close();
        }

        private void MemoryGame_Click(object sender, RoutedEventArgs e)
        {
            MemoryGame_Introduction memoryGame_Introduction = new MemoryGame_Introduction();
            memoryGame_Introduction.Show();
            this.Close();
            
        }

        private void SnakeGame_Click(object sender, RoutedEventArgs e)
        {
            SnakeGame_Introduction snakeGame_Introduction = new SnakeGame_Introduction();
            snakeGame_Introduction.Show();
            this.Close();   
        }

        private void TicTacToeGame_Click(object sender, RoutedEventArgs e)
        {
            TicTacToeGame_Introduction ticTacToeGame_Introduction = new TicTacToeGame_Introduction();
            ticTacToeGame_Introduction.Show();
            this.Close();
        }

        private void WeatherAPI_Click(object sender, RoutedEventArgs e)
        {
            WeatherAPI_Introduction weatherAPI_Introduction = new WeatherAPI_Introduction();
            weatherAPI_Introduction.Show();
            this.Close();
        }
    }
}