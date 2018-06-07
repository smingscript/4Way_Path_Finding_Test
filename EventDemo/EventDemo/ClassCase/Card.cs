using System;
using System.Collections.Generic;
using System.Linq;

namespace EventDemo
{

    public class Card
    {
        
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

    }

}
