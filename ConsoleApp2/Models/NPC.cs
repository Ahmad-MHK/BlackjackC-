using System;

namespace ConsoleApp2.Models
{
    public class NPC
    {
        private Hand hand;
        private ShuffleDecks shuffleDecks;

        public NPC(ShuffleDecks shuffleDecks)
        {
            hand = new Hand();
            this.shuffleDecks = shuffleDecks;
        }

        public void PlayTurn()
        {
            while (hand.GetTotalValue() < 17)
            {
                Card newCard = shuffleDecks.DealCard();
                hand.AddCard(newCard);
            }
        }

        public void ShowHand()
        {
            hand.ShowHand(false); // Show NPC's hand without revealing face down card
        }

        public bool CheckBust()
        {
            return hand.GetTotalValue() > 21;
        }

        public Hand GetHand()
        {
            return hand;
        }
    }
}