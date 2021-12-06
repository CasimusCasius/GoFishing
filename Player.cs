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
            this.textBoxOnForm.Text += Name + " dołączył do gry. \n\r";
        }
        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 0; i <= 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < CardCount; card++)
                    if (Peek(card).Value == value)
                        howMany++;
                if (howMany == 4)
                {
                    books.Add(value);
                    for (int card = CardCount - 1; card >= 0; card--)
                        cards.Deal(card);
                }

            }
            return books;
        }
        public Values GetRandomValue()
        {
            return Peek(random.Next(0, CardCount)).Value;
        }
        public Deck DoYouHaveAny(Values value)
        {
            Deck serchedValueDeck = new Deck(new Card[] { });
            serchedValueDeck = cards.PullOutValues(value);
            int countCard = serchedValueDeck.Count;
            textBoxOnForm.Text += Name + " ma " + countCard + Card.Plural(value, countCard) + Environment.NewLine;
            return serchedValueDeck;
        }
        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            AskForACard(players, myIndex, stock, GetRandomValue());
        }
        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values values)
        {
            int howMany = 0;
            textBoxOnForm.Text += Name + " pyta czy ktoś ma " + Card.Plural(values, 2) + Environment.NewLine;
            for (int i = 0; i < players.Count; i++)
            {
                if (myIndex != i)
                {
                    Deck takenCards = new Deck(new Card[] { });
                    takenCards = players[i].DoYouHaveAny(values);
                    textBoxOnForm.Text += players[i].Name + " ma " + takenCards.Count + Card.Plural(values, takenCards.Count) + Environment.NewLine;
                    if (takenCards.Count != 0)
                    {
                        howMany++;
                    }
                }
            }
            if (howMany == 0)
            {
                players[myIndex].TakeCard(stock.Deal());
                textBoxOnForm.Text += players[myIndex].Name + " pobrał kartę z kupki \n\r";
            }
        }
        public int CardCount
        {
            get
            {
                return cards.Count;
            }
        }
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }
    }
}
