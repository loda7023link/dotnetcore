using Loda.Entity.DataTable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loda.Entity
{
    public class MyContext : DbContext
    {
        public MyContext() : base()
        {

        }

        public MyContext(DbContextOptions<MyContext> options)
                    : base(options)
        {

        }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        #region 数据表

        public DbSet<DT_User> DT_User { get; set; }

        #endregion
    }
}
