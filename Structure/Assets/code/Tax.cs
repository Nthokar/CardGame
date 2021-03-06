namespace Assets.code
{
    public class Tax
    {
        public float Procent;
        public int Value;
        public int? TurnDuration;

        public Tax(float procent, int value, int? turnDuration)
        {
            this.Procent = procent;
            this.Value = value;
            this.TurnDuration = turnDuration;
        }
        public Tax(Tax tax)
        {
            this.Procent = tax.Procent;
            this.Value = tax.Value;
            this.TurnDuration = tax.TurnDuration;
        }

        public Tax() { }
    }
}
