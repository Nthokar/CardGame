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
            communitiIndicator.GetComponentInChildren<Indicator>().currentPoints = Player.community.GetValue();
            emploeeiIndicator.GetComponentInChildren<Indicator>().currentPoints = Player.emploee.GetValue();
            gouvermentIndicator.GetComponentInChildren<Indicator>().currentPoints = Player.gouverment.GetValue();
            text.text = Player.Balance.ToString() + '$';
        }
    }
} 