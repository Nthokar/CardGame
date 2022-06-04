namespace Assets.code
{
    public class GouvermentRelationship
    {
        private int _value;

        public GouvermentRelationship()
        {
            _value = 5;
        }
        public int GetValue()
        {
            return _value;
        }

        public void ChangeValue(int x)
        {
            _value += x;
            if (_value > 10) _value = 10;
            if (_value <= 0 || Player.OnLose != null) Player.OnLose.Invoke();
            CheckStatus();
        }

        public void CheckStatus()
        {
            if (_value == 10) return;
            if (_value == 9) return;
            if (_value == 2) return;
            if (_value == 1) return;
            if (_value == 0) return;
            else return;
        }

        public static void BuffStrong() { }
        public static void BuffNormal() { }
        public static void DebufStrong() { }
        public static void DebuffNormal() { }
    }
}
