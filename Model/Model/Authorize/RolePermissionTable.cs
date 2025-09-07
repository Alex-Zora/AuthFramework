using Common.Attributes;
using Model.Model.Authorize;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShanYue.Model
{
    public class RolePermissionTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       //不由数据库生成
        [SnowflakeId]
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long? PermissionId { get; set; }
        public long? ModuleId { get; set; }
        public string testFiles { get; set; } = string.Empty;
        public Role? role { get; set; }
        public Permission? permission { get; set; }
        public Module? module { get; set; }
    }
}
