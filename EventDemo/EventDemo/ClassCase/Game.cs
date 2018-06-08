using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class Game
    {
        public Game()
        {
            _players = new[] { new Player("Scarlet"), new Player("Peacock"), new Player("Plum"), new Player("Green")/*, new Player("White")*/ };
        }

        //TODO private readonly 로 바꾸기
        public Player[] _players;

        public List<Card> AnswerCards { get; set; }

        public void StartGame()
        {
            Clue clue = new Clue();
            clue.SetGameItems += Clue_SetAnswerCards;
        }

        public void DistributeCards()
        {
            Deck.Instance.PrepareNewRound();

            foreach (var player in _players)
                player.PrepareNewRound();

            int truncate = (int) Math.Truncate((double)Deck.Instance.Size() / _players.Length);
            int remain = Deck.Instance.Size() % _players.Length;
            int skipCount = 0;
            int takeCount = 0;

            for (int i = 0; i < _players.Length; i++)
            {
                skipCount += takeCount;

                if (i < remain)
                    takeCount = truncate + 1;
                else
                    takeCount = truncate;

                _players[i].AddCard(Deck.Instance.Draw(skipCount, takeCount));
            }
        }

        #region Event Callbacks
        private void Clue_SetAnswerCards(object sender, Clue.SetGameItemsEventArgs e)
        {
            Random random = new Random();
            AnswerCards = new List<Card>();

            foreach (var item in e.Clues)
            {
                int index = random.Next(item.Value.Count);
                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (i == index)
                        AnswerCards.Add(new Card(item.Value[i], item.Key));
                }
            }
        }
        #endregion

    }
}
