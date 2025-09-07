using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class TokenModel
    {
        public string AccessToken {  get; set; } = string.Empty;
        public string RefreshToken {  get; set; } = string.Empty;  

        public TokenModel() { }
        public TokenModel(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
