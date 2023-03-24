using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker {
    public enum Suit {
        Hearts = 0,
        Diamonds,
        Clubs,
        Spades
    };

    public enum Value {
        A = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        J,
        Q,
        K
    };

    public class Card {

        private Suit suit;
        private Value value;

        public Card(Value value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public Suit getSuit() { 
            return suit; 
        }
        public Value getValue() { 
            return value; 
        }


        public override string ToString()
        {
            return "Value: " + value + " Suit: " + suit;
        }
    }

    public class Deck {

        private List<Card> deck;
        private int deckAmount;

        public Deck()
        {
            this.deckAmount = 52;
            this.deck = new List<Card>(deckAmount);

            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    Card c = new Card(v, s);
                    deck.Add(c);
                }
            }
        }


        public Card GetCard(int i)
        {
            if (i < 0 && i >= deckAmount)
            {
                return null;
            }
            return deck[i];
        }

        public Card RemoveCard(int pos)
        {
            if (pos > 0 && pos >= deckAmount)
            {
                return null;
            }

            Card cd_return = GetCard(pos);
            deck.RemoveAt(pos);

            return cd_return;
        }


        public void SwapCard(int a, int b)
        {
            Card cd = GetCard(a);
            deck[a] = GetCard(b);
            deck[b] = cd;

        }

        public void shuffle() { 
            Random random = new Random();

            for (int i = 0; i < deckAmount; i++) {
                int num = random.Next(deckAmount);

                SwapCard(i, num);
            }
        }
    }
}
