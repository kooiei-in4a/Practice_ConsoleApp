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
            computer = new Player("CPU");
            deck = new Deck();
            deck.Shuffle();
        }

        public bool StartGame()
        {
            DealInitialCards();
            PlayerTurn();
            ComputerTurn();
            return DetermineWinner();
        }

        /// <summary>
        /// 双方のデッキにカードを5枚配る
        /// </summary>
        private void DealInitialCards()
        {
            for (int i = 0; i < 5; i++)
            {
                player.AddCard(deck.DealCard());
                computer.AddCard(deck.DealCard());
            }
        }

        /// <summary>
        /// プレーヤーのターン処理
        /// </summary>
        private void PlayerTurn()
        {
            Console.WriteLine("あなたの手札:");
            player.ShowHand();
            Console.WriteLine("");

            Console.WriteLine("交換したい手札番号[1-5]を半角スペース区切りで入力してください。 (未入力の場合は交換しないと判断されます。):");


            //string[] indices = Console.ReadLine().Split(' ');
            //List<int> cardIndices = indices.Select(int.Parse).ToList();

            List<int> cardIndices = ChangeHandPlayerInput(Console.ReadLine());

            player.ExchangeCards(deck, cardIndices);

            Console.WriteLine("");
            Console.WriteLine("交換後のあなたの手札:");
            player.ShowHand();
            Console.WriteLine("");
        }


        /// <summary>
        /// コンピュータのターン処理
        /// </summary>
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

        /// <summary>
        /// 勝者判定
        /// </summary>
        private bool DetermineWinner()
        {
            // 手札の強さを比較して勝者を決定するロジックを実装
            // ここでは簡単にランダムで勝者を決定します
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                Console.WriteLine($"{player.Name} の勝ち!");
                return true;
            }
            else
            {
                Console.WriteLine($"{computer.Name} の勝ち!");
                return false;
            }
        }

        private List<int> ChangeHandPlayerInput(string? input)
        {
            var result = new List<int>();
            List<bool> boolList = new List<bool> { false, false, false, false, false };


            try
            {
                string[] indices = input.Split(' ');
                
                for (int i = 0; i < indices.Length; i++)
                {
                    int val = -1;
                    if (int.TryParse(indices[i],out val))
                    {
                        if (0 < val && val < 6)
                        {
                            boolList[val - 1] = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < boolList.Count; i++)
            {
                if (boolList[i])
                {
                    result.Add(i);
                }
            }

            return result;
            

        }
    }
}
