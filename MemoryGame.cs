using System.Collections.ObjectModel;
using System.Reflection;
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

    public partial class MemoryGame : Window
    {
        public ObservableCollection<MemoryGameCard> Cards { get; set; }
        public List<string> cardsImagesToShow = new List<string>();

        private MemoryGameCard firstRevealedCard = null;
        private MemoryGameCard secondRevealedCard = null;

        public MemoryGame()
        {
            InitializeComponent();
            // Initialize the cards collection
            Cards = new ObservableCollection<MemoryGameCard>();

            initListOfCardImage();

            // Create the cards
            CreateCards();

            // Set the DataContext to bind the UI
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Get the cardId from the Tag property of the button
                int cardId = (int)clickedButton.Tag;
                RevealCard(cardId);
            }
        }

        public void CreateCards()
        {
            // Create pairs of images
            List<string> imagesForPairs = new List<string>(cardsImagesToShow);

            // Double the list to create pairs (0-7 will become 0-7 and 0-7 again)
            imagesForPairs.AddRange(imagesForPairs);

            // Shuffle the list so pairs are not next to each other
            Random random = new Random();
            imagesForPairs = imagesForPairs.OrderBy(x => random.Next()).ToList();

            // Clear the Cards collection to start fresh
            Cards.Clear();

            // Assign images to the cards
            for (int cardId = 0; cardId < imagesForPairs.Count; cardId++)
            {
                // Use the shuffled list to get the image URI
                string imageUri = imagesForPairs[cardId];

                // Add each card with the image to the collection
                Cards.Add(new MemoryGameCard { Id = cardId, CardImage = null }); // Initialize CardImage as null to keep it hidden
            }

            // Shuffle the cards' positions after assigning the images
            ShuffleCards();
        }

        private void ShuffleCards()
        {
            Random random = new Random();
            int count = Cards.Count;

            for (int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(count);
                Cards.Move(i, randomIndex);  // Shuffle cards in the ObservableCollection
            }
        }



        public void RevealCard(int cardId)
        {
            // Find the card in the collection that matches the given cardId
            MemoryGameCard selectedCard = Cards.FirstOrDefault(card => card.Id == cardId);

            if (selectedCard != null)
            {
                // Check if two cards are already revealed
                if (firstRevealedCard != null && secondRevealedCard != null)
                {
                    return; // Prevent further clicks until cards are evaluated
                }

                // Get the image URI for the selected card based on its position in the shuffled list
                string selectedCardURI = cardsImagesToShow[cardId % cardsImagesToShow.Count]; // Modulo operator to ensure proper indexing
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(selectedCardURI, UriKind.Absolute);
                image.EndInit();
                selectedCard.CardImage = image;

                if (firstRevealedCard == null)
                {
                    firstRevealedCard = selectedCard;
                }
                else if (secondRevealedCard == null)
                {
                    secondRevealedCard = selectedCard;

                    // Check for a match
                    if (CheckForMatch(firstRevealedCard, secondRevealedCard))
                    {
                        // Cards match, reset for next pair
                        firstRevealedCard = null;
                        secondRevealedCard = null;

                        // Check if the game is completed
                        CheckGameCompletion();
                    }
                    else
                    {
                        // No match, hide cards after a short delay
                        Task.Delay(1000).ContinueWith(_ =>
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                firstRevealedCard.CardImage = null;
                                secondRevealedCard.CardImage = null;
                                firstRevealedCard = null;
                                secondRevealedCard = null;
                            });
                        });
                    }
                }
            }
        }
        


        private bool CheckForMatch(MemoryGameCard card1, MemoryGameCard card2)
        {
            // Ensure both card images are of type BitmapImage
            if (card1.CardImage is BitmapImage bitmap1 && card2.CardImage is BitmapImage bitmap2)
            {
                return bitmap1.UriSource == bitmap2.UriSource;
            }
            return false; // Return false if either card does not have a BitmapImage
        }


        public void initListOfCardImage()
        {
            int numOfCards = 8;
            for (int i = 0; i < numOfCards; i++)
            {
                string cardsSource = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pics", "animal", $"card{i}.jpg");
                cardsImagesToShow.Add(cardsSource);
            }
        }

        private void CheckGameCompletion()
        {
            // Check if all cards have been revealed
            if (Cards.All(card => card.CardImage != null))
            {
                // Show a message box indicating the game is over
                MessageBox.Show("Congratulations! You've finished the game!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);

                // Show the "Play Again" button
                PlayAgainButton.Visibility = Visibility.Visible;
            }
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            // Reset the game state
            ResetGame();
        }

        private void ResetGame()
        {
            // Clear the current cards
            Cards.Clear();

            // Reinitialize card images and create cards again
            initListOfCardImage();
            CreateCards();

            // Hide the "Play Again" button
            PlayAgainButton.Visibility = Visibility.Collapsed;

            // Reset the revealed cards
            firstRevealedCard = null;
            secondRevealedCard = null;
        }

        private void backToMainPage_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }

}