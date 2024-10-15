using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
    
    public partial class WeatherAPI : Window
    {
        public ObservableCollection<Weather> Weathers { get; set; } = new ObservableCollection<Weather>();
        private static readonly HttpClient Client = new HttpClient();

        public WeatherAPI()
        {
            InitializeComponent();
            WeatherDataGrid.ItemsSource = Weathers;
        }

        // Getting the User input + loading the API
        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchTextBox = SearchTextBox.Text;
            await LoadWeatherAsync(searchTextBox);
        }

        private async Task LoadWeatherAsync(string searchCity)
        {
            try
            {
                string apiKey = "fb0a4482b56845de98f132035242909";
                string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={searchCity}&aqi=no";
                string json = await Client.GetStringAsync(url);

                Weather weather = JsonSerializer.Deserialize<Weather>(json);

                // Ensure the Icon has the full URL
                weather.Current.Condition.Icon = "http:" + weather.Current.Condition.Icon;

                Weathers.Clear();
                Weathers.Add(weather);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backToMainPage_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}