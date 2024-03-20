using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models
{
    public class Decks
    {
        private List<Card> cards;

        public Decks()
        {
            InitializeDecks();
        }

        private void InitializeDecks()
        {
            cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public List<Card> GetCards()
        {
            return cards;
        }
    }
}
