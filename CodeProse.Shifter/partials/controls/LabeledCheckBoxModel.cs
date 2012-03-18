namespace CodeProse.Shifter.partials.controls
{
    public class LabeledCheckBoxModel
    {
        public LabeledCheckBoxModel(string name, bool @checked)
        {
            Name = name;
            Checked = @checked;
        }

        public string Name { get; private set; }
        public bool Checked { get; private set; }
    }
}