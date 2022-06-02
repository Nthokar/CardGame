using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.code
{
    public static class Player
    {
        public static int Balance = 1000;
        public static int MoneyPerTurn = 100;
        public static List<Tax> taxes = new List<Tax>();

        public static Action OnDataChange;

        public static CommunityRelationship community = new CommunityRelationship();
        public static EmploeeRelationship emploee = new EmploeeRelationship();
        public static GouvermentRelationship gouverment = new GouvermentRelationship();

        public static void SetDefault()
        {
            Balance = 1000;
            MoneyPerTurn = 100;
            taxes = new List<Tax>();
            OnDataChange = null;
            community = new CommunityRelationship();
            emploee = new EmploeeRelationship();
            gouverment = new GouvermentRelationship();

        }
        public static void Recount(Choise choise)
        {
            if (choise == null) return;
            Balance += choise.BalanceInfluence;
            community.ChangeValue(choise.CommunityInfluence);
            emploee.ChangeValue(choise.EmploeeInfluence);
            gouverment.ChangeValue(choise.GovernmentInfluence);
            if (choise.tax != null)
                taxes.Add(choise.tax);
            OnDataChange.Invoke();
        }

        public static void GetMoneyByTurn()
        {
            Balance += (Int32) (MoneyPerTurn * (1f - GetAllTaxesProcent()) ) - GetAllTaxesValues();
            TaxesUpdateDurarion();
            OnDataChange.Invoke();
        }

        private static int GetAllTaxesValues()
        {
            int result = 0;
            foreach (Tax tax in taxes)
            {
                if (tax.TurnDuration == null)
                    continue;
                if (tax.TurnDuration > 0)
                    result += tax.Value;
            }
            return result;
        }

        private static void TaxesUpdateDurarion()
        {
            List<Tax> taxesOnRemove = new List<Tax>();
            foreach (Tax tax in taxes)
            {
                if (tax.TurnDuration == null)
                    continue;
                if (tax.TurnDuration > 0)
                    tax.TurnDuration--;
                else
                    taxesOnRemove.Add(tax);
            }
            foreach(Tax tax in taxesOnRemove)
            {
                taxes.Remove(tax);
            }
        }

        private static float GetAllTaxesProcent()
        {
            float result = 0;
            foreach (Tax tax in taxes)
            {
                if (tax.TurnDuration > 0)
                    result += tax.Procent;
            }
            return result;
        }
    }
}