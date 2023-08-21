using BookLibraryApi.Data;
using BookLibraryApi.Models;
using BookLibraryApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Repositories
{
    public class Repository : IRepository<Book>
    {
        public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            private readonly AppDbContext _context;
            private readonly DbSet<TEntity> _dbSet;

            public Repository(AppDbContext context)
            {
                _context = context;
                _dbSet = _context.Set<TEntity>();
            }

            public void Add(TEntity entity)
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }

            public void Delete(TEntity entity)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }

            public IEnumerable<TEntity> GetAll()
            {
                return _dbSet.ToList();
            }

            public TEntity GetById(int id)
            {
                // Assuming every entity will have an "Id" as a primary key. 
                // This may not be true for all cases, and you might want to adjust this method accordingly.
                return _dbSet.Find(id);
            }

            public void Update(TEntity entity)
            {
                _dbSet.Update(entity);
                _context.SaveChanges();
            }
        
    }
