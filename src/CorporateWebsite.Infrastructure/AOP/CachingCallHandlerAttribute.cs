using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateWebsite.Infrastructure.Enums;

namespace CorporateWebsite.Infrastructure.AOP
{
    /// <summary>
    /// 带返回值方法的缓存属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class CacheAttribute : Attribute
    {
        /// <summary>
        /// 缓存操作方式
        /// </summary>
        public CachingMethod Method { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public TimeSpan ExpirationTime { get;set; }= new TimeSpan(0, 5, 0);

        /// <summary>
        /// 是否为相对过期
        /// </summary>
        public bool IsSliding { get; set; } = false;
        

        public CacheAttribute(CachingMethod method)
        {
            this.Method = method;
        }

        public CacheAttribute(CachingMethod method, string expiration)
            : this(method)
        {
            this.ExpirationTime = TimeSpan.Parse(expiration);
        }

        public CacheAttribute(CachingMethod method, string expiration,bool isSliding)
            : this(method,expiration)
        {
            this.IsSliding = isSliding;
        }
    }
}
