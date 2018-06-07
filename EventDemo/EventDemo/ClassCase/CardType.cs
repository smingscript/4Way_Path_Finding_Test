using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class CardType
    {
        public static List<string> GetAllItem(CardType cardType)
        {
            return cardType.GetType()
                     .GetProperties()
                     .Select(field => (string) field.GetValue(cardType))
                     .ToList();
        }
    }
}
