using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo.Tests
{
    [TestClass()]
    public class RoomTests
    {
        [TestMethod()]
        public void 게임을_시작하고_정답_카드를_뽑는_이벤트_테스트()
        {
            Game game = new Game();
            game.StartGame();

            foreach (var item in game.AnswerCards)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        [TestMethod()]
        public void 게임을_시작하고_카드를_배포하는_이벤트_테스트()
        {
            Game game = new Game();
            game.StartGame();
            game.DistributeCards();

            for (int i = 0; i < game._players.Length; i++)
            {
                foreach (var item in game._players[i].GameCard)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
            }
        }

        [TestMethod()]
        public void 방의_추리_아이템을_얻는_이벤트_테스트()
        {
            Room room = new Room(Place.Courtyard);
            foreach (var item in room.roomObjects)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine();
        }


    }
}