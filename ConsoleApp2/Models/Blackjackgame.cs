using System;

namespace ConsoleApp2.Models
{
    public class BlackjackGame
    {
        private Dealer dealer;
        private NPC npc;
        private Shoe shoe;

        public BlackjackGame(int numberOfDecks)
        {
            dealer = new Dealer(numberOfDecks);
            shoe = new Shoe(numberOfDecks);
            npc = new NPC();
        }

        public void StartGame()
        {

            bool invalidChoice = false;
            int choice;

            while (true)
            {
                Console.WriteLine("A.Dealer Chose 1 or 2:");
                Console.WriteLine("1. Shuffle");
                Console.WriteLine("2. Deal Cards");

                choice = GetChoice();
                if (choice == 1)
                {
                    Console.WriteLine("Shuffle done. Next.");
                    shoe.Shuffle();
                    break;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Wrong choice u need to shuffle first.");
                    continue; 
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                    continue; // Restart the loop if choice is invalid
                }
            }


            while (true)
            { 
                Console.WriteLine("B.Dealer Chose 1 or 2:");
                Console.WriteLine("1. Shuffle");
                Console.WriteLine("2. Deal Cards");

                choice = GetChoice();
                if (choice == 1)
                {
                    Console.WriteLine("Wrong choice, you just shuffled the cards. Please try again.");

                }
                else if (choice == 2)
                {
                    Console.WriteLine("Good Job. Next.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
                }
            }

            while (true)
            {

                Console.WriteLine("C.Dealer Chose 1 or 2:");
                Console.WriteLine("1. Deal Cards from Left");
                Console.WriteLine("2. Deal Cards from Right");

                choice = GetChoice();
                if (choice == 2)
                {
                    Console.WriteLine("Wrong choice, you deal from left. Please try again.");
                    continue;
                }
                else if (choice == 1)
                {
                    Console.WriteLine("Good Job. Next.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                    continue;
                }

            }
            //I need to Deal Cards to NPC
            Card card = shoe.DealCard();
            npc.AddCard(card);
            npc.AddCard(card);

            // Deal a card to Dealer
            dealer.DealInitialCards();

            //NPc logic
            while (true)
            {
                if (npc.Hand.TotalValue() <= 14)
                {
                    npc.Hit();
                    Console.WriteLine(npc.Hand.TotalValue());
                    Console.WriteLine("npc has hit");
                    break ;
                }
                else if (npc.Hand.TotalValue() >= 14)
                {
                    npc.Stand();
                    Console.WriteLine("npc Stand");
                    Console.WriteLine(npc.Hand.TotalValue());
                    break;
                }
                else { }
            }

            if (npc.CheckBusted())
            {
                Console.WriteLine("NPC has Busted" + npc.Hand.TotalValue());
                Environment.Exit(0);
            } else { }

            //NPC logic

            while (true)
            {
                Console.WriteLine("NPC's total card: " + npc.Hand.TotalValue());
                Console.WriteLine("Dealer total Card: " + dealer.Hand.TotalValue());
                Console.WriteLine("D.Dealer Choose 1, 2, or 3:");
                Console.WriteLine("1. Hit");
                Console.WriteLine("2. Stand");
                Console.WriteLine("3. Reveal Face Down");

                choice = GetChoice();
                if (choice == 3)
                {
                    Console.WriteLine("Revealing face-down card...");
                    dealer.RevealFaceDown();
                    Console.WriteLine(dealer.Hand.TotalValue());
                    Console.WriteLine("Good Job. Next.");
                    break;
                }
                else if (choice == 1 || choice == 2)
                {
                    Console.WriteLine("Wrong choice. Please try again.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                    continue;
                }
            }

            if (npc.Hand.HasBlackjack())
            {
                Console.WriteLine("NPC has BlackJack.");

                if (dealer.Hand.TotalValue() <= npc.Hand.TotalValue())
                {
                    Console.WriteLine("the NPC win");
                    Console.WriteLine("Dealer has " + dealer.Hand.TotalValue());
                    Console.WriteLine("Npc has " + npc.Hand.TotalValue());
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("No one win everyone has blackjack");
                    Console.WriteLine("Dealer has " + dealer.Hand.TotalValue());
                    Console.WriteLine("NPC has " + npc.Hand.TotalValue());
                    Environment.Exit(0);
                }

            }


            Console.WriteLine("Now the face down card gets revealed.");

            while (true)
            {
                Console.WriteLine("Dealer Cards are: " + dealer.Hand.TotalValue());
                Console.WriteLine("E.Dealer choose 1 or 2:");
                Console.WriteLine("1. Hit");
                Console.WriteLine("2. Stand");

                choice = GetChoice();
                if (choice == 1 && dealer.Hand.TotalValue() < 17)
                {
                    Console.WriteLine("Good choice. This can be repeated until the total value is over 17.");
                    dealer.Hit();

                    if (dealer.CheckBusted())
                    {
                        Console.WriteLine("Dealer has busted!");
                        Console.WriteLine("NPC win!");
                        Console.WriteLine("Dealer hand :" + dealer.Hand.TotalValue());
                        Environment.Exit(0);
                        return;
                    } else { continue; }
                }
                else if (choice == 1 && dealer.Hand.TotalValue() >= 17)
                {
                    Console.WriteLine("Wrong choice. Total value is over 17.");
                    invalidChoice = true;
                } 
                else if (choice == 2 && dealer.Hand.TotalValue() < 17)
                {
                    Console.WriteLine("Wrong choice. Total value is under 17.");
                    invalidChoice = true;
                }
                else if (choice == 2)
                {
                    if (dealer.Hand.HasBlackjack())
                    {
                        Console.WriteLine("Dealer has BlackJack.");
                        Environment.Exit(0);
                    }
                    else if (dealer.Hand.TotalValue() <= npc.Hand.TotalValue())
                    {
                        Console.WriteLine("the NPC win");
                        Console.WriteLine("Dealer has " + dealer.Hand.TotalValue());
                        Console.WriteLine("Npc has " + npc.Hand.TotalValue());
                    }
                    else
                    {
                        Console.WriteLine("dealer win");
                        Console.WriteLine("Dealer has " + dealer.Hand.TotalValue());
                        Console.WriteLine("NPC has " + npc.Hand.TotalValue());
                    }
                    break;
                }
                else 
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                    continue;
                }


                if (invalidChoice)
                {
                    Console.WriteLine("Dealer, you made an invalid choice. Please choose again.");
                    invalidChoice = false; // Reset the flag
                }
            }


            Console.WriteLine("Game end.");
        }

        private int GetChoice()
        {
            while (true)
            {
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3))
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
                else
                {
                    return choice;
                }
            }
        }
    }
}
