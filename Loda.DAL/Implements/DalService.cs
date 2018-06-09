using Loda.DAL.Interfaces;
using Loda.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Loda.DAL.Implements
{
    public class DalService<T> : IDisposable, IDalService<T> where T : class, new()
    {
        private readonly MyContext _context;

        /// <summary>
        /// 获得数据库上下文
        /// </summary>
        /// <param name="context">依赖注入的数据库上下文</param>
        public DalService(MyContext context)
        {
            _context = context;
        }

        public T AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
