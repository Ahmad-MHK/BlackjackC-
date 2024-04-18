using System;
using System.Collections.Generic;
using ConsoleApp2.Models;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack!");

            // Initialize the blackjack game with 1 deck
            BlackjackGame game = new BlackjackGame(1);

            // Start the game
            game.StartGame();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
