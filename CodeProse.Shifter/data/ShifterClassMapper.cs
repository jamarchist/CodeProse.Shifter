using DapperExtensions.Mapper;

namespace CodeProse.Shifter.data
{
    public class ShifterClassMapper<T> : PluralizedAutoCustomMapper<T> where T: class
    {
        protected override void AutoMap()
        {
            var mapper = MapperFactory.Mappers[typeof (T)];
            mapper.MapType(() => base.AutoMap());
        } 
    }
}