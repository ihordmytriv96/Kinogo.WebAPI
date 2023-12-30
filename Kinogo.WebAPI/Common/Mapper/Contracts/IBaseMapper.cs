namespace Kinogo.WebAPI.Host.Common.Mapper.Contracts
{
    public interface IBaseMapper<TSource, TDestination>
    {
        public TDestination Map(TSource map);
    }
}
