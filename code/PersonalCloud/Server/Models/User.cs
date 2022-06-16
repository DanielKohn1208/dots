using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PersonalCloud.Server.Models
{
    [Table("users")]
    public partial class User
    {
        public User()
        {
            UserFiles = new HashSet<UserFile>();
        }

        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("user_name")]
        [StringLength(24)]
        public string UserName { get; set; }
        [Column("salt")]
        [StringLength(255)]
        public string Salt { get; set; }
        [Column("password")]
        [StringLength(100)]
        public string Password { get; set; }
        [Column("isroot")]
        public bool Isroot { get; set; }

        [InverseProperty(nameof(UserFile.Creator))]
        public virtual ICollection<UserFile> UserFiles { get; set; }

    }
}
