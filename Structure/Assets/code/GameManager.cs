using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.code
{
    public class GameManager : MonoBehaviour
    {
        public IndicatorsManager indicatorsManager;
        public GameObject Shop;
        public CardOnDesk CardOnDesk;
        public GameObject CardHolder;
        public GameObject CardTemplate;
        public GameObject ChangeButton;

        public Sprite ShopIcon;
        public Sprite CardIcon;
        
        
        private static bool isCardOnDesk;
        private static Card card;



        public void Awake()
        {
            GameInitialization();
            if (!isCardOnDesk)
                TurnStart();
            else
                TurnStart(card);
        }

        public void GameInitialization()
        {
            Shop = GameObject.Find("ShopWindow");
            CardHolder = GameObject.Find("CardHolder");
            indicatorsManager = GameObject.Find("IndicatorsManager").GetComponent<IndicatorsManager>();
            DeactivateShop();
            Player.OnDataChange = indicatorsManager.UpdateData;
        }

        public void TurnStart()
        {
            CreateCard(CardsStorage.GetRandomCard());
            CardOnDesk.PlayCreateAnimation();
        }
        public void TurnStart(Card card)
        {
            if (card == null)
            { 
                TurnStart();                                                                                        //опасная строка !!!                                                            
                return;
            }
            CreateCard(card);
            CardOnDesk.PlayCreateAnimation();
        }

        public void TurnEnd(Choise choise)
        {
            Player.Recount(choise);
            DestroyCard();
            if (choise == null || choise.IsCardsEmpty())
            {
                Player.GetMoneyByTurn();
                TurnStart();
            }
            else
            {
                TurnStart(choise.GetRandomCard());
            }
        }

        public void CreateCard(Card card)
        {
            var cardHolder = GameObject.Find("CardHolder");
            var CardGameObj = GameObject.Instantiate(CardTemplate, cardHolder.transform);
            CardOnDesk = CardGameObj.GetComponent<CardOnDesk>();
            CardOnDesk.GetComponent<CardOnDesk>().Card = card;
            CardOnDesk.transform.SetParent(cardHolder.transform);
            CardOnDesk.instance = CardGameObj;
            isCardOnDesk = true;
            GameManager.card = card;
        }

        public void DestroyCard()
        {
            CardOnDesk.PlayDestroyAnimation();
            isCardOnDesk = false;
        }

        public void ActivateShop()
        {
            CardHolder.SetActive(false);
            Shop.SetActive(true);
        }

        public void DeactivateShop()
        {
            CardHolder.SetActive(true);
            Shop.SetActive(false);
        }

        public void ShopChangeState()
        {
            if (Shop.active)
            {
                DeactivateShop();
                ChangeButton.GetComponent<Image>().sprite = ShopIcon;
            }
            else
            {
                ActivateShop();
                ChangeButton.GetComponent<Image>().sprite = CardIcon;
            }
        }

        public void LoadSetingsScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
