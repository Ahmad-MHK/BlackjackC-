namespace ConsoleApp2.Models
{
    public class Bet
    {
        private int betAmount = 50;

        public void PlaceBet(Chips chips, string npc)
        {
            try
            {
                chips.RemoveChips(betAmount, npc);
                Console.WriteLine($"{npc} placed a bet of ${betAmount}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
