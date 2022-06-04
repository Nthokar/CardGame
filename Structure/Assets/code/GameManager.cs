using System.Collections.Generic;
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

        public static Queue<Card> CardQueue = new Queue<Card>();

        public static bool isSurviveMode;
        public static bool isNewGame;
        public static bool isLose;
        private static bool isCardOnDesk;
        private static Card card;



        public void Awake()
        {
            GameInitialization();
            if (!isCardOnDesk || isNewGame)
            {
                TurnStart();
                isNewGame = false;
            }
            else
                TurnStart(card);
        }

        public static void RestartGame(bool _isSurviveMode)
        {
            isSurviveMode = _isSurviveMode;
            isNewGame = true;
            isLose = false;
            CardQueue.Clear();
        }
        public void GameInitialization()
        {
            Shop = GameObject.Find("ShopWindow");
            CardHolder = GameObject.Find("CardHolder");
            indicatorsManager = GameObject.Find("IndicatorsManager").GetComponent<IndicatorsManager>();
            if (isSurviveMode)
                Player.OnLose = () => { isLose = true; };
            else
                Player.OnLose = () => { return; };
            DeactivateShop();
            Player.OnDataChange = indicatorsManager.UpdateData;
        }

        public void TurnStart()
        {
            if (isLose) return;
            CreateCard(CardsStorage.GetRandomCard());
            CardOnDesk.PlayCreateAnimation();
            DequeueOldCards();
        }
        public void TurnStart(Card card)
        {
            if (isLose) return;
            if (card == null)
            {
                TurnStart();
                return;
            }
            CreateCard(card);
            CardOnDesk.PlayCreateAnimation();
            DequeueOldCards();
        }

        private static void DequeueOldCards()
        {
            if (CardQueue.Count > 7)
                CardQueue.Dequeue();
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
            CardOnDesk.GetComponent<CardOnDesk>().card = card;
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
