using System;
using System.Collections.Generic;

namespace RecruitmentApplication.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id, params System.Linq.Expressions.Expression<Func<T, object>>[] includes);
        List<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
