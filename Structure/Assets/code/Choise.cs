using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.code
{
    public class Choise
    {
        public int CommunityInfluence;
        public int EmploeeInfluence;
        public int GovernmentInfluence;
        public int BalanceInfluence;

        public Tax tax;

        public string Description;

        public Card[] Cards;

        public bool IsCardsEmpty()
        {
            return Cards == null || Cards.Length == 0;
        }

        public Card GetRandomCard()
        {
            Random rnd = new Random();
            int rndIndex = rnd.Next(0, Cards.Length);
            return Cards[rndIndex]; 
        }
    }
}
