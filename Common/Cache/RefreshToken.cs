using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class RefreshToken
    {
        public string Token { get; set; } = string.Empty;
        public string Device { get;set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public long UserId { get; set; }
        public DateTime ExpireDate {  get; set; }
    }
}
