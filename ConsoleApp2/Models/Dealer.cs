using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models
{
    public class Dealer
    {
        private readonly Shoe shoe;

        public Hand Hand { get; }
        public bool HasHit { get; private set; }
        public bool HasStand { get; private set; }

        public Dealer(int numberOfDecks)
        {
            shoe = new Shoe(numberOfDecks);
            Hand = new Hand();
            HasHit = false;
            HasStand = false;
        }

        // Method to deal a card from the shoe
        public Card DealCard()
        {
            return shoe.DealCard();
        }

        // Method to set the dealer as hitting
        public void Hit()
        {
            HasHit = true;
        }

        // Method to set the dealer as standing
        public void Stand()
        {
            HasStand = true;
        }

        // Method to deal the dealer's initial cards, one face-up and one face-down
        public void DealInitialCards()
        {
            Hand.AddCard(DealCard());
            Hand.AddCard(DealCard());
            FaceDown(Hand);
        }

        // Method to flip the dealer's face-down card face-up
        public void RevealFaceDown()
        {
            Hand.GetCards()[0].IsFaceUp = true;
        }

        // Method to check if the dealer has busted
        public bool CheckBusted()
        {
            return Hand.TotalValue() > 21;
        }

        // Method to hide the dealer's face-down card
        private void FaceDown(Hand hand)
        {
            var cards = hand.GetCards();
            if (cards.Count > 0)
            {
                cards[0].IsFaceUp = false;
            }
        }
    }
}
