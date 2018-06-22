using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Loda.Entity.DataTable
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreateTime = DateTime.Now;
        }


        /// <summary>
        /// DB版号,Mysql详情参考;http://www.cnblogs.com/shanyou/p/6241612.html
        /// </summary>
        //[Timestamp]//Mysql不允许byte[]类型上标记TimeStamp/RowVersion，这里使用DateTime类型配合标记ConcurrencyCheck达到并发控制
        [ConcurrencyCheck]
        [Column("row_version")]
        public DateTime RowVersion { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
    }
}
