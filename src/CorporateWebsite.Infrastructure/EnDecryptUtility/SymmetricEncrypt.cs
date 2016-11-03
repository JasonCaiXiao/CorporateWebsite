using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CorporateWebsite.Infrastructure.EnDecryptUtility
{
    /// <summary>
    /// 对称加密
    /// </summary>
    public partial class SymmetricCrypto
    {
        /// <summary>
        /// 字符编码
        /// </summary>
        public Encoding Encode { get; set; }

        /// <summary>
        /// 加密模式
        /// </summary>
        public CipherMode Mode { get; set; }

        /// <summary>
        /// 加密类型
        /// </summary>
        public CipherType Type { get; set; }


        /// <summary>
        /// 构造对称加密
        /// </summary>
        public SymmetricCrypto()
        {
            Init(CipherMode.ECB, CipherType.Aes, Encoding.Default);
        }


        /// <summary>
        /// 构造对称加密
        /// </summary>
        /// <param name="cipherType">加密类型</param>
        public SymmetricCrypto(CipherType cipherType)
        {
            Init(CipherMode.ECB, cipherType, Encoding.Default);
        }


        /// <summary>
        /// 构造对称加密
        /// </summary>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        public SymmetricCrypto(CipherMode cipherMode, CipherType cipherType)
        {
            Init(cipherMode, cipherType, Encoding.Default);
        }


        /// <summary>
        /// 构造对称加密
        /// </summary>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        public SymmetricCrypto(Encoding encoding, CipherMode cipherMode, CipherType cipherType)
        {
            Init(cipherMode, cipherType, encoding);
        }


        private void Init(CipherMode cipherMode, CipherType cipherType, Encoding encode)
        {
            Mode = cipherMode;
            Type = cipherType;
            Encode = encode;
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string key)
        {
            return Convert.ToBase64String(Encrypt(plainText, key));
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string iv, string key)
        {
            return Convert.ToBase64String(Encrypt(plainText, iv, key, Encode, Mode, Type));
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string iv, string key, Encoding encoding)
        {
            return Convert.ToBase64String(Encrypt(plainText, iv, key, encoding, Mode, Type));
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string iv, string key, Encoding encoding,
            CipherMode cipherMode)
        {
            return Convert.ToBase64String(Encrypt(plainText, iv, key, encoding, cipherMode, Type));
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string iv, string key, Encoding encoding,
            CipherType cipherType)
        {
            return Convert.ToBase64String(Encrypt(plainText, iv, key, encoding, Mode, cipherType));
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string iv, string key, CipherMode cipherMode)
        {
            return Convert.ToBase64String(Encrypt(plainText, iv, key, Encode, cipherMode, Type));
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string iv, string key, CipherMode cipherMode,
            CipherType cipherType)
        {
            return Convert.ToBase64String(Encrypt(plainText, iv, key, Encode, cipherMode, cipherType));
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string iv, string key, CipherType cipherType)
        {
            return Convert.ToBase64String(Encrypt(plainText, iv, key, Encode, Mode, cipherType));
        }


        /// <summary>
        /// 加密成Base64编码的字符串
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字符串</returns>
        public string EncryptToBase64String(string plainText, string iv, string key, Encoding encoding, 
            CipherMode cipherMode, CipherType cipherType)
        {
            return Convert.ToBase64String(Encrypt(plainText, iv, key, encoding, cipherMode, cipherType));
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string key)
        {
            return Encrypt(Encode.GetBytes(plainText), Encode.GetBytes(key));
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string iv, string key)
        {
            return Encrypt(plainText, iv, key, Encode, Mode, Type);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string iv, string key, Encoding encoding)
        {
            return Encrypt(plainText, iv, key, encoding, Mode, Type);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string iv, string key, Encoding encoding, CipherMode cipherMode)
        {
            return Encrypt(plainText, iv, key, encoding, cipherMode, Type);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string iv, string key, Encoding encoding, CipherType cipherType)
        {
            return Encrypt(plainText, iv, key, encoding, Mode, cipherType);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string iv, string key, CipherMode cipherMode)
        {
            return Encrypt(plainText, iv, key, Encode, cipherMode, Type);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string iv, string key, CipherMode cipherMode, CipherType cipherType)
        {
            return Encrypt(plainText, iv, key, Encode, cipherMode, cipherType);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string iv, string key, CipherType cipherType)
        {
            return Encrypt(plainText, iv, key, Encode, Mode, cipherType);
        }

        
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(string plainText, string iv, string key, Encoding encoding, CipherMode cipherMode, 
            CipherType cipherType)
        {            
            return Encrypt(encoding.GetBytes(plainText), encoding.GetBytes(iv), encoding.GetBytes(key), cipherMode, 
                cipherType);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainArray">明文字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(byte[] plainArray, byte[] keyArray)
        {
            return Encrypt(plainArray, null, keyArray, Mode);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainArray">明文字节数组</param>
        /// <param name="ivArray">初始向量字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(byte[] plainArray, byte[] ivArray, byte[] keyArray)
        {
            return Encrypt(plainArray, ivArray, keyArray, Mode);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainArray">明文字节数组</param>
        /// <param name="ivArray">初始向量字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(byte[] plainArray, byte[] ivArray, byte[] keyArray, CipherMode cipherMode)
        {
            return Encrypt(plainArray, ivArray, keyArray, cipherMode, Type);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainArray">明文字节数组</param>
        /// <param name="ivArray">初始向量字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(byte[] plainArray, byte[] ivArray, byte[] keyArray, CipherType cipherType)
        {
            return Encrypt(plainArray, ivArray, keyArray, Mode, cipherType);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainArray">明文字节数组</param>
        /// <param name="ivArray">初始向量字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public byte[] Encrypt(byte[] plainArray, byte[] ivArray, byte[] keyArray, CipherMode cipherMode, 
            CipherType cipherType)
        {
            SymmetricAlgorithm crypto = SymmetricCryptoFactory.Create(cipherType);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = null;
            byte[] cipherBytes;

            try
            {
                crypto.Mode = cipherMode;
                crypto.Padding = PaddingMode.PKCS7;
                //设置密钥及密钥向量
                crypto.Key = keyArray;
                if (ivArray != null)
                {
                    crypto.IV = ivArray;
                }
                cs = new CryptoStream(ms, crypto.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(plainArray, 0, plainArray.Length);
                cs.FlushFinalBlock();
                cipherBytes = ms.ToArray();//得到加密后的字节数组
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cs.Close();
                ms.Close();
            }

            return cipherBytes;
        }
    }
}
