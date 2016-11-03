using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorporateWebsite.Filters
{
    /// <summary>
    /// 自定义属性--针对Ajax方式的前端页面和后台交互以Json传输数据执行出错的信息进行日志记录
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class JsonExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //返回异常JSON
                filterContext.Result = new JsonResult
                {
                    Data = new { Success = false, Message = filterContext.Exception.Message }
                };
            }
        }

    }
}