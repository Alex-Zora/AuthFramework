using ShanYue.Model.Authorize;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShanYue.Model
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       //不由数据库生成
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public List<UserRoleTable>? UserRoles { get; set; }  = new List<UserRoleTable>();
        public List<RolePermissionTable> RolePermissions { get; set; } = new List<RolePermissionTable>();

        public Role() { }

        public Role(long id, string name, DateTime? createdDate, DateTime? updateDate, string? description)
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
            UpdateDate = updateDate;
            Description = description;
        }
}
}
