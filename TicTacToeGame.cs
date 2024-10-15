using System.Windows;
using System.Windows.Controls;

namespace App_Center
{
    public partial class TicTacToeGame : Window
    {
        private int player = 0;
        private char[] boardArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public TicTacToeGame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int buttonIndex = int.Parse(button.Name.Substring(6));

            if (boardArray[buttonIndex] != 'X' && boardArray[buttonIndex] != 'O')
            {
                boardArray[buttonIndex] = player % 2 == 0 ? 'X' : 'O';
                button.Content = boardArray[buttonIndex];

                int gameStatus = CheckWin();

                if (gameStatus == 1)
                {
                    MessageBox.Show($"Congratulations! Player {player % 2 + 1} wins!");
                    ResetGame();
                }
                else if (gameStatus == -1)
                {
                    MessageBox.Show("It's a tie!");
                    ResetGame();
                }
                else
                {
                    player++;
                }
            }
        }

        private void ResetGame()
        {
            player = 0;
            boardArray = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Button1.Content = "";
            Button2.Content = "";
            Button3.Content = "";
            Button4.Content = "";
            Button5.Content = "";
            Button6.Content = "";
            Button7.Content = "";
            Button8.Content = "";
            Button9.Content = "";
        }

        private int CheckWin()
        {
            int[,] winConditions = new int[,]
            {
                {1,2,3},{4,5,6}, {7,8,9},
                {1,4,7},{2,5,8}, {3,6,9},
                {1,5,9},{3,5,7}
            };
            for (int i = 0; i < winConditions.GetLength(0); i++)
            {
                if (boardArray[winConditions[i, 0]] == boardArray[winConditions[i, 1]] &&
                    boardArray[winConditions[i, 1]] == boardArray[winConditions[i, 2]])
                    return 1;
            }

            if (IsBoardFull()) return -1;
            return 0;
        }

        private bool IsBoardFull()
        {
            for (int i = 1; i < boardArray.Length; i++)
            {
                if ((boardArray[i] != 'X') && (boardArray[i] != 'O')) return false;
            }
            return true;
        }

        private void backToMainPage_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
