using Loda.BLL.Interfaces;
using Loda.DAL.Interfaces;
using Loda.Entity.DataTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Loda.BLL.Implements
{
    public class DT_UserService : BllService<DT_User>, IDT_UserService
    {
        /// <summary>
        /// 用于实例化父级
        /// </summary>
        /// <param name="rep"></param>
        public DT_UserService(IDalService<DT_User> dal) : base(dal)
        {

        }

        public IEnumerable<DT_User> GetList()
        {
            return GetEntities(r => true);
        }

        public DT_User Insert()
        {
            DT_User user = new DT_User
            {
                UserName = "test-" + new Random().Next(10000),
                UserPassword = DateTime.Now.ToString()
            };

            return AddEntity(user, true);
        }
    }
}
