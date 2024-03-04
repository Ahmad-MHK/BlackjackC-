using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public List<Card> DealHand(int numberOfCards)
        {
            List<Card> hand = new List<Card>();
            if (numberOfCards > cards.Count)
            {
                throw new InvalidOperationException("Not enough cards in the deck to deal.");
            }

            for (int i = 0; i < numberOfCards; i++)
            {
                Card card = cards[0];
                cards.RemoveAt(0);
                hand.Add(card);
            }

            return hand;
        }
    }
}
