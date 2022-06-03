using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.code
{
    public class IndicatorsManager : MonoBehaviour
    {
        public Text Balance;
        public Text MoneyPerTurn;
        public GameObject communitiIndicator;
        public GameObject emploeeiIndicator;
        public GameObject gouvermentIndicator;

        public Action OnChangeValue;
        public void Awake()
        {
            LoadIndicators();
            UpdateData();
        }
        public void LoadIndicators()
        {
            var transform = GameObject.Find("UpperMenu").transform;
            communitiIndicator = GameObject.Instantiate(communitiIndicator, transform);
            communitiIndicator.transform.SetParent(transform);
            emploeeiIndicator = GameObject.Instantiate(emploeeiIndicator, transform);
            emploeeiIndicator.transform.SetParent(transform);
            gouvermentIndicator = GameObject.Instantiate(gouvermentIndicator, transform);
            gouvermentIndicator.transform.SetParent(transform);
        }
        public void UpdateData()
        {
            communitiIndicator.GetComponentInChildren<Indicator>().currentPoints = Player.community.GetValue();
            emploeeiIndicator.GetComponentInChildren<Indicator>().currentPoints = Player.emploee.GetValue();
            gouvermentIndicator.GetComponentInChildren<Indicator>().currentPoints = Player.gouverment.GetValue();
            Balance.text = Player.Balance.ToString() + '$';
            MoneyPerTurn.text = '+' + Player.GetMoneyPerTurn().ToString() + "$ per turn";
        }
        public void PlayChangeIndicator(Choise choise)
        {
            if (choise == null)
            {
                emploeeiIndicator.GetComponentInChildren<Indicator>().changeIndicator.color = new Color(1,1,1,0);
                gouvermentIndicator.GetComponentInChildren<Indicator>().changeIndicator.color = new Color(1, 1, 1, 0);
                communitiIndicator.GetComponentInChildren<Indicator>().changeIndicator.color = new Color(1, 1, 1, 0);
                return;
            }
            if (choise.EmploeeInfluence != 0)
                StartCoroutine(emploeeiIndicator.GetComponentInChildren<Indicator>().ChangeIndicatorAnimation());

            if (choise.GovernmentInfluence != 0)
                StartCoroutine(gouvermentIndicator.GetComponentInChildren<Indicator>().ChangeIndicatorAnimation());

            if (choise.CommunityInfluence != 0)
                StartCoroutine(communitiIndicator.GetComponentInChildren<Indicator>().ChangeIndicatorAnimation());
        }
    }
} 