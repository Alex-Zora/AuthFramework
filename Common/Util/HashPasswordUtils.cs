using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Common.Util
{
    public class HashPasswordUtils
    {
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="salt">盐值</param>
        /// <param name="iterationCount">运算迭代次数</param>
        /// <returns></returns>
        public static string Encryption(string password, byte[] salt, int iterationCount = 500000)
        {
            string hashPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterationCount,
                numBytesRequested: 256 / 8));       //最后加密串的长度
            return hashPass;
        }

        /// <summary>
        /// 密码校验
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="salt">盐值</param>
        /// <param name="hashPass">加密串</param>
        /// <returns></returns>
        public static bool ParsePassword(string password, byte[] salt, string hashPass, int iterationCount = 500000) => hashPass.Equals(Encryption(password, salt, iterationCount)) ;

        /// <summary>
        /// 生成随机盐值
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateSalt() => RandomNumberGenerator.GetBytes(128 / 8);
    }
}
