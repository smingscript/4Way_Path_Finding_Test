using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class Room
    {
        public Room(string roomName)
        {
            _roomName = roomName;
            Clue clue = new Clue();
            clue.SetRoomObjects += Clue_SetRoomObjects;

            clue.GetObjectDictionary();
        }

        private string _roomName;
        public Dictionary<string, Enum> roomObjects { get; set; }

        void Clue_SetRoomObjects(object sender, Clue.SetRoomObjectsEventArgs e)
        {
            roomObjects = new Dictionary<string, Enum>();

            foreach (var item in e.Clues)
            {
                if ((CardType)item.Key == CardType.Place)
                {
                    roomObjects.Add(_roomName, CardType.Place);
                    Suggestion.suggestions.Add(_roomName);
                    continue;
                }

                for (int i = 0; i < item.Value.Count; i++)
                {
                    roomObjects.Add(item.Value[i], item.Key);
                }
            }
        }
    }

}
