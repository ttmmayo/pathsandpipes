using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pipes_and_Paths_Game
{
    class PermanentBoulder : Card
    {
        /// <summary>
        /// Creates a permanent boulder
        /// </summary>
        /// <param name="x">x position of boulder</param>
        /// <param name="y">y position of the boulder</param>
        /// <param name="cardType">whether it is a pipe or path boulder</param>
        public PermanentBoulder(int x, int y, Constant.CARD_TYPE cardType) : base(x, y)
        {
            _cardType = cardType;
        }

        /// <summary>
        /// Draws a permanent boulder
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
            //Draw the permanent boulder
            paper.FillEllipse(Constant.brushPermanentBoulder, X + Constant.CARD_SIZE / 2 - Constant.BOULDER_RADIUS / 2, Y + Constant.CARD_SIZE / 2 - Constant.BOULDER_RADIUS / 2, Constant.BOULDER_RADIUS, Constant.BOULDER_RADIUS);
            //Draw the outline of the card
            paper.DrawRectangle(Constant.penOutline, X, Y, Constant.CARD_SIZE, Constant.CARD_SIZE);
            
        }
    }
}
