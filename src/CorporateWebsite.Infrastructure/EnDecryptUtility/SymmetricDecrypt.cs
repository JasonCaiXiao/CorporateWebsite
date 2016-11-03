using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CorporateWebsite.Infrastructure.EnDecryptUtility
{
    partial class SymmetricCrypto
    {
        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string key)
        {
            return DecryptToString(Convert.FromBase64String(cipherText), key);
        }


        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string iv, string key)
        {
            return DecryptFromBase64String(cipherText, iv, key, Encode, Mode, Type);
        }


        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string iv, string key, Encoding encoding)
        {
            return DecryptFromBase64String(cipherText, iv, key, encoding, Mode, Type);
        }


        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string iv, string key, Encoding encoding,
            CipherMode cipherMode)
        {
            return DecryptFromBase64String(cipherText, iv, key, encoding, cipherMode, Type);
        }


        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string iv, string key, Encoding encoding,
            CipherType cipherType)
        {
            return DecryptFromBase64String(cipherText, iv, key, encoding, Mode, cipherType);
        }


        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string iv, string key, CipherMode cipherMode)
        {
            return DecryptFromBase64String(cipherText, iv, key, Encode, cipherMode, Type);
        }


        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string iv, string key, CipherMode cipherMode, 
            CipherType cipherType)
        {
            return DecryptFromBase64String(cipherText, iv, key, Encode, cipherMode, cipherType);
        }


        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string iv, string key, CipherType cipherType)
        {
            return DecryptFromBase64String(cipherText, iv, key, Encode, Mode, cipherType);
        }


        /// <summary>
        /// 从加密的Base64编码的字符串中解密成明文字符串
        /// </summary>
        /// <param name="cipherText">加密的字符串</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptFromBase64String(string cipherText, string iv, string key, Encoding encoding,
            CipherMode cipherMode, CipherType cipherType)
        {
            return DecryptToString(Convert.FromBase64String(cipherText), iv, key, encoding, cipherMode, cipherType);
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="key">初始密钥字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string key)
        {
            return Encode.GetString(Decrypt(cipherArray, Encode.GetBytes(key))).TrimEnd('\0');
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">初始密钥字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string iv, string key)
        {
            return DecryptToString(cipherArray, iv, key, Encode, Mode, Type);
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">初始密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string iv, string key, Encoding encoding)
        {
            return DecryptToString(cipherArray, iv, key, encoding, Mode, Type);
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">初始密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string iv, string key, Encoding encoding,
            CipherMode cipherMode)
        {
            return DecryptToString(cipherArray, iv, key, encoding, cipherMode, Type);
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">初始密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string iv, string key, Encoding encoding,
            CipherType cipherType)
        {
            return DecryptToString(cipherArray, iv, key, encoding, Mode, cipherType);
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">初始密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string iv, string key, CipherMode cipherMode)
        {
            return DecryptToString(cipherArray, iv, key, Encode, cipherMode, Type);
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">初始密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string iv, string key, CipherMode cipherMode, 
            CipherType cipherType)
        {
            return DecryptToString(cipherArray, iv, key, Encode, cipherMode, cipherType);
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">初始密钥字符串</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string iv, string key, CipherType cipherType)
        {
            return DecryptToString(cipherArray, iv, key, Encode, Mode, cipherType);
        }


        /// <summary>
        /// 解密成字符串
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">初始密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回加密后的字符串</returns>
        public string DecryptToString(byte[] cipherArray, string iv, string key, Encoding encoding,
            CipherMode cipherMode, CipherType cipherType)
        {
            return encoding.GetString(Decrypt(cipherArray, iv, key, encoding, cipherMode, cipherType)).TrimEnd('\0');
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="key">密钥字符串</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string key)
        {
            return Decrypt(cipherArray, Encode.GetBytes(key));
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string iv, string key)
        {
            return Decrypt(cipherArray, iv, key, Encode, Mode, Type);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string iv, string key, Encoding encoding)
        {
            return Decrypt(cipherArray, iv, key, encoding, Mode, Type);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string iv, string key, Encoding encoding, CipherMode cipherMode)
        {
            return Decrypt(cipherArray, iv, key, encoding, cipherMode, Type);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string iv, string key, Encoding encoding, CipherType cipherType)
        {
            return Decrypt(cipherArray, iv, key, encoding, Mode, cipherType);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string iv, string key, CipherMode cipherMode)
        {
            return Decrypt(cipherArray, iv, key, Encode, cipherMode, Type);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string iv, string key, CipherMode cipherMode, CipherType cipherType)
        {
            return Decrypt(cipherArray, iv, key, Encode, cipherMode, cipherType);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string iv, string key, CipherType cipherType)
        {
            return Decrypt(cipherArray, iv, key, Encode, Mode, cipherType);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="iv">初始向量字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, string iv, string key, Encoding encoding, CipherMode cipherMode,
            CipherType cipherType)
        {
            return Decrypt(cipherArray, encoding.GetBytes(iv), encoding.GetBytes(key), cipherMode, cipherType);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, byte[] keyArray)
        {
            return Decrypt(cipherArray, null, keyArray, Mode, Type);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="ivArray">初始向量字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, byte[] ivArray, byte[] keyArray)
        {
            return Decrypt(cipherArray, ivArray, keyArray, Mode, Type);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="ivArray">初始向量字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <param name="cipherMode">加密模式</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, byte[] ivArray, byte[] keyArray, CipherMode cipherMode)
        {
            return Decrypt(cipherArray, ivArray, keyArray, cipherMode, Type);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="ivArray">初始向量字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, byte[] ivArray, byte[] keyArray, CipherType cipherType)
        {
            return Decrypt(cipherArray, ivArray, keyArray, Mode, cipherType);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherArray">加密的字节数组</param>
        /// <param name="ivArray">初始向量字节数组</param>
        /// <param name="keyArray">密钥字节数组</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="cipherType">加密类型</param>
        /// <returns>返回解密后的字节数组</returns>
        public byte[] Decrypt(byte[] cipherArray, byte[] ivArray, byte[] keyArray, CipherMode cipherMode,
            CipherType cipherType)
        {
            SymmetricAlgorithm crypto = SymmetricCryptoFactory.Create(cipherType);
            MemoryStream ms = new MemoryStream(cipherArray);
            CryptoStream cs = null;
            byte[] decryptBytes;

            try
            {
                crypto.Mode = cipherMode;
                crypto.Padding = PaddingMode.PKCS7;
                crypto.Key = keyArray;
                if (ivArray != null)
                {
                    crypto.IV = ivArray;
                }
                cs = new CryptoStream(ms, crypto.CreateDecryptor(), CryptoStreamMode.Read);
                decryptBytes = new byte[cipherArray.Length];
                cs.Read(decryptBytes, 0, decryptBytes.Length);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cs.Close();
                ms.Close();
            }
            return decryptBytes;
        }
    }
}
