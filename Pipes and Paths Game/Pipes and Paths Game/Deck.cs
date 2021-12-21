using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pipes_and_Paths_Game
{
    class Deck
    {
        /// <summary>
        /// List of cards in the deck
        /// </summary>
        private List<Card> _cards = new List<Card>();

        /// <summary>
        /// Public list of the cards in the deck
        /// </summary>
        public List<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }

        /// <summary>
        /// Passes a cardtype into the deck, then generates and shuffles a deck
        /// </summary>
        /// <param name="cardType">The card type of the card</param>
        public Deck(Constant.CARD_TYPE cardType)
        {
            //Generates a new deck with a specified card type
            GenerateDeck(cardType);
            //Shuffles the deck
            Shuffle();
        }

        /// <summary>
        /// Generates the card in a deck
        /// </summary>
        public void GenerateDeck(Constant.CARD_TYPE cardType)
        {
            //Loop for 13 iterations to get 13 cards
            for (int i = 1; i < 14; i++)
            {
                //Add the two versions of each numbered card
                Cards.Add(new NumberCard(0, 0, i, cardType));
                Cards.Add(new NumberCard(0, 0, i, cardType));
            }

            //Adds a permanent boulder
            Cards.Add(new PermanentBoulder(0, 0, cardType));
            Cards.Add(new TemporaryBoulder(0, 0, cardType));
            Cards.Add(new TemporaryBoulder(0, 0, cardType));
        }
        
        /// <summary>
        /// Shuffles the deck by getting a list
        /// and ordering the cards according to that
        /// </summary>
        public void Shuffle()
        {
            //Gets a new random number generator
            Random random = new Random(Guid.NewGuid().GetHashCode());
            //Generates a set of random numbers to order them by
            Cards = Cards.OrderBy(card => random.Next()).ToList();
        }

        /// <summary>
        /// Draws the first card that is numbered
        /// </summary>
        /// <returns>The first numbered card</returns>
        public NumberCard DrawStartingCard()
        {
            //Go through the list of cards in the deck
            foreach (Card c in Cards)
            {
                //Check if the number card
                if (c is NumberCard)
                {
                    NumberCard cn = (NumberCard)c;
                    //Remove the card from the deck
                    Cards.Remove(c);
                    return cn;
                }
            }

            //Otherwise return nothing
            return null;
        }

        /// <summary>
        /// Draws the first card from the deck
        /// </summary>
        /// <returns>The first card from the deck</returns>
        public Card DrawCard()
        {
            //Checks if there are any cards in the first place
            if (Cards.Count == 0)
            {
                MessageBox.Show("There are no more cards left in the deck.");
                return null;
            }

            //Get the first card from the deck
            Card card = Cards[0];
            //Remove it from the list of cards in the deck
            Cards.RemoveAt(0);
            return card;
        }
    }
}
