using System;

namespace CodeProse.Shifter.data.mapping
{
    public interface ICustomMapper
    {
        void MapType(Action autoMap);
    }
}