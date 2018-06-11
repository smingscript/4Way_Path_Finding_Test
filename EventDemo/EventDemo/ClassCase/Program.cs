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
            Room room = new Room(Place.Courtyard);

            while (Suggestion.MakeSuggestion(room.roomObjects))
            {
                //이 부분을 이벤트로 처리한다!
                Console.WriteLine("선택한 카드:");
                foreach (var item in Suggestion.suggestions)
                {
                    Console.WriteLine(item);
                }
            }

        }
        
    }
}