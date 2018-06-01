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
            Card card = new Card();

            //var cardDeck = card.SetCardDeck();

            //3인 경기 가정
            Player player1 = new Player();
            Player player2 = new Player();
            Player player3 = new Player();

            card.DrawCardToStart += DrawAnswerCard;

            card.SetCards();

            #region CheckCardDraw
            //foreach (Card c in cardDeck)
            //{
            //    Console.WriteLine(c.CardType);
            //}

            //Console.WriteLine();

            //foreach (var i in card.AnswerCard)
            //{
            //    Console.WriteLine(i.CardType);
            //}
            #endregion

        }

        static void DrawAnswerCard(object sender, CardDrawEventArgs e)
        {
            Console.WriteLine("Answer Cards of this match is:");
            foreach (var card in e.AnswerCardDeck)
            {
                Console.WriteLine(card.CardType);
            }
            
        }

        static void SetPlayerCard(object sender, CardDrawEventArgs e)
        {

        }
    }
}
