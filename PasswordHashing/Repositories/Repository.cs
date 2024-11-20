using Microsoft.EntityFrameworkCore;
using PasswordHashing.Data;

namespace PasswordHashing.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PasswordDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(PasswordDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); 
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable(); 
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges(); 
        }

        public void Save()
        {
            _context.SaveChanges(); 
        }
    }
}