using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShanYue.Model
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       //不由数据库生成
        public long Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Url { get; set; } = string.Empty;
        [MaxLength(30)]
        public string? Code { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public List<RolePermissionTable>? RolePermissions { get; set; } = new List<RolePermissionTable>();
        [MaxLength(1)]
        public int type { get; set; }

        public Permission() { }

        public Permission(long Id, string Name, string Url, string Code, DateTime CreatedDate, DateTime UpdateDate, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Url = Url;
            this.Code = Code;
            this.CreatedDate = CreatedDate;
            this.UpdateDate = UpdateDate;
            this.Description = Description;
        }
    }
}
