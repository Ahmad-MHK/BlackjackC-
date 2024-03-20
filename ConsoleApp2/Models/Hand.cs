using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models
{
    public class Hand
    {
        private List<Card> cards;
        private int totalValue;

        public Hand()
        {
            cards = new List<Card>();
            totalValue = 0;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
            totalValue += card.GetValue();
        }

        public void ClearHand()
        {
            cards.Clear();
            totalValue = 0;
        }

        public void ShowHand(bool isDealer)
        {
            if (isDealer)
            {
                Console.WriteLine("Dealer's Hand:");
                Console.WriteLine("Face Down Card");
                foreach (var card in cards.Skip(1)) // Skip first card (face down)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine($"Total Value: {totalValue - cards[0].GetValue()}");
            }
            else
            {
                Console.WriteLine("NPC's Hand:");
                foreach (var card in cards)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine($"Total Value: {totalValue}");
            }
        }

        public int GetTotalValue(bool isDealer)
        {
            if (isDealer)
            {
                return totalValue - cards[0].GetValue(); // Return total value without face down card
            }
            else
            {
                return totalValue;
            }
        }

        public List<Card> GetCards()
        {
            return cards;
        }
    }
}
