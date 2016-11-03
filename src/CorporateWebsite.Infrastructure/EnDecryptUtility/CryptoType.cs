
namespace CorporateWebsite.Infrastructure.EnDecryptUtility
{
    /// <summary>
    /// 加密类型
    /// </summary>
    public enum CipherType
    {
        /// <summary>
        /// DES加密
        /// </summary>
        Des = 1,

        /// <summary>
        /// 三重DES加密
        /// </summary>
        TripleDes = 2,

        /// <summary>
        /// AES加密
        /// </summary>
        Aes = 3,

        /// <summary>
        /// RC2加密
        /// </summary>
        Rc2 = 4
    }
}
