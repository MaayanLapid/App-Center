﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace App_Center
{

    public partial class SnakeGame : Window
    {
        private Game game;
        private DispatcherTimer gameTimer;
        private const int GridSize = 20;

        public SnakeGame()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            game = new Game(GridSize, GridSize);
            InitializeGameGrid();

            gameTimer = new DispatcherTimer();
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = TimeSpan.FromMilliseconds(200);
            gameTimer.Start();

            KeyDown += MainWindow_KeyDown;
        }

        private void InitializeGameGrid()
        {
            GameGrid.Rows = GridSize;
            GameGrid.Columns = GridSize;

            GameGrid.Children.Clear();
            for (int i = 0; i < GridSize * GridSize; i++)
            {
                GameGrid.Children.Add(new GridCell());
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Update();
            UpdateUI();
            if (game.GameOver)
            {
                gameTimer.Stop();
                GameOverOverlay.Visibility = Visibility.Visible;
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    game.ChangeDirection(Direction.Up);
                    break;
                case Key.Down:
                    game.ChangeDirection(Direction.Down);
                    break;
                case Key.Left:
                    game.ChangeDirection(Direction.Left);
                    break;
                case Key.Right:
                    game.ChangeDirection(Direction.Right);
                    break;
            }
        }

        private void UpdateUI()
        {
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    int index = row * GridSize + col;
                    ((GridCell)GameGrid.Children[index]).SetState(game.GetCellState(col, row));
                }
            }
            ScoreText.Text = game.Score.ToString();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            game.ResetGame();
            GameOverOverlay.Visibility = Visibility.Collapsed;
            gameTimer.Start();
            UpdateUI();
        }

        private void backToMainPage_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}