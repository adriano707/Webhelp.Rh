using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Webhelp.Rh.Domain.Repository;

namespace Webhelp.Rh.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly RhDbContext _context;

        public Repository(RhDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T> InsertAsync<T>(T entity) where T : class
        { 
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public T Update<T>(T entity) where T : class
        {
            _context.Set<T>().AddOrUpdate(entity);

            return entity;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
