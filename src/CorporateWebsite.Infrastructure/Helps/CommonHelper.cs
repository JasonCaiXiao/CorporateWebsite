using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using CorporateWebsite.Infrastructure.EnDecryptUtility;

namespace CorporateWebsite.Infrastructure.Helps
{
    public class CommonHelper
    {
        #region 生成流水号
        /// <summary>
        /// 锁对象
        /// </summary>
        private static object lockObj = new object();
        /// <summary>
        /// 计数
        /// </summary>
        private static int countNum = 0;
        /// <summary>
        /// 生成业务单号
        /// </summary>
        /// <param name="prefix">业务类型</param>
        /// <returns></returns>
        public static string GenerateSerialNum(string prefix)
        {
            string serialNum = String.Empty;
            if (String.IsNullOrEmpty(prefix))
            {
                serialNum = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else
            {
                serialNum = prefix + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            lock (lockObj)
            {
                if (countNum > 9999)
                {
                    countNum = 0;
                }
                serialNum += countNum.ToString("0000");
                countNum++;
            }
            return serialNum;
        }
        #endregion

        #region 加密解密
        /// <summary>
        /// 字符串用MD5加密（默认格式为大写）
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string strMD5)
        {
            return MD5Encrypt(strMD5, false);
        }

        /// <summary>
        /// 字符串用MD5加密
        /// </summary>
        /// <param name="strMD5">需要加密的字符串</param>
        /// <param name="toLowerCase">是否需要转换为小写（true为小写，false为大写）</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string strMD5, bool toLowerCase)
        {
            MD5 md5 = MD5.Create();
            StringBuilder md5Password = new StringBuilder();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(strMD5));
            for (int i = 0; i < data.Length; i++)
            {
                md5Password.Append(data[i].ToString("X2"));
            }
            if (toLowerCase)  //如果是小写
            {
                return md5Password.ToString().ToLower();
            }
            else
            {
                return md5Password.ToString();
            }
        }

        /// <summary>
        /// 加密 
        /// </summary>
        /// <param name="data">明文</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码格式</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns></returns>
        public static string Encrypt(string data, string key, Encoding encoding, CipherMode cipherMode, CipherType cipherType)
        {
            SymmetricCrypto encrypt = new SymmetricCrypto(encoding, cipherMode, cipherType);
            string encryptedStr = encrypt.EncryptToBase64String(data, key);
            return encryptedStr;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">明文</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码格式</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns></returns>
        public static string Decrypt(string data, string key, Encoding encoding, CipherMode cipherMode, CipherType cipherType)
        {
            SymmetricCrypto encrypt = new SymmetricCrypto(encoding, cipherMode, cipherType);
            string decryptedStr = encrypt.DecryptFromBase64String(data, key);
            return decryptedStr;
        }
        #endregion

        /// <summary>
        /// 验证手机号码（true正确，false错误）
        /// </summary>
        /// <param name="phoneNum">手机号码</param>
        /// <returns></returns>
        public static bool ValidatePhoneNum(string phoneNum)
        {
            Regex regex = new Regex("^1[3|5|7|8][0-9]{9}$");
            if (regex.IsMatch(phoneNum))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 产生N位随机数字
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns></returns>
        public static string NewRandomNum(int length)
        {
            string randomStr = "";
            string dataStr = "1234567890";
            Random random = new Random();
            int randomNum = 0;
            for (int i = 0; i < length; i++)
            {
                randomNum = Math.Abs(random.Next(dataStr.Length));
                randomStr += dataStr.Substring(randomNum, 1);
            }
            return randomStr;
        }

        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ts.Ticks.ToString();
        }

    }
}
