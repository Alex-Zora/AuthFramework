using Model.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Table.Authorize
{
    public class UserRoleTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       //不由数据库生成
        [SnowflakeId]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long RoleId { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
