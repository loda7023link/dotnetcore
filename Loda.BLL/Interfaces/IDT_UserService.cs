using Loda.Entity.DataTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loda.BLL.Interfaces
{
    public interface IDT_UserService : IBllService<DT_User>
    {
        /// <summary>
        /// 插入一个新对象
        /// </summary>
        /// <returns></returns>
        DT_User Insert();

        /// <summary>
        /// 获取用户数据表
        /// </summary>
        /// <returns></returns>
        IEnumerable<DT_User> GetList();
    }
}
