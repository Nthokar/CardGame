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
            Debug.Log(storage.Count);
            System.Random rnd = new System.Random();
            if (cards.Count > 0)
            {
                int rndIndex = rnd.Next(0, cards.Count);
                Card card = cards[rndIndex];
                while (GameManager.CardQueue.Contains(card)) //условие на карты за которые нельзя заплатить
                {
                    rndIndex = rnd.Next(0, cards.Count);
                    card = cards[rndIndex];
                }
                GameManager.CardQueue.Enqueue(card);
                return card;
            }
            Debug.Log("Storage have no cards");
            throw new Exception("Storage have no cards");
        }

        public static void DeleteUniqueCard(Card uniqueCard)
        {
            cards.Remove(uniqueCard);
        }

        public static void SetDefault()
        {
            cards = storage.ToList();
        }

        private static HashSet<Card> storage = new HashSet<Card>()
        {

            new Card()
            {
                Description = "Ваш знакомый предприниматель сказал что корпоративы хорошо поднимают \"боевой дух\" сотрудников и предложил вам устроить что-то подобное",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = -1000,
                    isUnique = false,

                    Description = "Организовать за 1000",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Вы и ваши сотрудники повеселились от души ",
                        }
                    }
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = -1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description= "Не организовывать",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Один из сотрудников подслушал ваш разговор, после чего расказал остальным. Ваши сотрудники обиделись на вас",
                        }
                    }
                }
            },

            new Card()
            {
                Description = "Новатор предложил начать работать с фрилансерами",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 1,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    tax = new Tax()
                    {
                        Procent = -0.05f,
                        Value = 0,
                        TurnDuration = null,
                    },

                    Description = "Согласиться за 5% от денег за ход",
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = -1,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description= "Отказаться",

                }
            },

            new Card()
            {
                Description = "Ваш сотрудник учавствовал в скандале с домогательством",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description = "Выгнать за 5% от денег за ход",

                    tax = new Tax()
                    {
                        Procent = -0.05f,
                        TurnDuration = 5,
                    },

                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = -1,
                    GovernmentInfluence = -1,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description= "Проигнорировать",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "В ходе судебных разбирательств вам выписали штраф в размере 2000 ",


                            LeftChoise = new Choise()
                            {
                                BalanceInfluence = -2000,
                            },
                            RightChoise = new Choise()
                            {
                                BalanceInfluence = -2000,
                            }
                        }
                    }
                }
            },

            new Card()
            {
                Description = "Комьюнити жалуется на отсутсвие какого либо удобного способа связи с вашей компанией. В качестве решения вам предложили сделать сайт с круглосуточной поддержкой",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = -1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = -2000,
                    isUnique = true,

                    Description = "Сделать за 2000",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Ваши и без того загруженные сотрудники были недовольны",

                        }
                    }
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description= "Проигнорировать",
                }
            },

            new Card()
            {
                Description = "Вам пришло письмо от правительства. В нем была просьба: \"Запретить вашу продукцию на территории страны конкурента\"",
                RightChoise = new Choise()
                {
                    CommunityInfluence = -1,
                    EmploeeInfluence = -2,
                    GovernmentInfluence = 2,
                    BalanceInfluence = 0,
                    isUnique = false,

                    tax = new Tax()
                    {
                        Procent = -0.15f,
                        Value = 0,
                        TurnDuration = null,
                    },

                    Description = "Согласиться за 15% от денег за ход",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Комьюнити резко отозвалось о таком решении, а также один из сотрудников был уроженцем из той страны",

                        }
                    },
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = -1,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description= "Отказаться",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Кто-то из сотрудников узнал об этом решении и предал его всеобщей огласке",
                        }
                    },
                }
            },

            new Card()
            {
                Description = "В вашем городе наступила аномальная жара и ваши сотрудники попросили установить кондиционеры",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 2,
                    GovernmentInfluence = 0,
                    BalanceInfluence = -2000,
                    isUnique = true,

                    Description = "Установить за 2000",
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = -2,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description= "Проигнорировать",
                }
            },

            new Card() //123
            {
                Description = "Ваш менеджер по безопасности начал жаловатся на маленькую зарплату",
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = -1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = true,

                    Description = "Проигнорировать",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Вашу базу данных взломали и просят выкуп",
                            RightChoise = new Choise()
                            {
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                GovernmentInfluence = 1,
                                BalanceInfluence = 0,

                                Description = "Обратиться в полицию",

                                Cards = new Card[]
                                {
                                    new Card()
                                    {
                                        Description = "Его быстро поймали так, как он оказался тем самым менеджером по безопасности",
                                        RightChoise = new Choise()
                                        {
                                            EmploeeInfluence = -1,
                                        },
                                        LeftChoise = new Choise()
                                        {
                                            EmploeeInfluence = -1,
                                        }
                                    },
                                },

                            },
                            LeftChoise = new Choise()
                            {
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                GovernmentInfluence = 0,
                                BalanceInfluence = -5000,

                                Description = "Заплатить выкуп 5000",
                            }
                        },
                    },
                },
                RightChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = true,

                    Description = "Поднять за 5% от денег за ход",

                    tax = new Tax()
                    {
                        Procent = -0.05f,
                    },

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Другие ваши сотрудники узнали о подъеме зарплаты для \"безопасника\" из за чего начали расти недовольства",
                            RightChoise = new Choise()
                            {
                                CommunityInfluence = 0,
                                EmploeeInfluence = 3,
                                GovernmentInfluence = 0,
                                BalanceInfluence = 0,

                                tax = new Tax()
                                {
                                    Procent = -0.2f,
                                    Value = 0,
                                    TurnDuration = null
                                },


                                Description = "Поднять остальным за 20% от денег за ход",
                            },
                            LeftChoise = new Choise()
                            {
                                CommunityInfluence = 0,
                                EmploeeInfluence = -2,
                                GovernmentInfluence = 0,
                                BalanceInfluence = 0,

                                Description = "Проигнорировать"
                            }
                        },
                    },
                }

            },

            new Card()
            {
                Description = "Вам на почту пришло письмо с приглашением на Экспо",
                LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = -1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description = "Отказаться",
                },
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = -3000,
                    isUnique = false,

                    tax = new Tax()
                    {
                        Procent = 0.15f,
                    },

                    Description= "Согласиться за 3000",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Ваши доходы выросли на 15%"
                        },
                    },
                }
            },

            new Card()
            {
                Description = "Один из ваших рекламнных менеджеров предлагает вам последовать тренду и сократить часть сотрудников в пользу людей других этнических групп",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = -2,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = true,

                    Description = "Сократить",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Большая часть комьюнити поддержала эту инициативу, но сотрудники были очень недовольны этим решением",
                            LeftChoise = new Choise()
                            {
                                Cards = new Card[]
                                {
                                    new Card()
                                    {
                                        Description = "К вам пришел один из сокращенных сотрудников и сказал :\" Так! Или вы даёте мне 2000 или я иду в суд!\"",
                                        RightChoise = new Choise()
                                        {
                                            CommunityInfluence = 1,
                                            EmploeeInfluence = 1,
                                            GovernmentInfluence = 0,
                                            BalanceInfluence = -2000,

                                            Description = "Выплатить 2000",
                                        },
                                        LeftChoise = new Choise()
                                        {
                                            CommunityInfluence = -2,
                                            EmploeeInfluence = -1,
                                            GovernmentInfluence = -1,
                                            BalanceInfluence = -5000,

                                            Description = "Не выплачивать",

                                            Cards = new Card[]
                                            {
                                                new Card()
                                                {
                                                    Description = "Он отсудил у компании 5000 за моральнный ущерб"
                                                },
                                            },
                                        }
                                    },
                                },
                            },
                            RightChoise = new Choise
                            {
                                Cards = new Card[]
                                {
                                    new Card()
                                    {
                                        Description = "К вам пришел один из сокращенных сотрудников и сказал :\" Так! Или вы даёте мне 2000 или я иду в суд!\"",
                                        RightChoise = new Choise()
                                        {
                                            CommunityInfluence = 1,
                                            EmploeeInfluence = 1,
                                            GovernmentInfluence = 0,
                                            BalanceInfluence = -2000,

                                            Description = "Выплатить 2000",
                                        },
                                        LeftChoise = new Choise()
                                        {
                                            CommunityInfluence = -2,
                                            EmploeeInfluence = -1,
                                            GovernmentInfluence = -1,
                                            BalanceInfluence = -5000,

                                            Description = "Не выплачивать",

                                            Cards = new Card[]
                                            {
                                                new Card()
                                                {
                                                    Description = "Он отсудил у компании 5000 за моральнный ущерб"
                                                },
                                            },
                                        }
                                    },
                                },
                            }
                        },
                    },
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 2,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = true,

                    Description= "Не сокращать",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Это решение так и не придали огласке, поэтому комьюнити не обратило на это внимания, но сотрудники были очень благодарны",
                        },
                    },
                }
            },

            new Card()
            {
                Description = "Сотруднику пришла идея устроить турнир в один рабочий день по одной видео игре между всеми желающими",
                LeftChoise= new Choise()
                {
                    Description= "Работать в обычном режиме",

                    CommunityInfluence= 0,
                    EmploeeInfluence= -1,
                    GovernmentInfluence= 0,
                    BalanceInfluence = 0,

                    isUnique = false,
                },
                RightChoise = new Choise()
                {
                    Description ="Устроить и не получить денег за ход",

                    CommunityInfluence= 0,
                    EmploeeInfluence=2,
                    GovernmentInfluence=0,
                    BalanceInfluence= 0,
                    isUnique = false,

                    tax = new Tax()
                    {
                        Procent = -1f,
                        Value = 0,
                        TurnDuration = 1
                    },

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "По воле случая именно в этот день в офис пришел инвестор и остался не доволен вашим руководством",

                            LeftChoise = new Choise()
                            {
                                CommunityInfluence= -1,
                                EmploeeInfluence= 0,
                                GovernmentInfluence= 0,
                            },
                            RightChoise = new Choise()
                            {
                                CommunityInfluence= -1,
                                EmploeeInfluence= 0,
                                GovernmentInfluence= 0,
                            },
                        },
                    },
                },
            },

            new Card()
            {
                Description = "Одна из компаний по установке средств безопасности предложила вам установить камеры видеонаблюдения",
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description = "Не устанавливать",
                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Ночью к вам пробрался вор и украл оборудования на 5000",

                            LeftChoise= new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                BalanceInfluence = -5000,
                            },
                            RightChoise= new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                BalanceInfluence = -5000,
                            }
                        },
                    },
                },
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 1,
                    CommunityInfluence = 0,
                    EmploeeInfluence = 0,
                    BalanceInfluence = -2000,
                    isUnique = true,

                    Description= "Установить за 2000$",
                }
            },

            new Card()
            {
                Description = "Началась эпидемия \"Корововируса\", правительство просит вас заставить ваших сотрудников прививаться",

                RightChoise = new Choise()
                {
                    CommunityInfluence = 1,
                    EmploeeInfluence = 2,
                    GovernmentInfluence = -2,
                    BalanceInfluence = 0,
                    isUnique = true,

                    Description = "Не заставлять",
                },

                LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = -2,
                    GovernmentInfluence = 2,
                    BalanceInfluence = 0,
                    isUnique = true,

                    Description= "Заставлять",

                }
            },

            new Card()
            {
                Description = "Пришло время оплатить налоги",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 1,
                    BalanceInfluence = 0,
                    isUnique = false,

                    fine = new Fine()
                    {
                        ProcentFromBalance = -0.2f
                    },

                    Description = "Заплатить 20% от вашей текущей суммы",

                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description= "Попробовать обойти налог",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Еще чуть-чуть и вас бы отправили в тюрьму, но вам повезло отделаться лишь упадком репутации в лице вашего государства и комьюнити. Кхм, кстати, налог все равно прийдется заплатить",

                            LeftChoise = new Choise()
                            {
                                CommunityInfluence = -2,
                                EmploeeInfluence = -1,
                                GovernmentInfluence = -3,
                                BalanceInfluence = 0,

                                fine = new Fine()
                                {
                                    ProcentFromBalance = -0.2f
                                },
                            },

                            RightChoise = new Choise()
                            {
                                CommunityInfluence = -2,
                                EmploeeInfluence = -1,
                                GovernmentInfluence = -3,
                                BalanceInfluence = 0,

                                fine = new Fine()
                                {
                                    ProcentFromBalance = -0.2f
                                },
                            }
                        },
                    },
                }
            },

            new Card()
            {
                Description = "Вам пришло письмо на почту  от известной киностудии с предложением снять сериал об айти компании у вас в офисе",
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = -2,
                    EmploeeInfluence = 1,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description = "Отказаться",
                },
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 2,
                    EmploeeInfluence = -2,
                    BalanceInfluence = 0,
                    isUnique = true,

                    Description= "Согласиться",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Сериал \"зашел\" публике из за чего ваши доходы выросли на 15%",

                            LeftChoise=new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = 1,
                                EmploeeInfluence = 1,
                                BalanceInfluence = 0,

                                tax = new Tax()
                                {
                                    Procent = 0.15f,
                                    TurnDuration = null,
                                }
                            },
                            RightChoise=new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = 1,
                                EmploeeInfluence = 1,
                                BalanceInfluence = 0,

                                tax = new Tax()
                                {
                                    Procent = 0.15f,
                                    TurnDuration = null,
                                }
                            },
                        },
                    },
                }
            },

            new Card()
            {
                Description = "Ваши сотрудники жалуются на агрессиивное поведение тимлида",
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = -1,
                    BalanceInfluence = 0,
                    isUnique = false,

                    Description = "Оставить",
                },
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = 2,
                    BalanceInfluence = 0,
                    isUnique = true,

                    tax = new Tax()
                    {
                        Procent = -0.1f,
                        TurnDuration = null
                    },

                    Description= "Поменять",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Иногда строгий и агрессивный тимлид заставляет работать продуктивней. Ваша прибыль за ход уменьшилась на 10%",
                        },
                    },
                }
            },

            new Card()
            {
                Description = "В вашем офисе кончаются места для сотрудников. Во время поиска нового помещения вы наткнулись на крутой и относительно дешевый офис, но от сомнительного человека.",
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = -3,
                    BalanceInfluence = 0,

                    Description = "Остаться",

                },
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = 4,
                    BalanceInfluence = -10000,

                    Description= "Переехать в него за 10.000$",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Description = "Как оказалось в офисе была незаконная перепланировка из за чего вым пришлось пройти через огромную бумажную волокиту, а так-же заплатить еще 3000",

                            LeftChoise= new Choise()
                            {
                                GovernmentInfluence = -2,
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                BalanceInfluence = -3000,
                            },
                            RightChoise= new Choise()
                            {
                                GovernmentInfluence = -2,
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                BalanceInfluence = -3000,
                            },
                        },

                        null
                    },
                }
            },

            new Card()
            {
                Description = "Ваш разработчик написал код которым невозможно было пользоваться. Это не первый его прокол, но он обещает что исправит и такого больше не повторится",
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = 1,
                    BalanceInfluence = 0,

                    Description = "Разрешить исправить",

                    Cards = new Card[]
                    {
                        new Card ()
                        {
                            Description = "По  итогу он испортил код еще сильней и его все равно пришлось выгнать",
                            LeftChoise= new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = 0,
                                EmploeeInfluence = -2,
                                BalanceInfluence = 0,
                            },
                            RightChoise= new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = 0,
                                EmploeeInfluence = -2,
                                BalanceInfluence = 0,
                            },
                        },

                        null

                    },
                },
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = -2,
                    EmploeeInfluence = -1,
                    BalanceInfluence = 0,

                    Description = "Выгнать",

                    Cards = new Card[]
                    {
                        new Card ()
                        {
                            Description = "После того как вы его выгнали он начал писать плохие отзывы на форумах",

                            LeftChoise= new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = -2,
                                EmploeeInfluence = 0,
                                BalanceInfluence = 0,
                            },
                            RightChoise = new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = -2,
                                EmploeeInfluence = 0,
                                BalanceInfluence = 0,
                            }
                        },
                    },
                }
            },

            new Card()
            {
                Description = "Один из ваших заказчиков остался недоволен продуктом и просит переделать",
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 2,
                    EmploeeInfluence = -1,
                    BalanceInfluence = 0,

                    Description = "Переделать бесплатно",

                    Cards = new Card[]
                    {
                        new Card ()
                        {
                            Description = "Заказчик был очень доволен и оставил хороший отзыв",
                        },
                    },
                },
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = -2,
                    EmploeeInfluence = 0,
                    BalanceInfluence = 0,

                    Description = "Попросить 1000 за исправление",

                    Cards = new Card[]
                    {
                        new Card ()
                        {
                            Description = "Он отказался платить за исправление и написал множество жалоб на форумах",
                        },
                    },
                }
            },

            new Card()
            {
                Description = "Ваш друг, а по совместительству владелец другой айти компании предложил сделать общий продукт",
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = -1,
                    EmploeeInfluence = -2,
                    BalanceInfluence = 0,

                    Description = "Сделать за 3000",

                    Cards = new Card[]
                    {
                        new Card ()
                        {
                            Description = "Продукт оказался провальным и ни чуть себя не окупил",
                        },
                    },
                },
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = -1,
                    EmploeeInfluence = 1,
                    BalanceInfluence = 0,

                    Description = "Отказаться",
                }
            },
        

};

        private static List<Card> cards = storage.ToList();

        private static Card[] TutorialCards = new Card[]
        {
            new Card()
            {
                Description = "Привет ты директор IT компании",
                RightChoise = new Choise()
                {
                    Description = "Далее",
                    isUnique = true,
                },
                LeftChoise = new Choise()
                {
                    Description = "Далее",
                    isUnique = true,
                }

            },
            new Card()
            {
                Description = "По ходу игры будут появляться карточки с условиями и тебе надо будет выбрать один из двух ответов, от них будет зависить какая шкала измениться.",
                    RightChoise = new Choise()
                    {
                        Description = "Далее",
                        isUnique = true,
                    },
                    LeftChoise = new Choise()
                    {
                        Description = "Далее",
                        isUnique = true,
                    }

            },
            new Card()
            {
            Description = "В игре три шкалы: Правительство, Сотрудники, Комьюнити, если одна из них упадет до нуля, то ты проиграл",
                    RightChoise = new Choise()
                    {
                        Description = "Далее",
                        isUnique = true,
                    },
                    LeftChoise = new Choise()
                    {
                        Description = "Далее",
                        isUnique = true,
                    }

            },
            new Card()
            {
                Description = "Также у тебя есть деньги на которые ты можешь покупать улучшения в магазине. Их отсутствие тоже приведет к поражению",
                RightChoise = new Choise()
                {
                    Description = "Далее",
                    isUnique = true,
                },
                LeftChoise = new Choise()
                {
                    Description = "Далее",
                    isUnique = true,
                }

            },
            new Card()
            {
                Description = "Удачной игры!",
                RightChoise = new Choise()
                {
                    Description = "Перейти к игре",
                    isUnique = true,
                },
                LeftChoise = new Choise()
                {
                    Description = "Перейти к игре",
                    isUnique = true,
                }

            },
            
        };  
    }
}
