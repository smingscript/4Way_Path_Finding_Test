using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Place place = new Place();
            var a = CardType.GetAllItem(new Suspect());
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }

        private static void Card_CardDeckEvent(object sender, Clue.CardDeckEventEventArgs e)
        {
            Random random = new Random();
            ConvertInt2Enum(e);

            int index = random.Next(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                if (i != index)
                    e.CardDeck.Add(i);
            }
        }

    }
}