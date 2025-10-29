using Microsoft.EntityFrameworkCore;
using ResumeProfile.Application.Common.Interface;
using ResumeProfile.Domain.Entities.Common;
using ResumeProfile.Infrastructure.Persistence;

namespace ResumeProfile.Application.Service
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<long>
    {
        private readonly IApplicationDbContext _dbContext;
        protected DbSet<TEntity> entities;
        public Repository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<TEntity>();
        }


        public IQueryable<TEntity> Entities => entities.AsQueryable();

        public IQueryable<TEntity> EntitiesAsNoTracking => entities.AsNoTracking().AsQueryable();

        public async Task CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await entities.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task CreateRangeAsync(List<TEntity> data)
        {
            if (!data.Any())
                throw new Exception("data invalid");

            await entities.AddRangeAsync(data);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entities.Remove(entity);
            await SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return entities.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            var entity = await entities.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (entity == null)
                throw new Exception("Id invalid, data not found");
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            entities.Update(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}