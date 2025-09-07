using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public  class UserInfo
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
