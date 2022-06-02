using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.code
{
    public class IndicatorsManager : MonoBehaviour
    {
        public Text text;
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
            communitiIndicator.GetComponent<Indicator>().currentPoints = Player.community.GetValue();
            emploeeiIndicator.GetComponent<Indicator>().currentPoints = Player.emploee.GetValue();
            gouvermentIndicator.GetComponent<Indicator>().currentPoints = Player.gouverment.GetValue();
            text.text = Player.Balance.ToString() + '$';
        }
        public void PlayChangeIndicator(Choise choise)
        {
            if (choise == null)
            {
                emploeeiIndicator.GetComponent<Indicator>().changeIndicator.color = new Color(1,1,1,0);
                gouvermentIndicator.GetComponent<Indicator>().changeIndicator.color = new Color(1, 1, 1, 0);
                communitiIndicator.GetComponent<Indicator>().changeIndicator.color = new Color(1, 1, 1, 0);
                return;
            }
            if (choise.EmploeeInfluence != 0)
                StartCoroutine(emploeeiIndicator.GetComponent<Indicator>().ChangeIndicatorAnimation());

            if (choise.GovernmentInfluence != 0)
                StartCoroutine(gouvermentIndicator.GetComponent<Indicator>().ChangeIndicatorAnimation());

            if (choise.CommunityInfluence != 0)
                StartCoroutine(communitiIndicator.GetComponent<Indicator>().ChangeIndicatorAnimation());
        }
    }
} 