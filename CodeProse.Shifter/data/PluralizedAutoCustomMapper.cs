using System;

namespace CodeProse.Shifter.data
{
    public class PluralizedAutoCustomMapper<T> : CustomClassMapper<T> where T : class
    {
        public override void Table(string tableName)
        {
            TableName = String.Format("{0}s", tableName);
        }
    }
}