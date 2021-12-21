using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pipes_and_Paths_Game
{
    class Bot
    {
        /// <summary>
        /// Deck of cards
        /// </summary>
        Deck Deck;
        /// <summary>
        /// Hand of cards
        /// </summary>
        Hand Hand;

        /// <summary>
        /// A property that determines if the bot is simply random or possesses intelligence
        /// </summary>
        bool isSmart;

        /// <summary>
        /// Creates a bot with the relevant deck and hand of cards
        /// </summary>
        /// <param name="deck">Deck of cards</param>
        /// <param name="hand">Hand of cards</param>
        public Bot(Deck deck, Hand hand, bool is_smart)
        {
            Deck = deck;
            Hand = hand;
            isSmart = is_smart;
        }

        /// <summary>
        /// Allows the bot to make a move. It can make a random move by randomly selecting a card from its hand
        /// and a boardspace. It can also make a smart move if this option is selected by selecting the highest
        /// number card from its hand and playing aggressively as possible. It then checks whether this is a valid
        /// move.
        /// </summary>
        /// <param name="boardSpaces">The list of boardspaces on the board</param>
        /// <param name="paper">The graphics object to count from</param>
        public void BotMove(List<BoardSpace> boardSpaces, Graphics paper)
        {   
            //Counter for the bot's move
            int botMoveCounter = 0;
            Random random = new Random();
            //Name of the card and boardspace
            Card c;
            BoardSpace b = null;
            //Counters
            int boardSpaceCounter = boardSpaces.Count;
            int boardSpaceCounter2 = boardSpaces.Count / 2;
            int counter = 0;
            //Whether the bot is playing defensively or not
            bool defensive = false;

            //Check whether there are many spaces on the board, and if so play defensively
            for (int i = 0; i < (boardSpaces.Count / 2); i++)
            {
                //Ensure that the boardspace has a card
                if (boardSpaces[i].Card != null)
                {
                    //Check that it is the right type and increase the counter if so
                    if (boardSpaces[i].Card.CardType == Constant.playerCardType)
                        counter++;
                }

            }

            //If there are at least 3 cards on the enemy side, play defensively
            if (counter > 2)
                defensive = true;

            //While the bot has done less than two moves
            while (botMoveCounter < 2)
            {
                int winningBotCounter = 0;
                //Random generator for determining whether bot is aggressive or defensive
                Random rand = new Random();

                //Randomly select a card from the bot's hand
                if (Hand.Cards == null)
                {
                    MessageBox.Show("The bot has run out of cards.");
                    return;
                }
                
                //Performs the bot move either smartly, or randomly
                //Aggressive move
                if (isSmart && defensive == false)
                {
                    c = SmartBotCard();
                    //Find the furtherest boardspace until one of them can work.
                    boardSpaceCounter = boardSpaceCounter - 1;
                    b = boardSpaces[boardSpaceCounter];
                    
                }
                //Defensive move
                else if (isSmart && defensive == true)
                {
                    c = SmartBotCard();
                    //Find the nearest boardspace on the bot side that can play
                    boardSpaceCounter2 = boardSpaceCounter2 - 1;
                    //If the board counter becomes less than 0, execute an aggressive move
                    if (boardSpaceCounter2 < 0)
                    {
                        boardSpaceCounter = boardSpaceCounter - 1;
                        b = boardSpaces[boardSpaceCounter];
                    }
                    else
                    {
                        //If the board space card type is that of a player, execute the move
                        if (boardSpaces[boardSpaceCounter2].Card != null)
                        {
                            //If the card type is right, make that the boardspace
                            if (boardSpaces[boardSpaceCounter2].Card.CardType == Constant.playerCardType)
                            {
                                b = boardSpaces[boardSpaceCounter2];
                            }
                            else
                                continue;
                        }
                        else
                            continue;
                    }
                }
                else
                {
                    //Error message
                    if (Hand.Cards == null)
                    {
                        MessageBox.Show("The bot has run out of cards.");
                    }

                    //Randomly select a card from the hand
                    c = Hand.Cards[random.Next(0, Hand.Cards.Count)];
                    //Randomly select a boardsquare
                    b = boardSpaces[random.Next(0, boardSpaces.Count)];
                }
               
                //Check if the board has a valid path
                if (b.ValidPath(boardSpaces, false))
                {
                    //Check if there is a card already in place there
                    if (b.Card != null)
                    {
                        //Check that the card is a number card and the hand card is also a card
                        if (b.Card is NumberCard && c is NumberCard)
                        {
                            //Check that the number on the card is less than on the card
                            NumberCard bNumber = (NumberCard)b.Card;
                            NumberCard cNumber = (NumberCard)c;

                            //Check that the number is higher
                            if (cNumber.Number > bNumber.Number)
                            {
                                //Place the card on top of that card
                                b.Card = c;
                                //Draw the boardsquare again
                                b.Draw(paper);
                                //Increase the counter by 1
                                botMoveCounter++;
                                //Reset the board counter
                                boardSpaceCounter = boardSpaces.Count;
                                boardSpaceCounter2 = 0;
                                //Remove the card from the hand
                                Hand.Cards.Remove(c);
                                //Check if there is a winning path
                                if (gamePage.CheckWinningPath(b, boardSpaces, winningBotCounter))
                                {
                                    MessageBox.Show("The robot has won.");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        //Check if the board is on the bot's side for more checks
                        if (b.Y < Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2))
                        {
                            foreach (BoardSpace board in boardSpaces)
                            {
                                //Check if it is next to a numbered card 
                                if (b.IsNextToNumberCard(board))
                                {
                                    //Place the card on top of that card
                                    b.Card = c;
                                    //Draw the boardsquare again
                                    b.Draw(paper);
                                    //Increase the counter by 1
                                    botMoveCounter++;
                                    //Reset the board counter
                                    boardSpaceCounter = boardSpaces.Count;
                                    boardSpaceCounter2 = 0;
                                    //Remove the card from the hand
                                    Hand.Cards.Remove(c);
                                    //Check to see if the robot has won
                                    if (gamePage.CheckWinningPath(b, boardSpaces, winningBotCounter)) 
                                    {
                                        MessageBox.Show("The robot has won.");
                                        return;
                                    }
                                }
                            }
                        }
                        else //Not necessary to check for whether it is a number because ValidPaths does that already
                        {
                            //Place the card on top of that card
                            b.Card = c;
                            //Draw the boardsquare again
                            b.Draw(paper);
                            //Increase the counter by 1
                            botMoveCounter++;
                            //Reset the board counter
                            boardSpaceCounter = boardSpaces.Count;
                            boardSpaceCounter2 = 0;
                            //Remove the card from the hand
                            Hand.Cards.Remove(c);
                            //Check if there is a winning path
                            if (gamePage.CheckWinningPath(b, boardSpaces, winningBotCounter)) 
                            {
                                MessageBox.Show("The robot has won.");
                                return;
                            }
                        }
                    }
                }
            }

            //Remove the first obstacle that it can find
            foreach (BoardSpace bspace in boardSpaces)
            {
                //Check that it is a temporary boulder of the right type
                if (bspace.Card is TemporaryBoulder && bspace.Card.CardType != Constant.botCardType)
                {
                    TemporaryBoulder tempb = (TemporaryBoulder)bspace.Card;

                    //Subtract one from the stack size
                    tempb.StackSize--;
                    //Redraw the card on the picturebox
                    tempb.Draw(paper);

                    //If the stack size reaches 0
                    if (tempb.StackSize == 0)
                    {
                        //Find the boardcard that the boulder belongs to
                        foreach (BoardSpace board in boardSpaces)
                        {
                            if (board.Card == tempb)
                            {
                                //Replace it with a player card  
                                board.Card = new NumberCard(board.X, board.Y, 0, Constant.playerCardType);
                                //Draw the boardsquare again
                                board.Draw(paper);
                                board.Card.Selected = false;
                                return;
                            }
                        }
                    }
                    return;
                }
            }
            //Replenish the hand
            Hand.DealHand(Deck);
        }

        /// <summary>
        /// Creates a bot move that chooses a card intelligently from the hand.
        /// </summary>
        private Card SmartBotCard()
        {
            int numberHolder = 0;
            Card card = null;

            //Check that the bot has cards in its hand
            if (Hand.Cards != null)
            {
                //Bot will play any obstacles if it has any
                foreach (Card c in Hand.Cards)
                {
                    //Check if the card is a boulder
                    if (c is TemporaryBoulder || c is PermanentBoulder)
                    {
                        return c;
                    }
                }

                //Bot will then play it's highest numbers first
                foreach (Card c in Hand.Cards)
                {
                    //Check if it is a number card
                    if (c is NumberCard)
                    {
                        NumberCard numberc = (NumberCard)c;

                        //Check if the number of the card is greater than the current
                        //highest one 
                        if (numberc.Number > numberHolder)
                        {
                            //Make this the new number holder
                            numberHolder = numberc.Number;
                            //Make the card the numberc one
                            card = c;
                        }
                    }
                }

                return card;
                
            }
            //Error message
            else
            {
                MessageBox.Show("There are no cards left in the bot's hand.");
                return null;
            }

            
        }

        /// <summary>
        /// Draws the bot's hand on the graphics paper
        /// </summary>
        /// <param name="paper">Graphics paper</param>
        public void DrawBotHand(Graphics paper)
        {
            //Initial location of the cards
            int x = Constant.CARD_XGAP;
            int y = Constant.CARD_YGAP;

            //Change the colour of the brush to silver
            Constant.brushBackground.Color = Color.Silver;
            Constant.penOutline.Color = Color.Black;

            //Draw the empty and meaningless deck 
            if (Deck.Cards.Count > 0)
            {
                //Draw the deck as a silver rectangle
                paper.FillRectangle(Constant.brushBackground, x, y, Constant.CARD_SIZE, Constant.CARD_SIZE);
                paper.DrawRectangle(Constant.penOutline, x, y, Constant.CARD_SIZE, Constant.CARD_SIZE);
                x += Constant.CARD_SIZE + Constant.CARD_XGAP;
            }

            //Go through the list of cards in the list
            foreach (Card c in Hand.Cards)
            {
                //Check if there are any cards
                if (c == null)
                {
                    return;
                }
                //Draw the cards as only a silver background
                paper.FillRectangle(Constant.brushBackground, x, y, Constant.CARD_SIZE, Constant.CARD_SIZE);
                paper.DrawRectangle(Constant.penOutline, x, y, Constant.CARD_SIZE, Constant.CARD_SIZE);
                //Change the x position of the cards
                x += Constant.CARD_SIZE + Constant.CARD_XGAP;
            }
        }


    }
}
