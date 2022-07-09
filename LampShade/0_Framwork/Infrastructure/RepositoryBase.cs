using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framwork.Domain;
using Microsoft.EntityFrameworkCore;

namespace _0_Framwork.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext db;

        public RepositoryBase(DbContext db)
        {
            this.db = db;
        }
        public void Create(T Entity)
        {
            db.Add(Entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Any(expression);
        }

        public T GetCategoryBy(TKey Id)
        {
            return db.Set<T>().Find(Id);
        }

        public List<T> Get()
        {
            return db.Set<T>().ToList();
        }

        public void SaveChanges()
        {
           db.SaveChanges();
        }
    }
}
