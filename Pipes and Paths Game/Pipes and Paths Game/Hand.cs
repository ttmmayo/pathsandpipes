using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pipes_and_Paths_Game
{
    class Hand
    {
        private List<Card> _cards = new List<Card>();

        /// <summary>
        /// Public read-write list of the cards in the hand
        /// </summary>
        public List<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }

        /// <summary>
        /// Creates a hand with 6 cards
        /// </summary>
        /// <param name="deck">The deck to draw cards from</param>
        public Hand(Deck deck)
        {
            DealHand(deck);
        }

        /// <summary>
        /// Replenishes the hand until there are 6 cards
        /// </summary>
        /// <param name="deck">The deck to draw cards from</param>
        public void DealHand(Deck deck)
        {
            //While the count of cards is still less than 6
            while (Cards.Count < 6)
            {
                //Draw a card and add it to the hand
                Cards.Add(deck.DrawCard());
            }
        }

        /// <summary>
        /// Draws the hand onto the board
        /// </summary>
        /// <param name="paper">The specified graphics object</param>
        /// <param name="deck">The deck that is also drawn</param>
        public void Draw(Graphics paper, Deck deck)
        {
            //Initial location of the cards
            int x = Constant.CARD_XGAP;
            int y = Constant.CARD_YGAP;

            //Draw the empty and meaningless deck 
            if (deck.Cards.Count > 0)
            {
                //Change the colour of the brush to silver
                Constant.brushBackground.Color = Color.Silver;
                Constant.penOutline.Color = Color.Black;

                //Draw the deck as a silver rectangle
                paper.FillRectangle(Constant.brushBackground, x, y, Constant.CARD_SIZE, Constant.CARD_SIZE);
                paper.DrawRectangle(Constant.penOutline, x, y, Constant.CARD_SIZE, Constant.CARD_SIZE);
                x += Constant.CARD_SIZE + Constant.CARD_XGAP;
            }

            //For every card in the hand
            foreach (Card c in Cards)
            {
                if (c == null)
                {
                    return;
                }

                //Change the x and y position of the cards
                c.X = x;
                c.Y = y;
                //Draw the card
                c.Draw(paper);
                //Change the x position of the cards
                x += Constant.CARD_SIZE + Constant.CARD_XGAP;
            }
        }
    }
}
