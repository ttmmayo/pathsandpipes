using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pipes_and_Paths_Game
{
    public partial class gamePage : Form
    {
        public gamePage()
        {
            InitializeComponent();
        }

        //List of all boardspaces on the board
        List<BoardSpace> boardSpacesList = new List<BoardSpace>();

        //Create new decks for the player and the bot
        Deck playerDeck = new Deck(Constant.playerCardType);
        Deck botDeck = new Deck(Constant.botCardType);

        //Create new hands for the player and the bot
        Hand playerHand;
        Hand botHand;

        //The currently selected card
        Card selected;

        //Creates the new bot
        Bot bot;

        //Holds the counter for the length of the winning path
        int winningCounter = 0;
        //Counter for the number of cards and boulders moved
        int cardCounter = 0;
        int boulderCounter = 0;

        /// <summary>
        /// Draws all the boardspaces in the boardspace list
        /// </summary>
        /// <param name="paper">The graphics object specified</param>
        private void DrawBoardSpacesList(Graphics paper)
        {
            //Goes through each boardspace and draws it on the paper
            foreach (BoardSpace b in boardSpacesList)
            {
                b.Draw(paper);
            }
            //Draws the red half-line
            paper.DrawLine(Pens.Red, 0, Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2), Constant.CARD_SIZE * Constant.BOARD_COLUMNS, Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2));

        }

        /// <summary>
        /// Loads the specified boardspaces into a list and draws them on the board
        /// </summary>
        /// <param name="paper">The specified graphics object</param>
        private void LoadBoardSpaces(Graphics paper)
        {
            //The x and y positions of the boardspaces
            int x = 0;
            int y = 0;

            //For each specified column in the graphics object
            for (int i = 0; i < Constant.BOARD_ROWS; i++)
            {
                //For each specified row in the graphics object
                for (int z = 0; z < Constant.BOARD_COLUMNS; z++)
                {
                    //Add a new boardspace to the list of boardspaces
                    boardSpacesList.Add(new BoardSpace(x, y));
                    //Displace the y-position by the size of a card
                    x += Constant.CARD_SIZE;
                }

                //Resets the y position
                x = 0;
                //Displace the x-position by the size of a card
                y += Constant.CARD_SIZE;
            }
            //Draws each of the boardspaces in the list
            DrawBoardSpacesList(paper);
        }

        /// <summary>
        /// Places the starting card in the correct position
        /// </summary>
        /// <param name="card">The starting card</param>
        /// <param name="paper">The specified graphics object</param>
        private void PlaceStartingCard(NumberCard card, Graphics paper)
        {
            //Loop through the list
            foreach (BoardSpace b in boardSpacesList)
            {
                //Check if it is a player or bot card and then checks if it is on the right side
                if (card.CardType == Constant.playerCardType)
                {
                    if (b.X == Constant.CARD_SIZE * (Constant.BOARD_COLUMNS / 2) && b.Y == Constant.CARD_SIZE * (Constant.BOARD_ROWS * 3 / 4))
                    {
                        //Set the card equal to the one that belongs to the boardspace
                        BoardSpaceCard(b, card);
                    }
                }
                else if (card.CardType == Constant.botCardType)
                {
                    if (b.X == Constant.CARD_SIZE * (Constant.BOARD_COLUMNS / 2) && b.Y == Constant.CARD_SIZE * (Constant.BOARD_ROWS / 4))
                    {
                        //Set the card equal to the one that belongs to the boardspace
                        BoardSpaceCard(b, card);
                    }
                }
            }
                //Draws the card onto the given graphics object
                DrawBoardSpacesList(paper);
        }

        /// <summary>
        /// Changes the selected status of a card
        /// </summary>
        /// <param name="card">The card who has a change in selected status</param>
        private void ChangeSelectedStatus(Card card)
        {
            //If the card is selected
            if (selected == card)
            {
                //Deselect the card
                selected = null;
                card.Selected = false;
            }
            else
            {
                //If something is already selected
                if (selected != null)
                {
                    //Then deselect the currently selected card
                    selected.Selected = false;
                    selected = null;
                }

                //Select the new card
                selected = card;
                card.Selected = true;

            }
        }
        
        /// <summary>
        /// Draws the player's cards on the picture box
        /// </summary>
        private void DrawPlayerCards()
        {
            //Reset the picture boxes
            pictureBoxPlayerCards.Refresh();
            //Redraw the player cards
            playerHand.Draw(pictureBoxPlayerCards.CreateGraphics(), playerDeck);
        }

        /// <summary>
        /// Gets a boardspace and puts the card in the same place
        /// </summary>
        /// <param name="b">the boardspace</param>
        /// <param name="c">the card</param>
        private void BoardSpaceCard(BoardSpace b, Card c)
        {
            //Change the coordinates
            c.X = b.X;
            c.Y = b.Y;
            b.Card = c;
        }

        /// <summary>
        /// Places a player card
        /// </summary>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private void PlacePlayerCard(BoardSpace b, Card c)
        {
            //Checks that it is not null
            if (c == null)
            {
                MessageBox.Show("Please select a card to place.");
                return;
            }
            
            //Set the selected card to be the one that the boardspace has selected
            BoardSpaceCard(b, c);
            //Remove from the list
            playerHand.Cards.Remove(c);
            //Deselect the card
            ChangeSelectedStatus(c);
            //Redraw the card on the picturebox
            b.Draw(pictureBoxBoard.CreateGraphics());
            //Redraw the board
            DrawPlayerCards();
            //Increase the card counter
            cardCounter++;
            //If the cardcounters are high enough, show the end turn button
            if (cardCounter == 2)
            {
                //Set the end turn button to visible
                buttonEndTurn.Visible = true;
            }
            //Check for a winning path
            if (CheckWinningPath(b, boardSpacesList, winningCounter))
            {
                MessageBox.Show("You have just won.");
                buttonEndTurn.Visible = false;
            }
        }

        /// <summary>
        /// Checks for a winning path
        /// </summary>
        /// <param name="b">The last boardspace that was placed</param>
        /// <param name="boardspaces">The list of boardspaces on the board</param>
        /// <param name="winningCounter">The counter for how many places they have in the winning path</param>
        /// <returns></returns>
        public static bool CheckWinningPath(BoardSpace b, List<BoardSpace> boardspaces, int winningCounter)
        {
            //List of winnning squares
            List<BoardSpace> WinningPath = new List<BoardSpace>();

            //Eliminate boards that have already been used in the winning path
            foreach (BoardSpace boardspace in boardspaces)
            {
                if (boardspace != b)
                {
                    WinningPath.Add(boardspace);
                }
            }

            //Check for when it becomes the win length
            if (winningCounter >= Constant.WIN_LENGTH - 1)
            {
                //For each boardspace in the list 
                foreach (BoardSpace bb in boardspaces)
                {
                    //Check that it is next to an numbered card
                    if (b.IsNextToNumberCard(bb))
                    {
                        //Check that it is on the player side
                        if ((bb.Y >= Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2) && bb.Card.CardType == Constant.playerCardType)
                        || (bb.Y < Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2) && bb.Card.CardType == Constant.botCardType))
                        {
                            //Check that it has the correct cardtype
                            if (b.Card.CardType == bb.Card.CardType)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            //Check if the card is a number card and on the right side
            if (b.Card is NumberCard && ((b.Card.CardType == Constant.playerCardType && b.Y < Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2) 
                || (b.Card.CardType == Constant.botCardType && b.Y >= Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2)))))
            {
                foreach (BoardSpace board in WinningPath)
                {
                    //Checks that it is on the opponent's side
                    if ((board.Y < Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2) && b.Card.CardType == Constant.playerCardType) 
                        || (board.Y >= Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2) && b.Card.CardType == Constant.botCardType))
                    {
                        //Checks if it is a number card next to the board
                        if (b.IsNextToNumberCard(board))
                        {
                            //Check that it is the right card type
                            if (board.Card.CardType == b.Card.CardType)
                            {
                                //Check that it is the winning counter
                                winningCounter++;

                                //Check that the next card is part of a winning path
                                if (CheckWinningPath(board, WinningPath, winningCounter))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Executes when a temporary boulder is clicked. Removes one from the stack size
        /// or replaces it with a path/pipe when it reaches 0.
        /// </summary>
        /// <param name="card">The temporary boulder that has been clicked</param>
        private void ClickTempBoulder(Card card)
        {
            TemporaryBoulder tempb = (TemporaryBoulder)card;

            //Subtract one from the stack size
            tempb.StackSize--;
            //Redraw the card on the picturebox
            tempb.Draw(pictureBoxBoard.CreateGraphics());

            //If the stack size reaches 0
            if (tempb.StackSize <= 0)
            {
                //Find the boardcard that the boulder belongs to
                foreach (BoardSpace b in boardSpacesList)
                {
                    if (b.Card == tempb && b.Card.CardType != Constant.playerCardType)
                    {
                        //Replace it with a player card  
                        PlacePlayerCard(b, new NumberCard(b.X, b.Y, 0, Constant.botCardType));
                        //Make sure that selected is off and draw again if so necessary
                        b.Card.Selected = false;
                        b.Card.Draw(pictureBoxBoard.CreateGraphics());
                    }
                }
            }
            //Increases the boulder counter
            boulderCounter++;
        }

        /// <summary>
        /// Determines who has the highest number and who will begin first
        /// </summary>
        /// <param name="playerCard">The starting player card</param>
        /// <param name="botCard">The starting bot card</param>
        private void FirstTurn(NumberCard playerCard, NumberCard botCard)
        {
            //Check who has the higher number of the player and the bot
            if (playerCard.Number >= botCard.Number)
            {
                //Reset the counters
                cardCounter = 0;
                boulderCounter = 0;
            }
            else
            {
                //Let the bot move, then reset the counters
                bot.BotMove(boardSpacesList, pictureBoxBoard.CreateGraphics());
                cardCounter = 0;
                boulderCounter = 0;
            }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            //Closes the form
            this.Close();
        }

        /// <summary>
        /// Loads the initial boardgame spaces and cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBegin_Click(object sender, EventArgs e)
        {
            //Remove the button
            radioButtonSmartBot.Visible = false;

            //Declare the picturebox as a graphics object
            Graphics paper = pictureBoxBoard.CreateGraphics();
            //Load the board spaces onto the board
            LoadBoardSpaces(paper);

            //Loads the two beginning cards
            NumberCard startingCardPlayer = playerDeck.DrawStartingCard();
            NumberCard startingCardBot = botDeck.DrawStartingCard();

            //Load the starting cards onto the board
            PlaceStartingCard(startingCardPlayer, paper);
            PlaceStartingCard(startingCardBot, paper);

            //Initialises the two player hands
            playerHand = new Hand(playerDeck);
            botHand = new Hand(botDeck);

            if (radioButtonSmartBot.Checked)
                bot = new Bot(botDeck, botHand, true);
            else
                bot = new Bot(botDeck, botHand, false);

            //Determines which player goes first
            FirstTurn(startingCardPlayer, startingCardBot);

            //Draws the hand of the player and bot onto the picturebox (and the deck)
            playerHand.Draw(pictureBoxPlayerCards.CreateGraphics(), playerDeck);
            bot.DrawBotHand(pictureBoxBotCards.CreateGraphics());
        }

        /// <summary>
        /// When the player cards picture box is clicked by the user it selects/unselects a card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPlayerCards_MouseClick(object sender, MouseEventArgs e)
        {
            //Go through the list of cards in the player's hand
            foreach (Card c in playerHand.Cards)
            {
                //Check for the first card that the mouse is on
                if (c.IsMouseOn(e.X, e.Y))
                {
                    //Change the selected status of the card
                    ChangeSelectedStatus(c);
                    //Redraws the player hand
                    playerHand.Draw(pictureBoxPlayerCards.CreateGraphics(), playerDeck);
                }
            }
        }

        /// <summary>
        /// Places a card on the board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxBoard_MouseClick(object sender, MouseEventArgs e)
        {
            //Reset the winning counter
            winningCounter = 0;

            //Check if there is a currently selected card
            if (selected != null)
            {
                //Check that only two cards are moved
                if (cardCounter > 1)
                {
                    MessageBox.Show("You can only move two cards per turn.");
                    return;
                }

                //Go through a list of all the boardspaces on the board
                foreach (BoardSpace board in boardSpacesList)
                {
                    //Check if the mouse is on it
                    if (board.IsMouseOn(e.X, e.Y))
                    {
                        //Check whether the board has a valid path 
                        if (board.ValidPath(boardSpacesList, true))
                        {
                            //Check if there is already a card placed there
                            if (board.Card != null)
                            {
                                //If the board card or the selected card are not number cards
                                if (!(board.Card is NumberCard) || !(selected is NumberCard))
                                {
                                    MessageBox.Show("You can only place cards on number cards.");
                                    return;
                                }

                                //Cast to a number card
                                NumberCard boardNumber = (NumberCard)board.Card;
                                NumberCard selectedNumber = (NumberCard)selected;

                                //Check that the number of selected is greater than board.Card
                                if (selectedNumber.Number <= boardNumber.Number)
                                {
                                    MessageBox.Show("The number of the selected card needs to be greater.");
                                    return;
                                }

                                //Place the card on top of the other card
                                PlacePlayerCard(board, selected);
                                return;
                            }

                            //Check if the board is on the player's side
                            if (board.Y >= Constant.CARD_SIZE * (Constant.BOARD_ROWS / 2))
                            {
                                foreach (BoardSpace b in boardSpacesList)
                                {
                                    //Check if the boardspace is next to a number card
                                    if (board.IsNextToNumberCard(b))
                                    {
                                        //Place the card if it has a valid number next to it
                                        PlacePlayerCard(board, selected);
                                        return;
                                    }
                                }
                                MessageBox.Show("The card needs to be placed next to a number card.");
                                return;
                            }

                            //Place the card if it has a valid path
                            PlacePlayerCard(board, selected);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("This is not a valid path.");
                        }
                        return;
                    }
                }
            }
            else
            {
                //For each boardspace on the board
                foreach (BoardSpace b in boardSpacesList)
                {
                    //Check which one the mouse is on
                    if (b.IsMouseOn(e.X, e.Y))
                    {
                        //Check if it is a temporary obstacle
                        if (b.Card is TemporaryBoulder)
                        {
                            //Check that only one boulder has been moved
                            if (boulderCounter > 0)
                            {
                                MessageBox.Show("You can only remove one boulder per turn.");
                                return;
                            }

                            //Method to reduce the stack size of the boulder
                            ClickTempBoulder(b.Card);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Please select a card.");
                            return;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Ends the turn and allows the bot to make a move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            //Reset the counters
            cardCounter = 0;
            boulderCounter = 0;
            //Deal new cards from the deck
            playerHand.DealHand(playerDeck);
            DrawPlayerCards();
            //Make the bot take a turn
            bot.BotMove(boardSpacesList, pictureBoxBoard.CreateGraphics());
            //Make the button invisible again
            buttonEndTurn.Visible = false;
        }

        /// <summary>
        /// Attempt to resize the page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamePage_Resize(object sender, EventArgs e)
        {
            this.Width = this.Height;
            //The scale of which the height and gamepage are changing
            double scale = (this.Width / Constant.GAMEPAGE_ORIGINAL_SIZE);
        }
    }
}
