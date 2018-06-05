using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class Clue
    {
        public void SetInitCardDeck()
        {
            #region SetCard Refactoring

            Suspect[] suspects = (Suspect[])Enum.GetValues(typeof(Suspect));
            Place[] places = (Place[])Enum.GetValues(typeof(Place));
            Weapon[] weapons = (Weapon[])Enum.GetValues(typeof(Weapon));

            List<int> list = new List<int>();
            OnCardDeckEvent(list, suspects);
            OnCardDeckEvent(list, places);
            OnCardDeckEvent(list, weapons);

            Stack<int> stack = new Stack<int>(list.OrderBy(x => Guid.NewGuid()));

            #endregion
        }
        public Clue()
        {
        }

        //TODO 2
        private static Random random;
        
        public Enum CardType { get; private set; }

        private Stack<Card> _cardDeck;
        public Stack<Card> CardDeck { get; set; }

        private List<Card> _answerCard;
        public List<Card> AnswerCard { get; set; }


        #region CardDeckEvent event things for C# 3.0
        public event EventHandler<CardDeckEventEventArgs> CardDeckEvent;

        protected virtual void OnCardDeckEvent(CardDeckEventEventArgs e)
        {
            if (CardDeckEvent != null)
                CardDeckEvent(this, e);
        }

        private CardDeckEventEventArgs OnCardDeckEvent(Stack<Card> cardDeck, List<Card> answerCardDeck)
        {
            CardDeckEventEventArgs args = new CardDeckEventEventArgs(cardDeck, answerCardDeck);
            OnCardDeckEvent(args);

            return args;
        }

        public class CardDeckEventEventArgs : EventArgs
        {
            public Stack<Card> CardDeck { get; set; }
            public List<Card> AnswerCardDeck { get; set; }

            public CardDeckEventEventArgs()
            {
            }

            public CardDeckEventEventArgs(Stack<Card> cardDeck, List<Card> answerCardDeck)
            {
                CardDeck = cardDeck;
                AnswerCardDeck = answerCardDeck;
            }
        }
        #endregion

    }
}
