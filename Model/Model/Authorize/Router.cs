using Common.Attributes;
using ShanYue.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model.Authorize
{
    /// <summary>
    /// 前端路由信息
    /// </summary>
    public class Router
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [SnowflakeId]
        public long Id { get; set; }

        [MaxLength(20)]
        [Required]
        public required string Path { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Icon { get; set; } = string.Empty;
        public DateTime CreteTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime {  get; set; } = DateTime.Now;
        public long CreateId { get; set; }
        public long CreateBy { get; set; }
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        public List<RolePermissionTable> rolePermissionTable { get; set; } = new List<RolePermissionTable>();
    }
}
