namespace ConsoleApp2.Models
{
    public class Chips
    {
        private int leftNPCChips;
        private int rightNPCChips;

        public Chips(int initialChips)
        {
            leftNPCChips = initialChips;
            rightNPCChips = initialChips;
        }

        public int GetLeftNPCChips()
        {
            return leftNPCChips;
        }

        public int GetRightNPCChips()
        {
            return rightNPCChips;
        }

        public void AddChips(int chips, string npc)
        {
            if (npc == "Left NPC")
            {
                leftNPCChips += chips;
            }
            else if (npc == "Right NPC")
            {
                rightNPCChips += chips;
            }
            else
            {
                throw new System.Exception("Invalid NPC name");
            }
        }

        public void RemoveChips(int chips, string npc)
        {
            if (npc == "Left NPC")
            {
                if (leftNPCChips >= chips)
                {
                    leftNPCChips -= chips;
                }
                else
                {
                    throw new System.Exception("Insufficient chips for Left NPC");
                }
            }
            else if (npc == "Right NPC")
            {
                if (rightNPCChips >= chips)
                {
                    rightNPCChips -= chips;
                }
                else
                {
                    throw new System.Exception("Insufficient chips for Right NPC");
                }
            }
            else
            {
                throw new System.Exception("Invalid NPC name");
            }
        }
    }
}
