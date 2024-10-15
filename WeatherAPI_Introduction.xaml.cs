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
    /// Interaction logic for WeatherAPI_Introduction.xaml
    /// </summary>
    public partial class WeatherAPI_Introduction : Window
    {
        public WeatherAPI_Introduction()
        {
            InitializeComponent();
        }

        private void backToMainPage_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void WeatherAPI_button_Click(object sender, RoutedEventArgs e)
        {
            WeatherAPI weatherAPI = new WeatherAPI();
            weatherAPI.Show();
            this.Close();
        }
    }
}
