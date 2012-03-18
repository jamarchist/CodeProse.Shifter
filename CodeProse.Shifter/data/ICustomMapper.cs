using System;

namespace CodeProse.Shifter.data
{
    public interface ICustomMapper
    {
        void MapType(Action autoMap);
    }
}