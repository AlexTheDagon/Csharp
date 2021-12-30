using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MedicalAppointments.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public Repository(MedicalAppointmentsContext dbContext)
        {
            _entities = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public IQueryable<T> Include(Expression<Func<T, object>> include)
        {
            IQueryable<T> query = _entities.Include(include);
            return query ?? _entities;
        }

        public IQueryable<T> IncludeMultiple(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities.AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query ?? _entities;
        }

    }
}
