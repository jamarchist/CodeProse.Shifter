namespace CodeProse.Shifter.partials.controls
{
    public class WeekDayCheckBoxModel
    {
        public WeekDayCheckBoxModel(string name, string abbreviation, bool @checked)
        {
            Name = name;
            Checked = @checked;
            Abbreviation = abbreviation;
        }

        public string Name { get; private set; }
        public bool Checked { get; private set; }
        public string Abbreviation { get; private set; }
    }
}