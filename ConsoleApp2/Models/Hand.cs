using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2.Models
{
    public class Hand
    {
        private List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        // Method to add a card to the hand
        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        // Method to calculate the total value of the hand
        public int TotalValue()
        {
            int totalValue = 0;
            int numAces = 0;

            foreach (var card in cards)
            {
                totalValue += card.GetValue();
                if (card.Rank == Rank.Ace)
                {
                    numAces++;
                }
            }

            // Adjust total value for aces
            while (totalValue > 21 && numAces > 0)
            {
                totalValue -= 10;
                numAces--;
            }

            return totalValue;
        }

        // Method to check if the hand has blackjack (21)
        public bool HasBlackjack()
        {
            return TotalValue() == 21 && cards.Count == 2;
        }

        // Method to clear the hand
        public void Clear()
        {
            cards.Clear();
        }

        // Override ToString method to display the hand
        public override string ToString()
        {
            return string.Join(", ", cards.Select(card => card.ToString()));
        }
    }
}
