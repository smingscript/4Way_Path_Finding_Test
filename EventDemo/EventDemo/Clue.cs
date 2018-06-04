using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    //Clue Event
    public class ClueInitEventArgs : EventArgs
    {
        public Stack<Card> CardDeck { get; set; }
        public List<Card> AnswerCardDeck { get; set; }
        public Enum[] clueEnumItems { get; set; }
        public Stack<Card> cardDeck { get; set; }
        public List<Card> _answerCard { get; set; }
    }

    public class Clue
    {
        #region EventHandler
        /// <summary>
        /// 게임을 시작할 때 클루들을 세팅하기 위해 발생하는 이벤트
        /// </summary>
        public event EventHandler<ClueInitEventArgs> InitCluesToStart;

        /// <summary>
        /// GameManager에서 이벤트를 실행할 때 호출하는 메소드
        /// </summary>
        public void SetCards()
        {
            ClueInitEventArgs args = new ClueInitEventArgs();

            //args.CardDeck = SetCardDeck();
            //args.AnswerCardDeck = AnswerCard;

            OnInitClueToStart(args);

            AnswerCard = args.AnswerCardDeck;
            cardDeck = args.CardDeck;
        }

        //TODO 1
        protected virtual void OnInitClueToStart(ClueInitEventArgs e)
        {
            //EventHandler<CardDrawEventArgs> handler = DrawCardToStart;
            //if(handler != null)
            //{
            //    handler(this, e);
            //}

            //축약형
            //InitCluesToStart?.Invoke(this, e);

            #region SetCard Refactoring
            e.cardDeck = new Stack<Card>();
            e._answerCard = new List<Card>();
            e.AnswerCardDeck = new List<Card>();
            e.CardDeck = new Stack<Card>();

            //달라지는 부분
            string[] enumType = new string[] { "EventDemo.Suspect", "EventDemo.Place", "EventDemo.Weapon" };

            foreach (string item in enumType)
            {
                Type type = GetEnumType(item);
                e.clueEnumItems = ArrayToList(Enum.GetValues(type)); //e의 값으로 전달한다

                InitCluesToStart?.Invoke(this, e);
                //foreach (var enumItem in clueEnumItems.OrderBy(i => random.Next()))
                //{
                //    cardDeck.Push(new Card(enumItem));
                //}

                //_answerCard.Add(cardDeck.Pop());
            }
            //foreach (string item in enumType)
            //{
            //    Type type = GetEnumType(item);
            //    List<Enum> clueEnumItems = (List<Enum>) Enum.GetValues(type).Clone();

            //    foreach (var enumItem in clueEnumItems.OrderBy(i => random.Next()))
            //    {
            //        //달라지는 부분
            //        cardDeck.Push(new Card(enumItem));
            //    }

            //    //달라지는 부분
            //    _answerCard.Add(cardDeck.Pop());
            //}
            #endregion
        }
        #endregion

        private AppDomain currentDomain;
        System.Reflection.Assembly[] assemblies;

        public Clue()
        {
            currentDomain = AppDomain.CurrentDomain;
            currentDomain.Load("EventDemo");
            assemblies = AppDomain.CurrentDomain.GetAssemblies();

            
        }

        //TODO 2
        private static Random random;
        public Stack<Card> cardDeck = new Stack<Card>();
        public Enum CardType { get; private set; }

        //private List<Card> _answerCard = new List<Card>();

        public List<Card> AnswerCard { get; set; }
        //{
        //    get
        //    {
        //        return _answerCard;
        //    }
        //}

        //public Stack<Card> SetCardDeck()
        //{
        //    Stack<Card> cardDeck = new Stack<Card>();
        //    string[] enumType = new string[] { "EventDemo.Suspect", "EventDemo.Place", "EventDemo.Weapon" };

        //    foreach (string item in enumType)
        //    {
        //        Type type = GetEnumType(item);

        //        foreach (var enumItem in ShuffleEnumElements(Enum.GetValues(type)))
        //        {
        //            cardDeck.Push(new Card(enumItem));
        //        }

        //        _answerCard.Add(cardDeck.Pop());
        //    }

        //    return cardDeck;
        //}

        //TODO 3
        #region CardDeckGenerateHelper
        private Enum[] ArrayToList(Array inputList)
        {
            List<Enum> list = new List<Enum>();

            foreach (var input in inputList)
            {
                list.Add((Enum)input);
            }

            return list.ToArray(); //return the new random list
        }

        //private Enum[] ShuffleEnumElements(Array inputList)
        //{
        //    //var random = new Random();
        //    if (random == null)
        //    {
        //        random = new Random();
        //    }

        //    List<Enum> cardList = new List<Enum>();

        //    foreach (var input in inputList)
        //    {
        //        cardList.Add((Enum)input);
        //    }

        //    return cardList.OrderBy(i => random.Next()).ToArray();  //return the new random list
        //}

        Type GetEnumType(string enumName)
        {
            foreach (var assembly in assemblies)
            {
                var type = assembly.GetType(enumName);
                if (type == null)
                    continue;
                if (type.IsEnum)
                    return type;
            }

            return null;
        }
        #endregion

    }
}
