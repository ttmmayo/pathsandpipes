using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes_and_Paths_Game
{
    public class Constant
    {
        public const int CARD_SIZE = 40; //Gives the width/height of the card
        public const int BOARD_ROWS = 10; //Number of rows on the board
        public const int BOARD_COLUMNS = 8; //Number of columns on the board
        public const int PATH_WIDTH = 5; //Size of the pipe/path
        public const int NUMBER_LOCATION = 2; //Location of the number on the card
        public const int CARD_YGAP = 10; //Y gap between cards
        public const int CARD_XGAP = 10; //X gap between cards
        public const int WIN_LENGTH = 5; //Number of cards needed to win
        public const int BOULDER_RADIUS = 25; //Radius of the boulder
        public const int CARD_TURN_LIMIT = 2; //The number of cards executed each turn
        public const int BOULDER_TURN_LIMIT = 1; //The number of boulders that are removed each turn
        public const int GAMEPAGE_ORIGINAL_SIZE = 650; //The original size of the gamepage
        public enum CARD_TYPE {Path, Pipe}; //The type of card
        public const CARD_TYPE playerCardType = CARD_TYPE.Path; //Sets the player's card type
        public const CARD_TYPE botCardType = CARD_TYPE.Pipe; //Sets the bot's card type
        public static Pen penOutline = new Pen(Color.Black, 2);
        public static SolidBrush brushBackground = new SolidBrush(Color.Gray);
        public static SolidBrush brushPath = new SolidBrush(Color.SaddleBrown);
        public static SolidBrush brushPermanentBoulder = new SolidBrush(Color.Gray);
        public static SolidBrush brushTemporaryBoulder = new SolidBrush(Color.Blue);
    }
}
