using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2.Models
{
    public class NPC
    {
        public Hand Hand { get; }
        public bool HasHit { get; private set; }
        public bool HasStand { get; private set; }

        public NPC()
        {
            Hand = new Hand();
            HasHit = false;
            HasStand = false;
        }

        // Method to add a card to the NPC's hand
        public void AddCard(Card card)
        {
            Hand.AddCard(card);
        }

        // NPC logic
        public bool ShouldHit(Card dealerCard)
        {
            return Hand.TotalValue() <= 14;
        }

        // Method to check if the NPC has busted
        public bool CheckBusted()
        {
            return Hand.TotalValue() > 21;
        }

        // Method to set the NPC as hitting
        public void Hit()
        {
            HasHit = true;
        }

        // Method to set the NPC as standing
        public void Stand()
        {
            HasStand = true;
        }
    }
}
