using Portal.BD;
using Portal.Data;
using Portal.Repository.Interface;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Portal.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context = null;
        protected readonly DbSet<TEntity> entidade;
        private bool _disposed;

        public BaseRepository()
        {
            if (_context == null)
                _context = new Context();
            entidade = _context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            entidade.Add(obj);
        }

        public void Add(List<TEntity> obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity obj)
        {
            throw new System.NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _context.Dispose();
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TEntity GetById(int id)
        {
           return entidade.Find(id);
        }

        public IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate)
        {
            return entidade.Where(predicate);
        }

        public IEnumerable<TEntity> Listar()
        {
            return entidade.ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
