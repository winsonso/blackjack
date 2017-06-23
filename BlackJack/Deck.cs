using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    class Deck
    {
        private Queue<Card> deckOfCards;
        private List<int> cardsAsInt;

        Random generator = new Random();

        public void Shuffle()
        {
            deckOfCards = new Queue<Card>();
            GenerateCardsAsInt();
            for (int i = 51; i >= 0; i--)
            {
                int index = generator.Next(0, i);
                int temp = cardsAsInt[i];
                cardsAsInt[i] = cardsAsInt[index];
                cardsAsInt[index] = temp;
            }
            FillDeck();
        }

        private void GenerateCardsAsInt()
        {
            cardsAsInt = new List<int>();
            for (int i = 0; i < 52; i++)
            {
                cardsAsInt.Add(i);
            }
        }

        private void FillDeck()
        {
            for (int i = 0; i < cardsAsInt.Count(); i++)
            {
                CardSuit suit = (CardSuit)(cardsAsInt[i] % 4);
                CardRank value = (CardRank)(cardsAsInt[i] % 13+1);
                deckOfCards.Enqueue(new Card(suit, value));
            }
        }

        public Card DealCard()
        {
            return deckOfCards.Dequeue();
        }

    }
}
