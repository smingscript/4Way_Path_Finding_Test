using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class Clue
    {
        #region Clue Singleton
        private static Clue _instance;

        public static Clue Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Clue();
                return _instance;
            }
        }

        public Clue()
        {
            clueLists = new Dictionary<Enum, List<string>>
            {
                { CardType.Suspect, ClueType.GetAllItem(new Suspect()) },
                { CardType.Place, ClueType.GetAllItem(new Place()) },
                { CardType.Weapon, ClueType.GetAllItem( new Weapon()) }
            };
        }

        #endregion

        public Dictionary<Enum, List<string>> clueLists;

        public void SetItems()
        {
            OnSetGameItems(clueLists);
        }

        public void GetObjectDictionary()
        {
            OnSetRoomObjects(clueLists);
        }

        #region SetGameItems event things for C# 3.0
        public event EventHandler<SetGameItemsEventArgs> SetGameItems;

        protected virtual void OnSetGameItems(SetGameItemsEventArgs e)
        {
            if (SetGameItems != null)
                SetGameItems(this, e);
        }

        private SetGameItemsEventArgs OnSetGameItems(Dictionary<Enum, List<string>> clues)
        {
            SetGameItemsEventArgs args = new SetGameItemsEventArgs(clues);
            OnSetGameItems(args);

            return args;
        }

        private SetGameItemsEventArgs OnSetGameItemsForOut()
        {
            SetGameItemsEventArgs args = new SetGameItemsEventArgs();
            OnSetGameItems(args);

            return args;
        }

        public class SetGameItemsEventArgs : EventArgs
        {
            public Dictionary<Enum, List<string>> Clues { get; set; }

            public SetGameItemsEventArgs()
            {
            }

            public SetGameItemsEventArgs(Dictionary<Enum, List<string>> clues)
            {
                Clues = clues;
            }
        }
        #endregion

        #region SetRoomObjects event things for C# 3.0
        public event EventHandler<SetRoomObjectsEventArgs> SetRoomObjects;

        protected virtual void OnSetRoomObjects(SetRoomObjectsEventArgs e)
        {
            if (SetRoomObjects != null)
                SetRoomObjects(this, e);
        }

        private SetRoomObjectsEventArgs OnSetRoomObjects(Dictionary<Enum, List<string>> clues)
        {
            SetRoomObjectsEventArgs args = new SetRoomObjectsEventArgs(clues);
            OnSetRoomObjects(args);

            return args;
        }

        private SetRoomObjectsEventArgs OnSetRoomObjectsForOut()
        {
            SetRoomObjectsEventArgs args = new SetRoomObjectsEventArgs();
            OnSetRoomObjects(args);

            return args;
        }

        public class SetRoomObjectsEventArgs : EventArgs
        {
            public Dictionary<Enum, List<string>> Clues { get; set; }

            public SetRoomObjectsEventArgs()
            {
            }

            public SetRoomObjectsEventArgs(Dictionary<Enum, List<string>> clues)
            {
                Clues = clues;
            }
        }
        #endregion
    }
}
