using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Suggestion
    {
        public static readonly List<string> suggestions = new List<string>();
        private static string suggestion;

        public static bool MakeSuggestion(Dictionary<string, Enum> roomObjs)
        {
            if (suggestions.Count >= 3)
            {
                //TODO 추리에 반박하는 이벤트를 실행한다


                return false;
            }
            
            Console.WriteLine("추리 아이템을 하나씩 입력하세요:");
            suggestion = Console.ReadLine();

            //TODO 하나의 클루를 추리하면 선택된 클루에 대한 이벤트를 발생시킨다.


            #region For Console
            if (!roomObjs.Keys.ToArray().Contains(suggestion))
            {
                Console.WriteLine("추리 아이템을 잘못 입력했습니다, 다시 입력하세요");
                return true;
            }
            #endregion
            
            //Place 타입이면 추리를 무시한다
            if ((CardType)roomObjs[suggestion] == CardType.Place)
            {
                return true;
            }

            //이미 추가 된 추리이면 제거한다
            if (suggestions.Contains(suggestion))
            {
                suggestions.Remove(suggestion);
                return true;
            }
            //저장되지 않은 추리이면 추가한다
            else
            {
                suggestions.Add(suggestion);
                return true;
            }


        }
    }
}
