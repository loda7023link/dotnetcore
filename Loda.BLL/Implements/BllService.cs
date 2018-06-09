using Loda.BLL.Interfaces;
using Loda.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Loda.BLL.Implements
{
    /// <summary>
    /// 数据逻辑层：BLL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BllService<T> : IBllService<T> where T : class, new()
    {

        /// <summary>
        /// 数据库服务
        /// </summary>
        protected IDalService<T> _dal;

        public BllService(IDalService<T> dal)
        {
            _dal = dal;
        }


        public T AddEntity(T entity, bool isSave)
        {
            entity = _dal.AddEntity(entity);
            if (isSave)
            {
                if (SaveChanges() > 0)
                    return null;
            }
            return entity;
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> where)
        {
            return _dal.GetEntities(where);
        }

        public int SaveChanges()
        {
            return _dal.SaveChanges();
        }
    }

}
