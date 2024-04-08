using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models
{
	public class Deck
	{
		private List<Card> cards;

		public Deck()
		{
			cards = new List<Card>();
			InitializeDeck();
		}

		private void InitializeDeck()
		{
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
