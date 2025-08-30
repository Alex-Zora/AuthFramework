using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShanYue.Util
{
    public class JwtUtils
    { /// <summary>
      /// 使用token Descriptor(描述器)创建token  使用HmacSha256加密算法   推荐使用该方法
      /// </summary>
      /// <param name="claims"></param>
      /// <param name="expire"></param>
      /// <param name="jwtSecret"></param>
      /// <returns></returns>
        public static string CreateJwtSecurityByDecriptor(List<Claim> claims, DateTime expire, string jwtSecret, string issuer = "", string audience = "")
        {
            //转换密钥为字节数组
            var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
            //对称密]\\钥
            SecurityKey securityKey = new SymmetricSecurityKey(keyBytes);

            //jwt解释器
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                //Claims = claims.ToDictionary(x => x.Type, x => (object)x.Value),
                //在当前时间两分钟后生效
                //NotBefore = DateTime.Now.AddMinutes(2),
                Expires = expire,
                Issuer = issuer,
                Audience = audience,
                IssuedAt = DateTime.Now,
                SigningCredentials = new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256)
            };

            JsonWebTokenHandler jsonWebTokenHandler = new JsonWebTokenHandler();
            string token = jsonWebTokenHandler.CreateToken(securityTokenDescriptor);

            return token;
        }


        /// <summary>
        /// 使用JwtSecurityToken创建 使用HmacSha256加密算法 使用该方法需要在claims中添加签发时间
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="expire"></param>
        /// <param name="jwtSecret"></param>
        /// <returns></returns>
        public static string CreateJwtSecurity(List<Claim> claims, DateTime expire, string jwtSecret, string issuer = "", string audience = "")
        {
            byte[] bytes = Encoding.UTF8.GetBytes(jwtSecret);

            var secretKey = new SymmetricSecurityKey(bytes);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: expire,
                issuer: issuer,
                audience: audience,
                //notBefore: DateTime.Now.AddMinutes(2),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
