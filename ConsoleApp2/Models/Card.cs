using System;
using System.Collections.Generic;


namespace ConsoleApp2.Models
{
    public class Card
    {
        public enum Suit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public enum Rank
        {
            Ace = 1,
            Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Jack, Queen, King
        }

        public Suit CardSuit { get; }
        public Rank CardRank { get; }

        public Card(Suit suit, Rank rank)
        {
            CardSuit = suit;
            CardRank = rank;
        }

        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }

        public bool IsFaceUp { get; set; }

        public int GetValue()
        {
            if (CardRank == Rank.Ace)
                return 11; // Ace can be 1 or 11, defaulting to 11 here
            else if (CardRank >= Rank.Ten)
                return 10;
            else
                return (int)CardRank;
        }
    }
}
