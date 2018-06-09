using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public long user_id { get; set; }

        [Required]
        [MaxLength(50)]
        [Description("用户名")]
        public string user_name { get; set; }

        [Required]
        [MaxLength(32)]
        [Description("密码")]
        public string user_password { get; set; }

    }
}
