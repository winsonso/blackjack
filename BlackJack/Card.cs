
namespace BlackJack
{
    public enum CardRank
    {
        Ace = 1,
        Deuce = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public enum CardSuit
    {
        Hearts = 0,
        Clubs = 1,
        Diamonds = 2,
        Spades = 3
    }
    class Card
    {
        private CardSuit suit;
        private CardRank rank;
        private int valueScore;
        //Non-Default Constructor
        public Card(CardSuit suit, CardRank rank)
        {
            this.suit = suit;
            this.rank = rank;
            if ((int)rank > 10)
            {
                this.valueScore = 10;
            }
            else if ((int)rank == 1)
            {
                this.valueScore = 11;
            }
            else
            {
                this.valueScore = (int)rank;
            }
        }
        public CardSuit Suit
        {
            get
            {
                return this.suit;
            }
        }

        public CardRank Rank
        {
            get
            {
                return this.rank;
            }
        }

        public int ValueScore
        {
            get
            {
                return this.valueScore;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:({1})", this.rank, (char)((int)suit +3));
        }
    }
}
