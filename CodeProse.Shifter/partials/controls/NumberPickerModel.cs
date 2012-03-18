namespace CodeProse.Shifter.partials.controls
{
    public class NumberPickerModel
    {
        public NumberPickerModel(int minValue, int maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public int MaxValue { get; private set; }
        public int MinValue { get; private set; }
    }
}