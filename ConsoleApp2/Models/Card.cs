using System;


namespace ConsoleApp2.Models
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

    public class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        public int GetValue()
        {
            if (Rank == Rank.Ace)
                return 11; // Ace can be 1 or 11, defaulting to 11 here
            else if (Rank >= Rank.Ten)
                return 10;
            else
                return (int)Rank;
        }
    }
}