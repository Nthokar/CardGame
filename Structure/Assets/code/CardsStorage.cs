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
            if (storage.Count > 0)
            {
                Debug.Log("Cards in storage: " + storage.Count);
                int rndIndex = rnd.Next(0, storage.Count);
                return storage.ToList<Card>()[rndIndex];
            }
            Debug.Log("Storage have no cards");
            throw new Exception("Storage have no cards");
        }

        //public static Card GetRandomCard()
        //{
        //    return 
        //}

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

            new Card()
            {
                Discription = "Ваш сотрудник учавствовал в скандале с домогательством",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,
                    
                    Description = "Выгнать за 5% от денег за ход",

                    tax = new Tax()
                    {
                        Procent = 0.05f,
                        TurnDuration = 5,
                    },

                },
               LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = -1,
                    GovernmentInfluence = -1,
                    BalanceInfluence = 0,

                    Description= "Проигнорировать",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "В ходе судебных разбирательств вам выписали штраф в размере 2000 ",


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
                Discription = "Комьюнити жалуется на отсутсвие какого либо удобного способа связи с вашей компанией. В качестве решения вам предложили сделать сайт с круглосуточной поддержкой",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = -1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = -2000,

                    Description = "Сделать за 2000",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Ваши и без того загруженные сотрудники были недовольны",

                        }
                    }
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description= "Проигнорировать",
                  }
               },

            new Card()
            {
                Discription = "Вам пришло письмо от правительства. В нем была просьба: \"Запретить вашу продукцию на территории страны конкурента\"",
                RightChoise = new Choise()
                {
                    CommunityInfluence = -1,
                    EmploeeInfluence = -2,
                    GovernmentInfluence = 2,
                    BalanceInfluence = 0,

                    Description = "Согласиться",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Комьюнити резко отозвалось о таком решении, а также один из сотрудников был уроженцем из той страны",

                        }
                    }
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = -1,
                    BalanceInfluence = 0,

                    Description= "Отказаться",

                    tax = new Tax()
                    {
                        TurnDuration = 2,
                        Value = 1000,
                        Procent = 0.05f,
                    },
                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Кто-то из сотрудников узнал об этом решении и предал его всеобщей огласке",
                        }
                     }
                  }
               },

            new Card()
            {
                Discription = "В вашем городе наступила аномальная жара и ваши сотрудники попросили установить кондиционеры",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = -2000,

                    Description = "Установить за 2000",


                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = -2,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description= "Проигнорировать",

                  }
               },

            new Card() //123
            {
                Discription = "Ваш менеджер по безопасности начал жаловатся на маленькую зарплату",
                LeftChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description = "Проигнорировать",


                },
                RightChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description= "Поднять на 5% от денег за ход",


                  }
               },

            new Card()
            {
                Discription = "Вам на почту пришло письмо с приглашением на Экспо",
                LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = -1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description = "Отказаться",


                },
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = 1,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    tax = new Tax()
                    {
                        Procent = -0.15f,
                    },

                    Description= "Согласиться",


                  }
               },

            new Card()
            {
                Discription = "Один из ваших рекламнных менеджеров предлагает вам последовать тренду и сократить часть сотрудников в пользу людей других этнических групп",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 2,
                    EmploeeInfluence = -2,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description = "Сократить",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Большая часть комьюнити поддержала эту инициативу, но сотрудники были очень недовольны этим решением",

                        }
                    }
                },
                LeftChoise = new Choise()
                {
                    CommunityInfluence = -2,
                    EmploeeInfluence = 2,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 0,

                    Description= "Не сокращать",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Это решение так и не придали огласке, поэтому комьюнити не обратило на это внимания, но сотрудники были очень благодарны",
                        }
                    }
                }
            },

            new Card()
            {
                Discription = "Сотруднику пришла идея устроить турнир в один рабочий день по одной видео игре между всеми желающими",
                LeftChoise= new Choise()
                {
                    Description= "Работать в обычном режиме",

                    CommunityInfluence= 0,
                    EmploeeInfluence= 0,
                    GovernmentInfluence= 0,
                },
                RightChoise = new Choise()
                {
                    Description ="Устроить",

                    CommunityInfluence= 0,
                    EmploeeInfluence=2,
                    GovernmentInfluence=0,

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "По воле случая именно в этот день в офис пришел инвестор и остался не доволен вашим руководством",

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
                        }
                    }
                },
            },

            new Card()
            {
                Discription = "Одна из компаний по установке средств безопасности предложила вам установить камеры видеонаблюдения",
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = 0,
                    BalanceInfluence = 0,

                    Description = "Не устанавливать",
                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Ночью к вам пробрался вор и украл оборудования на 5000",

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
                            },
                        }
                    }
                },
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 1,
                    CommunityInfluence = 0,
                    EmploeeInfluence = 0,
                    BalanceInfluence = -2000,

                    Description= "Установить за 2000$",
                  }
               },

            new Card()
            {
                Discription = "Злоумышлиники украли вашу базу данных и просят выкуп: 4000$",

                LeftChoise = new Choise()
                {
                    Description = "Заплатить выкуп",
                    
                    CommunityInfluence = -2,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 0,
                    BalanceInfluence = 4000,

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Злоумышлиники забрали выкуп и слили базу данных",

                            LeftChoise= new Choise()
                            {
                                CommunityInfluence = -1,
                                EmploeeInfluence = 0,
                                GovernmentInfluence = -2,
                                BalanceInfluence = 0,
                            },
                            RightChoise= new Choise()
                            {
                                CommunityInfluence = -1,
                                EmploeeInfluence = 0,
                                GovernmentInfluence = -2,
                                BalanceInfluence = 0,
                            }
                        },
                        
                        new Card()
                        {
                            Discription = "Злоумышлиники забрали выкуп и вернули базу данных",

                            LeftChoise= new Choise()
                            {
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                GovernmentInfluence = 0,
                                BalanceInfluence = 0,
                            },
                            RightChoise= new Choise()
                            {
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                GovernmentInfluence = 0,
                                BalanceInfluence = 0,
                            }
                        }
                    },
                },
                RightChoise = new Choise()
                {
                    Description = "Не платить выкуп",

                    CommunityInfluence = 0,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 1,
                    BalanceInfluence = 0,

                    Cards= new Card[]
                    {
                        new Card()
                        {
                            Discription = "Вашу базу данных слили в сеть",

                            LeftChoise = new Choise()
                            {
                                CommunityInfluence = -2,
                                EmploeeInfluence = 0,
                                GovernmentInfluence = 0,
                                BalanceInfluence = 0,
                            },

                            RightChoise = new Choise()
                            {
                                CommunityInfluence = -2,
                                EmploeeInfluence = 0,
                                GovernmentInfluence = 0,
                                BalanceInfluence = 0,
                            }
                        }
                    }
                },
            },

            new Card()
            {
                Discription = "Началась эпидемия \"Корововируса\", правительство просит вас заставить ваших сотрудников прививаться",
                
                RightChoise = new Choise()
                {
                    CommunityInfluence = 1,
                    EmploeeInfluence = 2,
                    GovernmentInfluence = -2,
                    BalanceInfluence = 0,
                    isUnique = true,

                    fine = new Fine()
                    {
                        ProcentFromBalance = -0.1f
                    },

                    Description = "Не заставлять",

                    Cards = new Card[]
                    {

                    },
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
                Discription = "Пришло время оплатить налоги",
                RightChoise = new Choise()
                {
                    CommunityInfluence = 0,
                    EmploeeInfluence = 0,
                    GovernmentInfluence = 1,
                    BalanceInfluence = 0,

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

                    Description= "Попробовать обойти налог",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Еще чуть-чуть и вас бы отправили в тюрьму, но вам повезло отделаться лишь упадком репутации в лице вашего государства и комьюнити. Кхм, кстати, налог все равно прийдется заплатить",

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
                        }
                     }
                  }
               },
            
            new Card()
            {
                Discription = "Вам пришло письмо на почту  от известной киностудии с предложением снять сериал об айти компании у вас в офисе",
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = -2,
                    EmploeeInfluence = 1,
                    BalanceInfluence = 0,

                    Description = "Отказаться",
                },
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 2,
                    EmploeeInfluence = -2,
                    BalanceInfluence = 0,

                    Description= "Согласиться",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Сериал \"зашел\" публике из за чего ваши доходы выросли на 15%",

                            LeftChoise=new Choise()
                            {
                                GovernmentInfluence = 0,
                                CommunityInfluence = 1,
                                EmploeeInfluence = 1,
                                BalanceInfluence = 0,

                                tax = new Tax()
                                {
                                    Procent = -0.15f
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
                                    Procent = -0.15f
                                }
                            },
                        }
                     }
                 }
              },

            new Card()
            {
                Discription = "Ваши сотрудники жалуются на агрессиивное поведение тимлида",
                LeftChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = -1,
                    BalanceInfluence = 0,

                    Description = "Оставить",
                },
                RightChoise = new Choise()
                {
                    GovernmentInfluence = 0,
                    CommunityInfluence = 0,
                    EmploeeInfluence = 2,
                    BalanceInfluence = 0,

                    tax = new Tax()
                    {
                        Procent = 0.1f
                    },

                    Description= "Поменять",

                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Иногда строгий и агрессивный тимлид заставляет работать продуктивней. Ваша прибыль за ход уменьшилась на 10%",
                        }
                     }
                 }
              },

            new Card()
            {
                Discription = "В вашем офисе кончаются места для сотрудников. Во время поиска нового помещения вы наткнулись на крутой и относительно дешевый офис, но от сомнительного человека.",
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
                    EmploeeInfluence = 3,
                    BalanceInfluence = -10000,

                    Description= "Переехать в него за 10.000$",
                    
                    Cards = new Card[]
                    {
                        new Card()
                        {
                            Discription = "Как оказалось в офисе была незаконная перепланировка из за чего вым пришлось пройти через огромную бумажную волокиту, а так-же заплатить еще 3000",

                            LeftChoise= new Choise()
                            {
                                GovernmentInfluence = -1,
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                BalanceInfluence = -3000,
                            },
                            RightChoise= new Choise()
                            {
                                GovernmentInfluence = -1,
                                CommunityInfluence = 0,
                                EmploeeInfluence = 0,
                                BalanceInfluence = -3000,
                            },
                        },

                        null
                     }
                 }
              },

        };
    }
}
