using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            Clue card = new Clue();

            //var cardDeck = card.SetCardDeck();

            //3인 경기 가정
            Player player1 = new Player();
            Player player2 = new Player();
            Player player3 = new Player();
            List<Player> players = new List<Player> { new Player(), new Player(), new Player() };

            card.InitCluesToStart += DrawAnswerCard;
            card.InitCluesToStart += new EventHandler<ClueInitEventArgs>((sender, e) => SetPlayerCard(sender, e, players));

            card.SetCards();

            Console.WriteLine("Answer Cards of this match is:");

            foreach (var answerCard in card.AnswerCard)
            {
                Console.WriteLine(answerCard.CardType);

            }

            List<Card> gameCards = new List<Card>();
            foreach (Card item in card.cardDeck)
            {
                gameCards.Add(item);
            }

            players[0].GameCard = gameCards;

            Console.WriteLine();
            Console.WriteLine("Player's Card: ");
            foreach (Card gameCard in players[0].GameCard)
            {
                Console.WriteLine(gameCard.CardType);
            }

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

        static void DrawAnswerCard(object sender, ClueInitEventArgs e)
        {
            if (random == null)
            {
                random = new Random();
            }

            foreach (var enumItem in e.clueEnumItems.OrderBy(i => random.Next()))
            {
                e.cardDeck.Push(new Card(enumItem));
            }

            e.AnswerCardDeck.Add(e.cardDeck.Pop());

            //Console.WriteLine("Answer Cards of this match is:");

            //foreach (var card in e.AnswerCardDeck)
            //{
            //    Console.WriteLine(card.CardType);
                
            //}
            
        }

        static void SetPlayerCard(object sender, ClueInitEventArgs e, List<Player> players)
        {
            Random random = new Random();

            foreach (var enumItem in e.clueEnumItems.OrderBy(i => random.Next()))
            {
                e.cardDeck.Push(new Card(enumItem));
            }

            e._answerCard.Add(e.cardDeck.Pop());

            //List<Card> gameCards = new List<Card>();
            //foreach(Card card in e.cardDeck)
            //{
            //    gameCards.Add(card);
            //}

            //players[0].GameCard = gameCards;

            //Console.WriteLine();
            //Console.WriteLine("Player's Card: ");
            //foreach(Card card in players[0].GameCard)
            //{
            //    Console.WriteLine(card.CardType);
            //}
        }
    }
}
