using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishing
{
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards.Add(new Card((Suits)suit, (Values)value));
                }
            }
        }

        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count { get { return cards.Count; } }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal(int index)
        {
            Card cardToDeal = cards[index];
            cards.RemoveAt(index);
            return cardToDeal;
        }

        public Card Deal()
        {
            return Deal(0);
        }

        public void Shuffle()
        {
            List<Card> newCards = new List<Card>();
            while (cards.Count > 0)
            {
                int i = random.Next(cards.Count);
                newCards.Add(cards[i]);
                cards.RemoveAt(i);
            }
            cards = newCards;
        }
        public IEnumerable<string> GetCardNames()
        {
            List<string> cardNames = new List<string>();
            foreach (var card in cards)
            {
                cardNames.Add(card.Name);
            }
            return cardNames.ToArray();
        }
        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }
        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }

        public bool ContainsValue(Values value)
        {
            foreach (var card in cards)
            {
                if (card.Value == value)
                {
                    return true;
                }
            }
            return false;
        }
        public Deck PullOutValues(Values values)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].Value == values)
                    deckToReturn.Add(Deal(i));
            return deckToReturn;
        }
        public bool HasBook(Values values)
        {
            int NumberOfCards = 0;
            foreach (var card in cards)
                if (card.Value == values)
                    NumberOfCards++;
            if (NumberOfCards == 4)
                return true;
            else
                return false;
        }

    }

}
