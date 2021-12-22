using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalAppointments.Model.Repositories
{
    public interface IRepository<T> where T:class
    {
        public void Add(T entity);

        public IQueryable<T> GetAll();

        public T GetById(int id);

        public void Update(T entity);

        public void Delete(T entity);
        public IQueryable<T> Include(Expression<Func<T, object>> include);
        public IQueryable<T> IncludeMultiple(params Expression<Func<T, object>>[] includes);
    }
}
