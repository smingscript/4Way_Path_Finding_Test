using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class Clue
    {
        public void SetCardDeck()
        {
            #region SetCard Refactoring

            //Suspect[] suspects = (Suspect[])Enum.GetValues(typeof(Suspect));
            //Place[] places = (Place[])Enum.GetValues(typeof(Place));
            //Weapon[] weapons = (Weapon[])Enum.GetValues(typeof(Weapon));

            List<string> suspects = CardType.GetAllItem(new Suspect());
            List<string> places = CardType.GetAllItem(new Place());
            List<string> weapon = CardType.GetAllItem(new Weapon());

            List<int> list = new List<int>();
            //OnCardDeckEvent(list, suspects.Select(x => (int)x).ToArray(), CardType.Suspect);
            //OnCardDeckEvent(list, places);
            //OnCardDeckEvent(list, weapons);

            //플레이어에게 배분할 카드 덱 생성
            List<string> playerCardDeck = OnSetPlayerCardDeck();

            //정답 카드 생성
            List<string> answerCardDeck = OnSetAnswerCardDeck();

            //각 방에서 필요한 클루 카드 덱 생성


            Stack<int> stack = new Stack<int>(list.OrderBy(x => Guid.NewGuid()));

            #endregion
        }
        public Clue()
        {
        }

        //TODO 2
        private static Random random;
        
        
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

        private CardDeckEventEventArgs OnCardDeckEvent(List<int> cardDeck, int[] answerCardDeck, CardType cardType)
        {
            CardDeckEventEventArgs args = new CardDeckEventEventArgs(cardDeck, answerCardDeck, cardType);
            OnCardDeckEvent(args);

            return args;
        }

        public class CardDeckEventEventArgs : EventArgs
        {
            public List<int> CardDeck { get; set; }
            public int[] AnswerCardDeck { get; set; }
            public CardType CardType { get; set; }

            public CardDeckEventEventArgs()
            {
            }

            public CardDeckEventEventArgs(List<int> cardDeck, int[] answerCardDeck, CardType cardType)
            {
                CardDeck = cardDeck;
                AnswerCardDeck = answerCardDeck;
                CardType = cardType;
            }
        }
        #endregion

    }
}
