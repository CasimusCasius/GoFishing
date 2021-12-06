using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishing
{
    public partial class Card
    {
    public Suits Suit { get; set; }
        public Values Value { get; set; }
        public string Name
        {
            get
            {
                return names[(int)Value] + " " + suits[(int)Suit];
            }
        }
        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }
        public override string ToString()
        {
            return Name;
        }


    }
}
