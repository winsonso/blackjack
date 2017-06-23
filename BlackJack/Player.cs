using System;
using System.Collections.Generic;


namespace BlackJack
{
    class Player:PlayerBase
    {
        private double blance;
        private double bet;

        public Player(double newblance) {
            this.blance = newblance;
            this.handCards = new List<Card>(5);
        }

        public double Blance{
            get
            {
                return blance;
            }
            set
            {
                blance = value;
            }
        }

        public double Bet {
            get
            {
                return bet;
            }
            set
            {
                bet = value;
            }
        }

        public new void ShowCards()
        {
            Console.Write("Cards on your hand: \t");
            foreach (Card card in handCards)
            {
                Console.Write("{0}, ", card.ToString());
            }
            Console.Write("({0})", Score);
            Console.WriteLine();
        }

    }
}
