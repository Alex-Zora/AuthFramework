using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShanYue.Model.Authorize
{
    public class RolePermissionTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       //不由数据库生成
        public long Id { get; set; }
        [Required]
        public long RoleId { get; set; }
        [Required]
        public long PermissionId { get; set; }
        public Role? role { get; set; }
        public Permission? permission { get; set; }
    }
}
