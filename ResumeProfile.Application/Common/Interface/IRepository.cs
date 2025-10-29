using ResumeProfile.Domain.Entities.Common;

namespace ResumeProfile.Application.Common.Interface
{
    public interface IRepository<TEntity> where TEntity : class,IEntity<long>
    {
        IQueryable<TEntity> Entities { get; }
        IQueryable<TEntity> EntitiesAsNoTracking { get; }
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid Id);
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(List<TEntity> entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid Id);
        Task DeleteAsync(TEntity entity);

    }
}