using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporateWebsite.Infrastructure;
using CorporateWebsite.Infrastructure.Helps;

namespace CorporateWebsite.Filters
{
    /// <summary>
    /// 自定义属性--记录Action执行出错的日志
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class LogExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];
                LogHelper.WriteError(controllerName,actionName, filterContext.Exception);
            }
            if (filterContext.Result is JsonResult)
            {
                //当结果为json时，设置异常已处理
                filterContext.ExceptionHandled = true;
            }
            else
            {
                //否则调用原始设置
                //base.OnException(filterContext);
                filterContext.Result = new ViewResult() { ViewName = "SystemError" };
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}