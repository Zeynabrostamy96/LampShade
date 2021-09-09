using _01_Farmework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace _01_Farmework.Infrastructure
{
    public class RepositoryBase<Tkey,T>: IRepository<Tkey,T> where T:class
    {
        private readonly DbContext _dbcontext;
        public RepositoryBase(DbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Create(T entity)
        {
            _dbcontext.Add(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _dbcontext.Set<T>().Any(expression);
        }

        public T Get(Tkey id)
        {
            return _dbcontext.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _dbcontext.Set<T>().ToList();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
