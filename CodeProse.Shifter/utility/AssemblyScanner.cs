using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeProse.Shifter.data;
using CodeProse.Shifter.data.mapping;

namespace CodeProse.Shifter.utility
{
    public static class AssemblyScanner
    {
        /// <summary>
        /// Scans an assembly for Types in a 'domain' namespace associates them with a mapper
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IDictionary<Type, ICustomMapper> ClassMappers(this Assembly assembly)
        {
            var mappers = new Dictionary<Type, ICustomMapper>();
            foreach (var @class in assembly.DomainClasses())
            {
                var mapperType = assembly.MapperFor(@class);
                var mapper = Activator.CreateInstance(mapperType) as ICustomMapper;

                mappers.Add(@class, mapper);
            }

            return mappers;
        }

        private static IEnumerable<Type> DomainClasses(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => !String.IsNullOrEmpty(t.Namespace) && t.Namespace.Contains(".domain"));
        }

        private static Type MapperFor(this Assembly assembly, Type domainType)
        {
            return assembly.CustomMappers().FirstOrDefault(t => !t.ContainsGenericParameters && t.BaseType.GetGenericArguments()[0] == domainType) ??
                    typeof (PluralizedAutoCustomMapper<>).MakeGenericType(domainType);
        }

        private static IEnumerable<Type> CustomMappers(this Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(t => typeof (ICustomMapper).IsAssignableFrom(t))
                .Where(t => t != typeof(ICustomMapper))
                .Where(t => t != typeof(CustomClassMapper<>))
                .Where(t => t != typeof(PluralizedAutoCustomMapper<>));
        }
    }
}