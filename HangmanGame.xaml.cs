using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace App_Center
{
    public partial class HangmanGame : Window
    {
        public List<Questions> questions;
        public string randomWord;
        public char[] guessedWord;
        public int incorrectGuesses;
        public const int MaxIncorrectGuesses = 7;

        public HangmanGame()
        {
            InitializeComponent();
            LoadQuestions();
        }

        public void LoadQuestions()
        {
            string questionsJson = File.ReadAllText("SubjectQuestions.json");
            questions = JsonSerializer.Deserialize<List<Questions>>(questionsJson);
        }

        public void StartGame_Click(object sender, RoutedEventArgs e)
        {
            string category = ((ComboBoxItem)CategoryComboBox.SelectedItem).Content.ToString().ToLower().Replace(" ", "_");
            randomWord = GetRandomWord(category);
            guessedWord = new char[randomWord.Length];

            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }
            incorrectGuesses = 0;

            UpdateUI();
            GuessTextBox.IsEnabled = true;
            GameOverTextBlock.Text = "";
        }

        public string GetRandomWord(string category)
        {
            var categoryQuestions = questions.FirstOrDefault(q => q.Category.ToLower() == category.ToLower());
            if (categoryQuestions != null && categoryQuestions.Names.Length > 0)
            {
                Random random = new Random();
                return categoryQuestions.Names[random.Next(categoryQuestions.Names.Length)];
            }
            return null;
        }

        public void Guess_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(GuessTextBox.Text))
                return;

            char userGuess = GuessTextBox.Text.ToLower()[0];
            GuessTextBox.Text = "";

            bool foundMatch = false;
            for (int i = 0; i < randomWord.Length; i++)
            {
                if (char.ToLower(randomWord[i]) == userGuess)
                {
                    guessedWord[i] = randomWord[i];
                    foundMatch = true;
                }
            }

            if (!foundMatch)
            {
                incorrectGuesses++;
            }

            UpdateUI();

            if (incorrectGuesses >= MaxIncorrectGuesses)
            {
                EndGame(false);
            }
            else if (!guessedWord.Contains('_'))
            {
                EndGame(true);
            }
        }

        public void UpdateUI()
        {
            WordToGuessTextBlock.Text = string.Join(" ", guessedWord);
            IncorrectGuessesTextBlock.Text = $"Incorrect guesses: {incorrectGuesses}/{MaxIncorrectGuesses}";
            HangmanTextBlock.Text = GetHangmanAscii(incorrectGuesses);

            // Check if the game is over
            if (incorrectGuesses >= MaxIncorrectGuesses)
            {
                EndGame(false);
            }
            else if (!guessedWord.Contains('_'))
            {
                EndGame(true);
            }
        }

        public void EndGame(bool won)
        {
            GuessTextBox.IsEnabled = false;
            if (won)
            {
                GameOverTextBlock.Text = "Congratulations! You've guessed the word!";
                GameOverTextBlock.Foreground = Brushes.Green;
            }
            else
            {
                GameOverTextBlock.Text = $"Game Over! The word was: {randomWord}";
                GameOverTextBlock.Foreground = Brushes.Red;
            }
        }

        public string GetHangmanAscii(int stage)
        {
            string[] hangmanStages = new string[]
            {
                @"
    
    
    
    
    
    
  _____",
                @"
    ________
    |      |
    |
    |
    |
    |
    |
  _____",
                @"
    ________
    |      |
    |      @
    |
    |
    |
    |
  _____",
                @"
    ________
    |      |
    |      @
    |      |
    |      |
    |
    |
  _____",
                @"
    ________
    |      |
    |      @
    |     /|
    |      |
    |
    |
  _____",
                @"
    ________
    |      |
    |      @
    |     /|\
    |      |
    |
    |
  _____",
                @"
    ________
    |      |
    |      @
    |     /|\
    |      |
    |     /
    |
  _____",
                @"
    ________
    |      |
    |      @
    |     /|\
    |      |
    |     / \
    |
  _____"
            };

            return hangmanStages[stage];
        }

        private void backToMainPage_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

    public class Questions
    {
        public string Category { get; set; }
        public string[] Names { get; set; }
    }
}