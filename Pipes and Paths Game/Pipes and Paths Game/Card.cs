using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes_and_Paths_Game
{
    public abstract class Card
    {
        /// <summary>
        /// x position of the card
        /// </summary>
        private int _x;
        /// <summary>
        /// y position of the card
        /// </summary>
        private int _y;
        /// <summary>
        /// The type of card
        /// </summary>
        protected Constant.CARD_TYPE _cardType;
        /// <summary>
        /// Whether the card is currently selected
        /// </summary>
        private bool _selected;

        /// <summary>
        /// Public read-write property for the x position of the card
        /// </summary>
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Public read-write property for the y position of the card
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Public read-only property for the card type of the card
        /// </summary>
        public Constant.CARD_TYPE CardType
        {
            get { return _cardType; }
        }

        /// <summary>
        /// Public read-write property for whether the card is currently selected
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        /// <summary>
        /// Creates an instance of a card at a specified (x,y) location
        /// </summary>
        /// <param name="x">x position of the card</param>
        /// <param name="y">y position of the card</param>
        public Card(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Draws a card on a specific graphics object
        /// </summary>
        /// <param name="paper">The graphics object specified</param>
        public abstract void Draw(Graphics paper);

        /// <summary>
        /// Determines whether the x and y position are on the card
        /// </summary>
        /// <param name="x">x position of the mouse</param>
        /// <param name="y">y position of the mouse</param>
        /// <returns></returns>
        public bool IsMouseOn(int x, int y)
        {
            //Check whether the mouse is on the card
            if (x > X && x < X + Constant.CARD_SIZE
                && y > Y && y < Y + Constant.CARD_SIZE)
            {
                return true;
            }

            return false;
        }
    }
}
