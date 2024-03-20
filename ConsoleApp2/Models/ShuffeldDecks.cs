using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models
{
	public class ShuffleDecks
	{
		private List<Card> shuffledCards;

		public ShuffleDecks()
		{
			InitializeShuffledCards();
		}

		private void InitializeShuffledCards()
		{
			Decks decks = new Decks();
			shuffledCards = decks.GetCards();
			Shuffle(shuffledCards);
		}

		private void Shuffle(List<Card> cards)
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

		public Card DealCard()
		{
			if (shuffledCards.Count == 0)
			{
				throw new InvalidOperationException("Deck is empty, cannot deal any more cards.");
			}

			Card dealtCard = shuffledCards[shuffledCards.Count - 1];
			shuffledCards.RemoveAt(shuffledCards.Count - 1);
			return dealtCard;
		}
	}
}
