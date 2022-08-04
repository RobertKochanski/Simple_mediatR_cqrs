using Microsoft.EntityFrameworkCore;

namespace cqrs.Data
{
    public class BaseRepositorie<T> : IBaseRepositorie where T : BaseModel, new()
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepositorie(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> Create(T model, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(model, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return model;
        }

        public async Task<T> Update(T model, CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);

            return model;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            var model = new T() { Id = id };

            _dbContext.Attach(model).State = EntityState.Deleted;

            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            return result > 0;
        } 

        public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }

    public interface IBaseRepositorie
    {
    }
}
