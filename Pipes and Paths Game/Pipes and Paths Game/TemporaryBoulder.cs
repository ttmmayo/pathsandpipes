using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pipes_and_Paths_Game
{
    class TemporaryBoulder : Card
    {
        /// <summary>
        /// Gives the size of the stack of temporary boulders with an initial size of 4
        /// </summary>
        private int _stackSize = 4;

        /// <summary>
        /// Public read-write property for the size of the stack
        /// </summary>
        public int StackSize
        {
            get { return _stackSize; }
            set { _stackSize = value; }
        }

        /// <summary>
        /// Creates an instance of a temporary boulder
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cardType"></param>
        public TemporaryBoulder(int x, int y, Constant.CARD_TYPE cardType) : base(x, y)
        {
            _cardType = cardType;
        }

        /// <summary>
        /// Draws a temporary boulder
        /// </summary>
        /// <param name="paper">Specified graphics object</param>
        public override void Draw(Graphics paper)
        {
            //Check if the card is a pipe or a path
            if (CardType == Constant.CARD_TYPE.Pipe)
            {
                //Change the pen outline colour
                Constant.penOutline.Color = Color.Black;
                //Change the brush background colour
                Constant.brushBackground.Color = Color.SaddleBrown;
                //Change the brush path colour
                Constant.brushPath.Color = Color.Gray;

            }
            else if (CardType == Constant.CARD_TYPE.Path)
            {
                //Change the pen outline colour
                Constant.penOutline.Color = Color.Black;
                //Change the brush background colour
                Constant.brushBackground.Color = Color.Green;
                //Change the brush path colour
                Constant.brushPath.Color = Color.SaddleBrown;
            }

            //Checks if the card is selected
            if (Selected)
            {
                //Changes the colour of the selected card to red
                Constant.penOutline.Color = Color.Red;
            }

            //Draw the background of the card
            paper.FillRectangle(Constant.brushBackground, X, Y, Constant.CARD_SIZE, Constant.CARD_SIZE);
            //Draw the two crossing paths of the card
            paper.FillRectangle(Constant.brushPath, X, Y + Constant.CARD_SIZE / 2 - Constant.PATH_WIDTH / 2, Constant.CARD_SIZE, Constant.PATH_WIDTH);
            paper.FillRectangle(Constant.brushPath, X + Constant.CARD_SIZE / 2 - Constant.PATH_WIDTH / 2, Y, Constant.PATH_WIDTH, Constant.CARD_SIZE);
            //Draw the outline of the card
            paper.DrawRectangle(Constant.penOutline, X, Y, Constant.CARD_SIZE, Constant.CARD_SIZE);
            //Draw the temporary boulder
            paper.FillEllipse(Constant.brushTemporaryBoulder, X + Constant.CARD_SIZE / 2 - Constant.BOULDER_RADIUS / 4, Y + Constant.CARD_SIZE / 2 - Constant.BOULDER_RADIUS / 4, Constant.BOULDER_RADIUS / 2, Constant.BOULDER_RADIUS / 2);
            //Draws the number onto the card
            paper.DrawString(StackSize.ToString(), SystemFonts.DefaultFont, Brushes.Red, X + Constant.NUMBER_LOCATION, Y + Constant.NUMBER_LOCATION);
        }
    }
    
}
