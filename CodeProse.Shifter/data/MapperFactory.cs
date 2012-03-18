using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeProse.Shifter.data
{
    public static class MapperFactory
    {
        private static readonly IDictionary<Type, ICustomMapper> mappers;

        static MapperFactory()
        {
            var shifter = Assembly.GetExecutingAssembly();
            mappers = shifter.ClassMappers();
        }

        public static IDictionary<Type, ICustomMapper> Mappers
        {
            get { return mappers; }
        }
    }
}