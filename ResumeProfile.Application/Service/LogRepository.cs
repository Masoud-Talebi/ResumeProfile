namespace ResumeProfile.Application.Service
{
    public class LogRepository<TEntity> : ILogRepository<TEntity> where TEntity : class, IEntity<Guid>
    {
        private readonly ILogDbContext _dbContext;
        private DbSet<TEntity> entities;
        public LogRepository(ILogDbContext dbContext)
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
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(List<TEntity> data)
        {
            if (!data.Any())
                throw new Exception("data invalid");

            await entities.AddRangeAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAllAsync(TEntity entity)
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
            await _dbContext.SaveChangesAsync();
        }

    }
}