using System;

namespace Assets.code
{
    public class Choise
    {
        public string Description;

        public int CommunityInfluence;
        public int EmploeeInfluence;
        public int GovernmentInfluence;
        public int BalanceInfluence;

        public Tax tax;
        public Fine fine;

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

        public Choise() { }
        public Choise(Choise choise)
        {
            
        }
    }
}
