namespace ConsoleApp2
{
    internal class Card
    {
        public enum Suit
        {
            Club = 1,
            Diamond = 2,
            Heart = 3,
            Spades = 4,
        }

        public enum Rank
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        public Suit suit;
        public Rank rank;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        // Method to get the value of the card in a typical card game scenario
        public int GetValue()
        {
            // In a simple scenario, you might want to return the rank as the value
            return (int)rank;
        }

        // Override ToString() method to represent the card as a string
        public override string ToString()
        {
            return $"{rank} of {suit}s";
        }
    }
}
