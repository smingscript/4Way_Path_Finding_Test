using System;
using System.Collections.Generic;
using System.Linq;

namespace EventDemo
{
    public enum CardType
    {
        Suspect,
        Place,
        Weapon
    }

    public class Card
    {
        public Card(string name, Enum type)
        {
            CardName = name;
            CardType = type;
        }

        public string CardName { get; private set; }
        public Enum CardType { get; private set; }

        public override string ToString()
        {
            return $"{CardName}: {CardType}";
        }
    }

    
    
}
