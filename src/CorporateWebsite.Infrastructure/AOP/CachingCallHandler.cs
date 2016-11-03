using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using Castle.DynamicProxy;
using CorporateWebsite.Infrastructure.Enums;
using CorporateWebsite.Infrastructure.Helps;

namespace CorporateWebsite.Infrastructure.AOP
{
    /// <summary>
    /// 方法函数返回值缓存操作-使用AutoFac进行AOP
    /// </summary>
    public class CachingCallHandler : IInterceptor
    {
        /// <summary>
        /// 生成缓存值的键值
        /// </summary>
        /// <param name="method"></param>
        /// <param name="invocation"></param>
        /// <returns></returns>
        private string GetValueKey(CachingMethod method, IInvocation invocation)
        {
            switch (method)
            {
                // 如果是Remove，则不存在特定值键名，所有的以该方法名称相关的缓存都需要清除
                case CachingMethod.Remove:
                    return null;
                // 如果是Get或者Update，则需要产生一个针对特定参数值的键名
                case CachingMethod.Get:
                case CachingMethod.Update:
                    if (invocation.Arguments != null &&
                        invocation.Arguments.Length > 0)
                    {
                        var sb = new StringBuilder();
                        for (var i = 0; i < invocation.Arguments.Length; i++)
                        {
                            sb.Append(invocation.Arguments[i]);
                            if (i != invocation.Arguments.Length - 1)
                                sb.Append("_");
                        }
                        return sb.ToString();
                    }
                    else
                        return "NULL";
                default:
                    throw new InvalidOperationException("无效的缓存方式。");
            }
        }

     
        public void Intercept(IInvocation invocation)
        {
            // 获得被拦截的方法
            var method = invocation.Method;
            // 如果拦截的方法定义了Cache属性，说明需要对该方法的结果需要进行缓存
            if (method.IsDefined(typeof (CacheAttribute), false))
            {   
                var cachingAttribute = (CacheAttribute)method.GetCustomAttributes(typeof(CacheAttribute), false)[0];
                var key = GetValueKey(cachingAttribute.Method, invocation);
                var valueKey =string.Concat(method.Name,"_", key);
                switch (cachingAttribute.Method)
                {
                    case CachingMethod.Get:
                        try
                        {
                            // 如果缓存中存在该键值的缓存，则直接返回缓存中的结果退出
                            if (CacheHelper.Exists(valueKey))
                            {
                                invocation.ReturnValue = CacheHelper.GetCache(valueKey);
                            }
                            else // 否则先调用方法，再把返回结果进行缓存
                            {
                                invocation.Proceed();
                                var time = cachingAttribute.ExpirationTime;
                                if (cachingAttribute.IsSliding)
                                {
                                    CacheHelper.SetCache(valueKey, invocation.ReturnValue,time);
                                }
                                else
                                {
                                    CacheHelper.SetCache(valueKey, invocation.ReturnValue,DateTime.Now.AddSeconds(time.Seconds));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            
                        }
                        break;
                    case CachingMethod.Update:
                        try
                        {
                            invocation.Proceed();
                            var time = cachingAttribute.ExpirationTime;
                            if (cachingAttribute.IsSliding)
                            {
                                CacheHelper.SetCache(valueKey, invocation.ReturnValue, time);
                            }
                            else
                            {
                                CacheHelper.SetCache(valueKey, invocation.ReturnValue, DateTime.Now.AddSeconds(time.Seconds));
                            }
                        }
                        catch (Exception ex)
                        {
                           
                        }
                    break;
                    case CachingMethod.Remove:
                        try
                        {
                            if (CacheHelper.Exists(valueKey))
                            {
                               CacheHelper.RemoveCache(valueKey);
                            }
                        }
                        catch (Exception ex)
                        {
                           
                        }
                    break;
                }
            }
        }
    }
}
