#region
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace EventDemo
{
    public class Deck
    {
        #region singleton
        private static Deck _instance;

        public static Deck Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Deck();
                return _instance;
            }
        }

        private Deck()
        {
            _cards = new List<Card>();

            //clue에서 data를 받아서 _card에 18장의 카드를 생성한다.
            Clue clue = new Clue();
            clue.SetGameItems += Clue_SetPlayerDeck;

            //이벤트 발생
            clue.SetItems();
        }
        #endregion

        private List<Card> _cards;

        private int _index = 0;

        /// <summary>
        /// Deck을 다시 셔플한다
        /// </summary>
        public void PrepareNewRound()
        {
            _cards = _cards.OrderBy(x => Guid.NewGuid()).ToList();
            _index = 0;
        }

        public Card[] Draw(int SkipCount, int TakeCount)
        {
            return _cards.Skip(SkipCount).Take(TakeCount).ToArray();
        }

        public int Size()
        {
            return _cards.Count;
        }

        #region Event Callbacks
        private void Clue_SetPlayerDeck(object sender, Clue.SetGameItemsEventArgs e)
        {
            Random random = new Random();

            foreach (var item in e.Clues)
            {
                int index = random.Next(item.Value.Count);
                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (i != index)
                        _cards.Add(new Card(item.Value[i], item.Key));
                }
            }
        }
        #endregion
    }
}
