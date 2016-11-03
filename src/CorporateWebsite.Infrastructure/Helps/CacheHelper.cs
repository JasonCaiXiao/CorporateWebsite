using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CorporateWebsite.Infrastructure.Helps
{
    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum CacheKey
    {
        StrPermissionsByUid,
        AssistList,
        WorkOrderYearData,
        UploadAttachment,
        ProjectName,
        CheckPasswordForLogin,
        CheckPasswordForTime,
        ChangeAssist,
        ProjectAll
    }
    public class CacheHelper
    {
        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public static bool Exists(string cacheKey)
        {
            return GetCache(cacheKey)!=null;
        }
        
        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public static object GetCache(string cacheKey)
        {
            var objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject);
        }

        /// <summary>
        /// 相对过期-数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject, TimeSpan timeout)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, timeout, System.Web.Caching.CacheItemPriority.NotRemovable, null);
        }

        /// <summary>
        /// 绝对过期-数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject, DateTime absoluteExpiration)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);
        }

        /// <summary>
        /// 绝对与相对过期-数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static void RemoveCache(string cacheKey)
        {
            var cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            var cache = HttpRuntime.Cache;
            var cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}
