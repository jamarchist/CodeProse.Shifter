using System;
using DapperExtensions.Mapper;

namespace CodeProse.Shifter.data.mapping
{
    public class CustomClassMapper<T> : PluralizedAutoClassMapper<T>, ICustomMapper where T : class
    {
        void ICustomMapper.MapType(Action autoMap)
        {
            autoMap();
        }
    }
}