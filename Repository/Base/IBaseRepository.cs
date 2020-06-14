using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Portal.Repository.Interface
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void Add(List<TEntity> obj);
        TEntity GetById(int id);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Listar();
        int Save();
    }
}
