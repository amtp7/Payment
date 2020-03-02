
namespace Payments.Infrastructure.IMappers
{
    public interface IMapper<TEntity_EF, TEntity>
    {
        TEntity ToModel(TEntity_EF efEntity);
        TEntity_EF ToDbModel(TEntity entity);
    }
}
