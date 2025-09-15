using Model.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Table.Authorize
{
    [Index(nameof(Account),IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       //不由数据库生成
        [SnowflakeId]
        public long Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(20)]
        public string NickName { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Account { get; set; } = string.Empty;
        [MaxLength(256)]
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// 密码盐值
        /// </summary>
        [MaxLength(128)]
        public string? PasswordSalt { get; set; } = string.Empty;
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改密码、 强制下线、登出
        /// </summary>
        public int TokenVersion { get; set; } = 0;

        public List<UserRoleTable> UserRoles { get; set; } = new List<UserRoleTable>();

        public User() { }

        public User(long id, string name, string nickName, string account, string? email, DateTime? createTime, DateTime? updateTime, string password)
        {
            Id = id;
            Name = name;
            NickName = nickName;
            Account = account;
            Email = email;
            CreateTime = createTime;
            UpdateTime = updateTime;
            Password = password;
        }
    }
}
