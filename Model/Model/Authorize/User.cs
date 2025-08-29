using ShanYue.Model.Authorize;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShanYue.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       //不由数据库生成
        public long Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(20)]
        public string NickName { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Account { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        [MaxLength(200)]
        public string Password { get; set; } = string.Empty;

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
