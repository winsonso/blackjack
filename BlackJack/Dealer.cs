using System;
using System.Collections.Generic;


namespace BlackJack
{
    class Dealer:PlayerBase
    {
        public Dealer()
        {
            this.handCards = new List<Card>(5);
        }

        public void ShowOneCard()
        {
            Console.Write("Dealer's face up card:  {0}\n", handCards[0].ToString());
        }
        public new void ShowCards()
        {
            Console.Write("Dealer: ");
            foreach (Card card in handCards)
            {
                Console.Write("{0}, ", card.ToString());
            }
            Console.Write("({0})", Score);
            Console.WriteLine();
        }
    }
}
