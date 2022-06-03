using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.code
{
    public class CardOnDesk : MonoBehaviour
    {
        public Text text;
        public Text ChoiseText;
        public Card card;
        public GameObject Template;
        public GameObject Parent;
        public GameManager GameManager;
        public IndicatorsManager IndicatorManager;
        public GameObject instance;


        public float rotationAngel = 30;
        private bool isAnimationPlaying;
        private Vector3 targetPosition;

        public void Start()
        {
            GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            IndicatorManager = GameManager.indicatorsManager;
            text.text = card.Discription;
        }

        private void Update()
        {
            if (!isAnimationPlaying && Input.mousePosition.x < 660)
            {
                StartCoroutine(RotationAnimation(20));
                IndicatorManager.PlayChangeIndicator(card.LeftChoise);
                ChangeDescriptionText(card.LeftChoise);
                if (Input.GetMouseButtonDown(0))
                    OnLeft();
            }
            if (!isAnimationPlaying && Input.mousePosition.x > 1260)
            {
                StartCoroutine(RotationAnimation(-20));
                IndicatorManager.PlayChangeIndicator(card.RightChoise);
                ChangeDescriptionText(card.RightChoise);
                if (Input.GetMouseButtonDown(0))
                    OnRight();
            }
            if (!isAnimationPlaying && Input.mousePosition.x < 1260 && Input.mousePosition.x > 660)
            {
                StartCoroutine(RotationAnimation(0));
                IndicatorManager.PlayChangeIndicator(null);
                ChangeDescriptionText(null);
            }
        }

        IEnumerator RotationAnimation(float angel)
        {
            float currentAngel = transform.rotation.z;
            for (float i = 0; i < 0.2; i +=Time.deltaTime)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angel), Time.deltaTime);
                yield return null;
            }
        }

        IEnumerator DestroyAnimation()
        {
            isAnimationPlaying = true;
            targetPosition = transform.position + Vector3.down * 2000;
            for (float i = 0; i < 0.2; i +=Time.deltaTime)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
                yield return null;
            }
            isAnimationPlaying = false;
            Destroy(instance);
        }

        IEnumerator CreateAnimation()
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position = transform.position + Vector3.right * 200;
            targetPosition = transform.position + Vector3.left * 200;
            for (float i = 0; i < 1; i +=Time.deltaTime)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), EasingSquare(Time.deltaTime));
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*4);
                yield return null;
            }
        }

        public void ChangeDescriptionText(Choise choise)
        {
            if (choise == null)
            {
                ChoiseText.text = "...";
            }
            else
            {
                ChoiseText.text = choise.Description;
            }
        }

        public void PlayCreateAnimation()
        {
            StartCoroutine(CreateAnimation());
        }

        public void PlayDestroyAnimation()
        {
            StartCoroutine(DestroyAnimation());
        }
        public CardOnDesk(Card cd)
        {
            card = cd;
        }

        public float EasingSquare(float x) { return x*x*x*x*x; }

        public void OnLeft() { 
            GameManager.TurnEnd(card.LeftChoise);
            if (card.LeftChoise.isUnique)
                CardsStorage.DeleteUniqueCard(card);

        }
        public void OnRight()
        { 
            GameManager.TurnEnd(card.RightChoise);
            if (card.LeftChoise.isUnique)
                CardsStorage.DeleteUniqueCard(card);
        }
    }
}
