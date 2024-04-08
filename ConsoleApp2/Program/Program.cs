using System;
using ConsoleApp2

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer(1); // Create a dealer with one deck

            Console.WriteLine("Game Started. Choose 1 or 2:");
            Console.WriteLine("1. Shuffle");
            Console.WriteLine("2. Deal Cards");

            int choice = GetChoice();
            if (choice == 1)
            {
                dealer.Shuffle();
                Console.WriteLine("Shuffle done. Next.");
            }
            else if (choice == 2)
            {
                dealer.DealInitialCards();
                Console.WriteLine("Deal Cards done. Next.");
            }

            while (!dealer.HasStand)
            {
                Console.WriteLine("Dealer Choose 1 or 2:");
                Console.WriteLine("1. Hit");
                Console.WriteLine("2. Stand");

                choice = GetChoice();
                if (choice == 1)
                {
                    dealer.Hit();
                    Console.WriteLine("Dealer hits.");
                    if (dealer.CheckBusted())
                    {
                        Console.WriteLine("Dealer busts. Game end.");
                        return;
                    }
                }
                else if (choice == 2)
                {
                    dealer.Stand();
                    Console.WriteLine("Dealer stands.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }

            // Reveal the face-down card
            dealer.RevealFaceDown();

            while (!dealer.HasStand)
            {
                Console.WriteLine("Dealer Choose 1 or 2:");
                Console.WriteLine("1. Hit");
                Console.WriteLine("2. Stand");

                choice = GetChoice();
                if (choice == 1)
                {
                    dealer.Hit();
                    Console.WriteLine("Dealer hits.");
                    if (dealer.CheckBusted())
                    {
                        Console.WriteLine("Dealer busts. Game end.");
                        return;
                    }
                }
                else if (choice == 2)
                {
                    dealer.Stand();
                    Console.WriteLine("Dealer stands.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }

            Console.WriteLine("Game end.");
        }

        static int GetChoice()
        {
            while (true)
            {
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
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
