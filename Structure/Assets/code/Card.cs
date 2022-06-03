 namespace Assets.code
{
    public class Card
    {

        public string Description;
        public Choise LeftChoise;
        public Choise RightChoise;

        public Card(Card card)
        {
            Description = card.Description;
            LeftChoise = card.LeftChoise;
            RightChoise = card.RightChoise;
        }
        public Card() { }
    }
}
