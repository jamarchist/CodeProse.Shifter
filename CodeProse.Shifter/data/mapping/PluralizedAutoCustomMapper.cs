using System;

namespace CodeProse.Shifter.data.mapping
{
    public class PluralizedAutoCustomMapper<T> : CustomClassMapper<T> where T : class
    {
        public override void Table(string tableName)
        {
            TableName = String.Format("{0}s", tableName);
        }
    }
}