using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2.Models
{
    public class Shoe
    {
        private List<Deck> decks;
        private List<Card> shuffledCards;
        private int currentIndex;

        public Shoe(int numberOfDecks)
        {
            decks = new List<Deck>();
            shuffledCards = new List<Card>();
            currentIndex = 0;

            for (int i = 0; i < numberOfDecks; i++)
            {
                decks.Add(new Deck());
            }

            Shuffle();
        }

        private void Shuffle()
        {
            shuffledCards.Clear();
            Random rng = new Random();

            foreach (Deck deck in decks)
            {
                shuffledCards.AddRange(deck.GetCards());
            }

            shuffledCards = shuffledCards.OrderBy(card => rng.Next()).ToList();
        }

        public Card DealCard()
        {
            if (currentIndex >= shuffledCards.Count)
            {
                throw new InvalidOperationException("All cards have been dealt");
            }

            Card dealtCard = shuffledCards[currentIndex];
            currentIndex++;
            return dealtCard;
        }
    }
}
