using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PersonalCloud.Shared.Models
{
    [Table("user_files")]
    [Index(nameof(CreatorId), Name = "creator_id")]
    public partial class UserFile
    {
        [Key]
        [Column("file_id")]
        public int FileId { get; set; }
        [Column("creator_id")]
        public int? CreatorId { get; set; }
        [Column("file_name")]
        [StringLength(100)]
        public string FileName { get; set; }
        [Column("file_extension")]
        [StringLength(100)]
        public string FileExtension { get; set; }
        [Column("file_content")]
        public byte[] FileContent { get; set; }
        [Column("date_added", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }

        [ForeignKey(nameof(CreatorId))]
        [InverseProperty(nameof(User.UserFiles))]
        public virtual User Creator { get; set; }
    }
}
