using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.code
{
    public static class CardsStorage
    {
        public static Card GetRandomCard()
        {
            System.Random rnd = new System.Random();
            if (cards.Count > 0)
            {
                Debug.Log("Cards in storage: " + cards.Count);
                int rndIndex = rnd.Next(0, storage.Count);
                Card card = cards[rndIndex];
                if (!GameManager.CardQueue.Contains(card))
                {
                    GameManager.CardQueue.Enqueue(card);
                    return cards[rndIndex];
                }
                else
                    return GetRandomCard();
            }
            Debug.Log("Storage have no cards");
            throw new Exception("Storage have no cards");
        }

        public static void DeleteUniqueCard(Card uniqueCard)
        {
            cards.Remove(uniqueCard);
        }

        private static HashSet<Card> storage = new HashSet<Card>()
        {
            new Card()
            {
                Discription = "Ваш знакомый предприниматель сказал что корпоративы хорошо поднимают \"боевой дух\" сотрудников и предложил вам устроить что-то подобное",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = -1000,

                    Description = "Организовать за 1000",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Вы и ваши сотрудники повеселились от души ",
                        }
                    }
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description= "Не организовывать",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Один из сотрудников подслушал ваш разговор, после чего расказал остальным. Ваши сотрудники обиделись на вас",
                        }
                     }
                  }
               },

            new Card()
            {
                Discription = "Новатор предложил начать работать с фрилансерами",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 1,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 1,
                    BalanceInfluence = 0,

                    Description = "Согласиться за 5% от денег за ход",
                },
               LeftChoise = new Choise()
                {
                    CommunityInfluence = -1,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description= "Отказаться",

                 }
              },

        };

        private static List<Card> cards = storage.ToList();
    }
}
