using System;
using System.Collections.Generic;
using System.Linq;

namespace Pocker
{
    public class PokerGame
    {
        private Player player;
        private Player computer;
        private Deck deck;

        public PokerGame(string playerName)
        {
            player = new Player(playerName);
            computer = new Player("Computer");
            deck = new Deck();
            deck.Shuffle();
        }

        public void StartGame()
        {
            DealInitialCards();
            PlayerTurn();
            ComputerTurn();
            DetermineWinner();
        }

        private void DealInitialCards()
        {
            for (int i = 0; i < 5; i++)
            {
                player.AddCard(deck.DealCard());
                computer.AddCard(deck.DealCard());
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("Your hand:");
            player.ShowHand();
            Console.WriteLine("Enter the indices of the cards you want to exchange (0-4, separated by spaces):");
            string[] indices = Console.ReadLine().Split(' ');
            List<int> cardIndices = indices.Select(int.Parse).ToList();
            player.ExchangeCards(deck, cardIndices);
            Console.WriteLine("Your new hand:");
            player.ShowHand();
        }

        private void ComputerTurn()
        {
            Random random = new Random();
            int numCardsToExchange = random.Next(1, 4);
            List<int> cardIndices = new List<int>();
            for (int i = 0; i < numCardsToExchange; i++)
            {
                cardIndices.Add(random.Next(5));
            }
            computer.ExchangeCards(deck, cardIndices);
        }

        private void DetermineWinner()
        {
            // 手札の強さを比較して勝者を決定するロジックを実装
            // ここでは簡単にランダムで勝者を決定します
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                Console.WriteLine($"{player.Name} wins!");
            }
            else
            {
                Console.WriteLine($"{computer.Name} wins!");
            }
        }
    }
}
