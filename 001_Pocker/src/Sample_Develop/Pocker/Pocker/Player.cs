using System;
using System.Collections.Generic;

namespace Pocker
{
    public class Player
    {
        private string name;
        private List<Card> hand;

        public string Name { get => name; set => name = value; }
        public List<Card> Hand { get => hand; set => hand = value; }

        public Player(string name)
        {
            this.Name = name;
            this.Hand = new List<Card>();
        }

        public void ShowHand()
        {
            foreach (Card card in Hand)
            {
                Console.Write(card + " ");
            }
            Console.WriteLine();
        }

        public void ExchangeCards(Deck deck, List<int> cardIndices)
        {
            foreach (int index in cardIndices)
            {
                Hand[index] = deck.DealCard();
            }
        }

        public List<Card> GetHand()
        {
            return Hand;
        }

        public void AddCard(Card card)
        {
            Hand.Add(card);
        }
    }
}
