using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFishing
{
    internal class Player
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;
        public Player(String name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            this.textBoxOnForm.Text += Name + " dołączył do gry. \n";
        }
        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 0; i <= 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                    if (cards.Peek(card).Value == value)
                        howMany++;
                if (howMany==4)
                {
                    books.Add(value);
                    for (int card = cards.Count - 1; card >= 0; card--) 
                        cards.Deal(card);
                }

            }
            return books;
        }
        public Values GetRandomValue()
        {
            return cards.Peek(random.Next(0, cards.Count)).Value;
        }
        public Deck DoYouHaveAny(Values value)
        { 
            Deck serchedValueDeck = new Deck(new Card[] { });
            serchedValueDeck = cards.PullOutValues(value);
            int countCard = serchedValueDeck.Count;
            textBoxOnForm.Text += Name + " ma " + countCard + Card.Plural(value, countCard);
            return serchedValueDeck;
        }
        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            AskForACard(players, myIndex, stock, GetRandomValue());
        }
        public void AskForACard(List<Player> players,int myIndex, Deck stock, Values values)
        {
            textBoxOnForm.Text += Name + " pyta czy ktoś ma " + Card.Plural(values,2);
            for (int i = 0; i < players.Count; i++)
            {
                if(myIndex != i)
                {
                    Deck takenCards = new Deck(new Card[]{});
                    takenCards = players[i].DoYouHaveAny(values);
                    if (takenCards.Count == 0)
                    {
                        players[i].cards.Add(stock.Deal());

                    }
                }

            }
        }
        

    }
}
