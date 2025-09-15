using Model.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Table.Authorize
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [SnowflakeId]
        public long Id { get; set; }
        /// <summary>
        /// 菜单执行Action名
        /// </summary>
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// 菜单显示名（如用户页、编辑(按钮)、删除(按钮)）
        /// </summary>
        [MaxLength(50)]
        public string? Name { get; set; }
        /// <summary>
        /// 是否是按钮
        /// </summary>
        [Required]
        public bool IsButton { get; set; } = false;
        /// <summary>
        /// 是否是隐藏菜单
        /// </summary>
        public bool? IsHide { get; set; } = false;
        /// <summary>
        /// 是否keepAlive
        /// </summary>
        public bool? IsKeepAlive { get; set; } = false;
        /// <summary>
        /// 按钮事件
        /// </summary>
        [MaxLength(50)]
        public string? Func { get; set; } = string.Empty ;

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int OrderSort { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [MaxLength(50)]
        public string? Icon { get; set; } = string.Empty;
        /// <summary>
        /// 菜单图标新
        /// </summary>
        [MaxLength(50)]
        public string? IconNew { get; set; } = string.Empty;
        /// <summary>
        /// 菜单描述    
        /// </summary>
        [MaxLength(100)]
        public string? Description { get; set; } = string.Empty;
        /// <summary>
        /// 激活状态
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 创建ID
        /// </summary>
        public long? CreateId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [MaxLength(50)]
        public string? CreateBy { get; set; } = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改ID
        /// </summary>
        public long? UpdateId { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [MaxLength(50)]
        public string? UpdateBy { get; set; } = string.Empty;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 上一级菜单（0表示上一级无菜单）
        /// </summary>
        public long ParentId { get; set; } = 0;
        /// <summary>
        /// 接口api
        /// </summary>
        public long PermissionId { get; set; } = 0;
        public List<RolePermissionTable> RolePermissions { get; set; } = new List<RolePermissionTable>();
    }
}
