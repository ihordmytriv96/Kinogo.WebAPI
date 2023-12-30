using System.Linq.Expressions;

namespace Kinogo.WebAPI.Domain.Common.Contracts.Filter
{
    public interface IEntityFilter<TEntity, TEntityModel>
    {
        public Expression<Func<TEntity, bool>> Filter(TEntityModel model);
    }
}
