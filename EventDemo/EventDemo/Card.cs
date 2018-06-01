﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EventDemo
{
    //Card Event
    public class CardDrawEventArgs : EventArgs
    {
        public Stack<Card> CardDeck { get; set; }
        public List<Card> AnswerCardDeck { get; set; }
    }

    public class Card
    {
        #region EventHandler
        /// <summary>
        /// 게임을 시작하기 위해서 카드를 세팅하기 위해 발생하는 이벤트
        /// </summary>
        public event EventHandler<CardDrawEventArgs> DrawCardToStart;

        /// <summary>
        /// GameManager에서 카드 배분 이벤트를 실행할 때 호출하는 메소드
        /// </summary>
        public void SetCards()
        {
            CardDrawEventArgs args = new CardDrawEventArgs();
            args.CardDeck = SetCardDeck();
            args.AnswerCardDeck = AnswerCard;
            OnDrawCardToStart(args);
        }

        protected virtual void OnDrawCardToStart(CardDrawEventArgs e)
        {
            //EventHandler<CardDrawEventArgs> handler = DrawCardToStart;
            //if(handler != null)
            //{
            //    handler(this, e);
            //}

            //축약형
            DrawCardToStart?.Invoke(this, e);
        }
        #endregion

        private AppDomain currentDomain;
        System.Reflection.Assembly[] assemblies;
        public Card()
        {
            currentDomain = AppDomain.CurrentDomain;
            currentDomain.Load("EventDemo");
            assemblies = AppDomain.CurrentDomain.GetAssemblies();
        }

        public Card(Enum type)
        {
            CardType = type;
        }

        private static Random random;

        public Enum CardType { get; private set; }

        private List<Card> _answerCard = new List<Card>();

        public List<Card> AnswerCard
        {
            get
            {
                return _answerCard;
            }
        }

        public Stack<Card> SetCardDeck()
        {
            Stack<Card> cardDeck = new Stack<Card>();
            string[] enumType = new string[] { "EventDemo.Suspect", "EventDemo.Place", "EventDemo.Weapon" };

            foreach (string item in enumType)
            {
                Type type = GetEnumType(item);

                foreach (var enumItem in ShuffleEnumElements(Enum.GetValues(type)))
                {
                    cardDeck.Push(new Card(enumItem));
                }

                _answerCard.Add(cardDeck.Pop());
            }

            return cardDeck;
        }

        #region CardDeckGenerateHelper
        private Enum[] ShuffleEnumElements(Array inputList)
        {
            //var random = new Random();
            if(random == null)
            {
                random = new Random();
            }

            List<Enum> cardList = new List<Enum>();

            foreach(var input in inputList)
            {
                cardList.Add((Enum)input);
            }

            return cardList.OrderBy(i => random.Next()).ToArray(); ; //return the new random list
        }

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
