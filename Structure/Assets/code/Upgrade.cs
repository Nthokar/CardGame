using UnityEngine;
using UnityEngine.UI;

namespace Assets.code
{
    public class Upgrade : MonoBehaviour
    {
        Image icon;
        Button buyButton;
        public string Descriprion;
        public Text priceText;
        public GameObject instance;

        [SerializeField]
        public int Price;
        [SerializeField]
        private int _priceIncreaseValue;
        [SerializeField]
        private float _priceIncreaseProcent;

        [SerializeField]
        public int MoneyPerTurnValue;
        [SerializeField]
        public float MoneyPerTurnProcent;

        public void Start()
        {
            UpdatePrice();
        }
        public void OnBuy()
        {
            if (Player.Balance < Price) return;
            Player.MoneyPerTurn += MoneyPerTurnValue;
            if (MoneyPerTurnProcent != 0) Player.taxes.Add(new Tax((float) MoneyPerTurnProcent, 0, null));
            Player.Balance -= (int) Price;
            GameObject.Find("IndicatorsManager").GetComponent<IndicatorsManager>().UpdateData();
            IncreasePrice();
            UpdatePrice();
        }

        private void IncreasePrice()
        {
            Price += _priceIncreaseValue;
            Price = (int) (Price * (1 + _priceIncreaseProcent)); 
        }

        private void UpdatePrice()
        {
            priceText.text = Price.ToString() + '$';
        }
    }
}
