using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker
{
    public class Card
    {
        private string suit;
        private string rank;

        public Card(string suit, string rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string ToString()
        {
            return rank + suit;
        }
    }
}
