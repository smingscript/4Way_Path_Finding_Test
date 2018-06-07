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

            card.CardDeckEvent += Card_CardDeckEvent;

            //var cardDeck = card.SetCardDeck();

            //3인 경기 가정
            Player player1 = new Player();
            Player player2 = new Player();
            Player player3 = new Player();
            List<Player> players = new List<Player> { new Player(), new Player(), new Player() };

            card.InitCluesToStart += DrawAnswerCard;
            card.SetCards();
            card.InitCluesToStart -= DrawAnswerCard;
            card.InitCluesToStart += new EventHandler<ClueInitEventArgs>((sender, e) => SetPlayerCard(sender, e, players));
            card.SetCards();

            Console.WriteLine("Answer Cards of this match is:");

            foreach (var answerCard in card.AnswerCard)
            {
                Console.WriteLine(answerCard.CardType);

            }

            List<Card> gameCards = new List<Card>();
            foreach (Card item in card.CardDeck)
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

        private static void ConvertInt2Enum(Clue.CardDeckEventEventArgs e)
        {
            if (e.CardType == CardType.Suspect)
            {
                Suspect[] array = e.AnswerCardDeck.Select(x => (Suspect)x).ToArray();
            }
            if (e.CardType == CardType.Place)
            {
                Place[] array = e.AnswerCardDeck.Select(x => (Place)x).ToArray();
            }
            if (e.CardType == CardType.Weapon)
            {
                Weapon[] array = e.AnswerCardDeck.Select(x => (Weapon)x).ToArray();
            }
        }
    }

    static void Foo<T>(List<int> list, T[] array)
    {
        //if (random == null)
        //{
        //    random = new Random();
        //}

        
    }

    public enum CardType
    {
        Suspect,
        Place,
        Weapon
    }
}
