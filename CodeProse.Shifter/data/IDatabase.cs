using System;
using System.Data;

namespace CodeProse.Shifter.data
{
    public interface IDatabase : IDisposable
    {
        IDbConnection Connection { get; }
    }
}