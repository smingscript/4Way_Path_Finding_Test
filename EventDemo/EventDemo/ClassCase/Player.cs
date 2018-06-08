using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            GameCard = new List<Card>();
        }

        public string Name { get; private set; }
        public List<Card> GameCard { get; private set; }

        public Card[] AddCard(Card[] card)
        {
            GameCard.AddRange(card);
            return card;
        }

        public Card this[int cardIndex]
        {
            get { return GameCard[cardIndex]; }
        }

        internal void PrepareNewRound()
        {
            GameCard.Clear();
        }
    }
}
