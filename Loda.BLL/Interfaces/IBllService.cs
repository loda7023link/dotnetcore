using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Loda.BLL.Interfaces
{
    public interface IBllService<T> where T : class, new()
    {
        T AddEntity(T entity, bool isSave);

        IQueryable<T> GetEntities(Expression<Func<T, bool>> where);

        int SaveChanges();
    }
}
