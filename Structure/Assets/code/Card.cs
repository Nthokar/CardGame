 namespace Assets.code
{
    public class Card
    {

        public string Discription;
        public Choise LeftChoise;
        public Choise RightChoise;

        public Card(Card card)
        {
            Discription = card.Discription;
            LeftChoise = card.LeftChoise;
            RightChoise = card.RightChoise;
        }
        public Card() { }
    }
}
