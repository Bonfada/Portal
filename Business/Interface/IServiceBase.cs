using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Interface
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Add(List<TEntity> obj);
        TEntity GetById(int id);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Listar();
    }
}
