using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker {
    public class CardToPic {
        System.Drawing.Bitmap z;
        public CardToPic(String name) {
            switch (name.ToString()) {
                case "Two of Spades":
                    z = global::Poker.Properties.Resources._2S;
                    break;
                case "Three of Spades":
                    z = global::Poker.Properties.Resources._3S;
                    break;
                case "Four of Spades":
                    z = global::Poker.Properties.Resources._4S;
                    break;
                case "Five of Spades":
                    z = global::Poker.Properties.Resources._5S;
                    break;
                case "Six of Spades":
                    z = global::Poker.Properties.Resources._6S;
                    break;
                case "Seven of Spades":
                    z = global::Poker.Properties.Resources._7S;
                    break;
                case "Eight of Spades":
                    z = global::Poker.Properties.Resources._8S;
                    break;
                case "Nine of Spades":
                    z = global::Poker.Properties.Resources._9S;
                    break;
                case "Ten of Spades":
                    z = global::Poker.Properties.Resources._10S;
                    break;
                case "J of Spades":
                    z = global::Poker.Properties.Resources.JS;
                    break;
                case "Q of Spades":
                    z = global::Poker.Properties.Resources.QS;
                    break;
                case "K of Spades":
                    z = global::Poker.Properties.Resources.KS;
                    break;
                case "A of Spades":
                    z = global::Poker.Properties.Resources.AS;
                    break;
                case "Two of Hearts":
                    z = global::Poker.Properties.Resources._2H;
                    break;
                case "Three of Hearts":
                    z = global::Poker.Properties.Resources._3H;
                    break;
                case "Four of Hearts":
                    z = global::Poker.Properties.Resources._4H;
                    break;
                case "Five of Hearts":
                    z = global::Poker.Properties.Resources._5H;
                    break;
                case "Six of Hearts":
                    z = global::Poker.Properties.Resources._6H;
                    break;
                case "Seven of Hearts":
                    z = global::Poker.Properties.Resources._7H;
                    break;
                case "Eight of Hearts":
                    z = global::Poker.Properties.Resources._8H;
                    break;
                case "Nine of Hearts":
                    z = global::Poker.Properties.Resources._9H;
                    break;
                case "Ten of Hearts":
                    z = global::Poker.Properties.Resources._10H;
                    break;
                case "J of Hearts":
                    z = global::Poker.Properties.Resources.JH;
                    break;
                case "Q of Hearts":
                    z = global::Poker.Properties.Resources.QH;
                    break;
                case "K of Hearts":
                    z = global::Poker.Properties.Resources.KH;
                    break;
                case "A of Hearts":
                    z = global::Poker.Properties.Resources.AH;
                    break;
                case "Two of Diamonds":
                    z = global::Poker.Properties.Resources._2D;
                    break;
                case "Three of Diamonds":
                    z = global::Poker.Properties.Resources._3D;
                    break;
                case "Four of Diamonds":
                    z = global::Poker.Properties.Resources._4D;
                    break;
                case "Five of Diamonds":
                    z = global::Poker.Properties.Resources._5D;
                    break;
                case "Six of Diamonds":
                    z = global::Poker.Properties.Resources._6D;
                    break;
                case "Seven of Diamonds":
                    z = global::Poker.Properties.Resources._7D;
                    break;
                case "Eight of Diamonds":
                    z = global::Poker.Properties.Resources._8D;
                    break;
                case "Nine of Diamonds":
                    z = global::Poker.Properties.Resources._9D;
                    break;
                case "Ten of Diamonds":
                    z = global::Poker.Properties.Resources._10D;
                    break;
                case "J of Diamonds":
                    z = global::Poker.Properties.Resources.JD;
                    break;
                case "Q of Diamonds":
                    z = global::Poker.Properties.Resources.QD;
                    break;
                case "K of Diamonds":
                    z = global::Poker.Properties.Resources.KD;
                    break;
                case "A of Diamonds":
                    z = global::Poker.Properties.Resources.AD;
                    break;
                case "Two of Clubs":
                    z = global::Poker.Properties.Resources._2C;
                    break;
                case "Three of Clubs":
                    z = global::Poker.Properties.Resources._3C;
                    break;
                case "Four of Clubs":
                    z = global::Poker.Properties.Resources._4C;
                    break;
                case "Five of Clubs":
                    z = global::Poker.Properties.Resources._5C;
                    break;
                case "Six of Clubs":
                    z = global::Poker.Properties.Resources._6C;
                    break;
                case "Seven of Clubs":
                    z = global::Poker.Properties.Resources._7C;
                    break;
                case "Eight of Clubs":
                    z = global::Poker.Properties.Resources._8C;
                    break;
                case "Nine of Clubs":
                    z = global::Poker.Properties.Resources._9C;
                    break;
                case "Ten of Clubs":
                    z = global::Poker.Properties.Resources._10C;
                    break;
                case "J of Clubs":
                    z = global::Poker.Properties.Resources.JC;
                    break;
                case "Q of Clubs":
                    z = global::Poker.Properties.Resources.QC;
                    break;
                case "K of Clubs":
                    z = global::Poker.Properties.Resources.KC;
                    break;
                case "A of Clubs":
                    z = global::Poker.Properties.Resources.AC;
                    break;
                default:
                    z = global::Poker.Properties.Resources.back;
                    break;
            }
        }

        public System.Drawing.Bitmap getPic()
        {
            return z;
        }
    }
}
