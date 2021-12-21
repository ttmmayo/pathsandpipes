using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Pipes_and_Paths_Game
{
    public class BoardSpace : Card
    {
        /// <summary>
        /// The card that is currently on the boardspace
        /// </summary>
        Card _card = null;

        /// <summary>
        /// Public read-write property for the card on the boardspace
        /// </summary>
        public Card Card
        {
            get { return _card; }
            set { _card = value; }
        }

        /// <summary>
        /// Creates a boardspace at the specified location
        /// </summary>
        /// <param name="x">x position of the boardspace</param>
        /// <param name="y">y position of the boardspace</param>
        public BoardSpace(int x, int y) : base(x, y){ }

        /// <summary>
        /// Draws a white boardspace with black outline on the graphics object
        /// </summary>
        /// <param name="paper">The specified graphics object</param>
        public override void Draw(Graphics paper)
        {
            //Sets the colour of the outline pen to black
            Constant.penOutline.Color = Color.Black;
            //Sets the colour of the background pen to white
            Constant.brushBackground.Color = Color.White;
            //Fills in the background
            paper.FillRectangle(Constant.brushBackground, X, Y, Constant.CARD_SIZE, Constant.CARD_SIZE);
            //Draws the outline
            paper.DrawRectangle(Constant.penOutline, X, Y, Constant.CARD_SIZE, Constant.CARD_SIZE);

            //If there is a card on the boardspace
            if (Card != null)
            {
                //Set the coordinates of the card to be the same as the boardspace
                Card.X = X;
                Card.Y = Y;

                //Draw the card on the boardspace
                Card.Draw(paper);
            }
        }

        /// <summary>
        /// Check if it is next to a numbered card
        /// </summary>
        /// <param name="b">The name of the boardspace to check if it is next to</param>
        /// <returns></returns>
        public bool IsNextToNumberCard(BoardSpace b)
        {
            //Check if it is a number card
            if (b.Card is NumberCard)
            {
                if (b.X == X && b.Y == Y - Constant.CARD_SIZE)
                    return true;
                else if (b.X == X && b.Y == Y + Constant.CARD_SIZE)
                    return true;
                else if (b.X == X + Constant.CARD_SIZE && b.Y == Y)
                    return true;
                else if (b.X == X - Constant.CARD_SIZE && b.Y == Y)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determine whether the cards form a valid path or not
        /// </summary>
        /// <param name="boardSpaces">The name of the list of boardspaces</param>
        /// <returns></returns>
        public bool ValidPath(List<BoardSpace> boardSpaces, bool isPlayerCard)
        {
            List<BoardSpace> validBoards = new List<BoardSpace>();

            //Goes through the boardspaces and finds all the boardspaces excluding this one
            foreach (BoardSpace b in boardSpaces)
            {
                if (b != this)
                {
                    validBoards.Add(b);
                }
             
            }

            //Check for a boardspace that is not on the opponent's side
            if ((isPlayerCard && Y >= Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2)) ||
                !isPlayerCard && Y < Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2))
            {
                return true;
            }
            else
            {
                //For all the boardspaces in the list
                foreach (BoardSpace b in validBoards)
                {
                    if (b.Card != null)
                    {
                        //Check if it is next to it as a number card, and if the card type is the same
                        if (IsNextToNumberCard(b) && ((b.Card.CardType == Constant.playerCardType && isPlayerCard) 
                            || (b.Card.CardType == Constant.botCardType && !isPlayerCard)))
                        {
                            //Check if that boardspace is part of a valid path
                            if (b.ValidPath(validBoards, isPlayerCard))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }
    }
}
