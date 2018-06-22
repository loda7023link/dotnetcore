using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Loda.Entity.DataTable
{
    public class DT_User : BaseEntity
    {
        public DT_User()
        {

        }

        [DataMember]
        [Key]
        [Column("user_id")]
        public long UserId { get; set; }

        [Required]
        [MaxLength(50)]
        [Description("用户名")]
        [Column("user_name")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(32)]
        [Description("密码")]
        [Column("user_password")]
        public string UserPassword { get; set; }

    }
}
