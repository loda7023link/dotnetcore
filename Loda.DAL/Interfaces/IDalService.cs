using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Loda.DAL.Interfaces
{
    public interface IDalService<T> where T : class, new()
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        T AddEntity(T entity);

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="where">linq语句</param>
        /// <returns></returns>
        IQueryable<T> GetEntities(Expression<Func<T, bool>> where);

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
