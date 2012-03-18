using System;
using System.Collections.Generic;
using System.Reflection;
using CodeProse.Shifter.utility;

namespace CodeProse.Shifter.data.mapping
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