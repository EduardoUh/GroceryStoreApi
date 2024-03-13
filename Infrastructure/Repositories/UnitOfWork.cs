using Application.Contracts.Persistence;
using Domain.Common;
using Infrastructure.Persistence;
using System.Collections;

namespace Infrastructure.Repositories
{
    public class UnitOfWork(GroceryStoreDbContext context) : IUnitOfWork
    {
        private readonly GroceryStoreDbContext _context = context;
        private Hashtable? _repositories;
        public GroceryStoreDbContext Context => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if(_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            Console.WriteLine(type);

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type]!;
        }
    }
}
