using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.code
{
    public class Upgrade : MonoBehaviour
    {
        Image icon;
        Button buyButton;
        public string Descriprion;

        public int Cost;
        public int MoneyPerTurn;

        public void OnBuy()
        {
            Player.MoneyPerTurn += MoneyPerTurn;
            Player.Balance -= Cost;
            GameObject.Find("IndicatorsManager").GetComponent<IndicatorsManager>().UpdateData();
        }
    }
}
