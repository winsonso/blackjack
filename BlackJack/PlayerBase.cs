using System.Collections.Generic;


namespace BlackJack
{
    class PlayerBase
    {
        protected List<Card> handCards;
        protected int score;

        public int Score
        {
            // here is the logic part for calulate the point
            get
            {
                int updateScore = 0;
                int numOfAce = checkForAce();
                foreach (Card card in handCards)
                {
                    updateScore += card.ValueScore;
                    //score = updateScore;
                }
                // if Ace is more than 1, it need to recalulate the points.
                // For example:
                // A,A --> 12 pts
                // A,A,A --> 13 pts
                if (numOfAce == 1 && updateScore > 21)
                    score = updateScore - (11 * numOfAce - numOfAce);
                else if(numOfAce > 1)
                    score = updateScore - (11 * (numOfAce -1) - (numOfAce-1));
                else
                    score = updateScore;
                return score;
            }
        }


        public void ShowCards() {}

        // Checking how many ace in player's hand to calulate how many point it should be.
        private int checkForAce()
        {
            int numOfAce = 0;
            foreach(Card card in handCards)
            {
                if (card.ValueScore == 11)
                {
                    //Console.WriteLine("There is a ACE");
                    numOfAce++;
                }
            }
            return numOfAce;
        }
        public void DrawCard(Card card)
        {
            handCards.Add(card);
        }

        public void ClearHandCards()
        {
            handCards.Clear();
        }
    }
}
