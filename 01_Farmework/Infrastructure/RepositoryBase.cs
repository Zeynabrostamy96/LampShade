using _01_Farmework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Farmework.Infrastructure
{
    public class RepositoryBase<TKey,T> : IRepository<TKey,T> where T:class
    {
        private readonly DbContext _dbContext;
        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _dbContext.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
