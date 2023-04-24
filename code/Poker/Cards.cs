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

    public enum HandRank
    {
        HighCard = 0,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    };

    public class Card : IComparable<Card> {

        private Suit suit;
        private Value value;

        public Card(Value value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public int CompareTo(Card other)
        {
            if (other == null) { 
                return 1; 
            }

            if (this.value > other.value)
            {
                return 1; 
            }
            else if (this.value < other.value)
            {
                return -1; 
            }
            else
            {
                return 0; 
            }
        }

        public Suit getSuit() { 
            return suit; 
        }
        public Value getValue() { 
            return value; 
        }


        public override string ToString()
        {
            return value + " of " + suit;
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

    public class PokerRank {
        private List<Card> cards;
        public HandRank rank;

        public PokerRank(List<Card> cards)
        {
            this.cards = cards;
            this.rank = HandRank.HighCard;
        }

        public void Evaluate()
        {
            cards.Sort();
            if (IsRoyalFlush())
            {
                rank = HandRank.RoyalFlush;
            }
            else if (IsStraightFlush())
            {
                rank = HandRank.StraightFlush;
            }
            else if (IsFourOfAKind())
            {
                rank = HandRank.FourOfAKind;
            }
            else if (IsFullHouse())
            {
                rank = HandRank.FullHouse;
            }
            else if (IsFlush())
            {
                rank = HandRank.Flush;
            }
            else if (IsStraight())
            {
                rank = HandRank.Straight;
            }
            else if (IsThreeOfAKind())
            {
                rank = HandRank.ThreeOfAKind;
            }
            else if (IsTwoPair())
            {
                rank = HandRank.TwoPair;
            }
            else if (IsPair())
            {
                rank = HandRank.Pair;
            }
        }

        private bool IsRoyalFlush()
        {
            if (IsStraightFlush())
            {
                if (cards[0].getValue() == Value.A && cards[4].getValue() == Value.K)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsFourOfAKind()
        {
            if (cards[0].getValue() == cards[1].getValue() && cards[0].getValue() == cards[2].getValue() && cards[0].getValue() == cards[3].getValue())
            {
                return true;
            }
            else if (cards[1].getValue() == cards[2].getValue() && cards[1].getValue() == cards[3].getValue() && cards[1].getValue() == cards[4].getValue())
            {
                return true;
            }
            return false;
        }
        private bool IsFullHouse()
        {
            if (cards[0].getValue() == cards[1].getValue() && cards[0].getValue() == cards[2].getValue() && cards[3].getValue() == cards[4].getValue())
            {
                return true;
            }
            else if (cards[0].getValue() == cards[1].getValue() && cards[2].getValue() == cards[3].getValue() && cards[2].getValue() == cards[4].getValue())
            {
                return true;
            }
            return false;
        }
        private bool IsFlush()
        {
            if (cards[0].getSuit() == cards[1].getSuit() && cards[0].getSuit() == cards[2].getSuit() && cards[0].getSuit() == cards[3].getSuit() && cards[0].getSuit() == cards[4].getSuit())
            {
                return true;
            }
            return false;
        }
        private bool IsStraight() {
            cards.Sort();
            if (cards[0].getValue() == cards[1].getValue() - 1 && cards[0].getValue() == cards[2].getValue() - 2 && cards[0].getValue() == cards[3].getValue() - 3 && cards[0].getValue() == cards[4].getValue() - 4)
            {
                return true;
            }
            if (cards[0].getValue() == Value.A && cards[4].getValue() == Value.Five &&
                cards[4].getValue() == Value.Four && cards[3].getValue() == Value.Three &&
                cards[2].getValue() == Value.Two)
            {
                return true;
            }
            if (cards[0].getValue() == Value.A && cards[1].getValue() == Value.Ten &&
                cards[2].getValue() == Value.J && cards[3].getValue() == Value.Q &&
                cards[4].getValue() == Value.K)
            {
                return true;
            }
            return false;
        }
        private bool IsThreeOfAKind()
        {
            if (cards[0].getValue() == cards[1].getValue() && cards[0].getValue() == cards[2].getValue())
            {
                return true;
            }
            else if (cards[1].getValue() == cards[2].getValue() && cards[1].getValue() == cards[3].getValue())
            {
                return true;
            }
            else if (cards[2].getValue() == cards[3].getValue() && cards[2].getValue() == cards[4].getValue())
            {
                return true;
            }
            return false;
        }
        private bool IsTwoPair()
        {
            if (cards[0].getValue() == cards[1].getValue() && cards[2].getValue() == cards[3].getValue())
            {
                return true;
            }
            else if (cards[0].getValue() == cards[1].getValue() && cards[3].getValue() == cards[4].getValue())
            {
                return true;
            }
            else if (cards[1].getValue() == cards[2].getValue() && cards[3].getValue() == cards[4].getValue())
            {
                return true;
            }
            return false;
        }
        private bool IsPair()
        {
            cards.Sort();
            if (cards[0].getValue() == cards[1].getValue())
            {
                return true;
            }
            else if (cards[1].getValue() == cards[2].getValue())
            {
                return true;
            }
            else if (cards[2].getValue() == cards[3].getValue())
            {
                return true;
            }
            else if (cards[3].getValue() == cards[4].getValue())
            {
                return true;
            }
            return false;
        }
        private bool IsStraightFlush()
        {
            if (IsStraight() && IsFlush())
            {
                return true;
            }
            return false;
        }
        public String getRank()
        {
            return rank.ToString();
        }
    }
}
