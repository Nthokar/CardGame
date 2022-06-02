namespace Assets.code
{
    public static class Scale
    {
        private static int _value;

        public static int GetValue()
        {
            return _value;
        }

        public static void ChangeValue(int x)
        {
            _value += x;
            if (_value > 10) _value = 10;
            if (_value < 0) _value = 0;
        }
    }
}
