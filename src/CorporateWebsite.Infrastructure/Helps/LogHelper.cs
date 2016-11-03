using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace CorporateWebsite.Infrastructure.Helps
{
    /*******************************
     * FileName: LogHelper
     * Author: caixiao 
     * Description: 日志记录，用来记录业务日志和错误日志
     * CreateTime: 2015/9/17 16:06:57
     *******************************/
    public class LogHelper
    {
        private static readonly log4net.ILog LogInfo = log4net.LogManager.GetLogger("record.log");
        private static readonly log4net.ILog LogError = log4net.LogManager.GetLogger("error.log");
        

        /// <summary>
        /// 记录调试日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteDebug(string message)
        {
            LogInfo.Debug(message);
        }

        /// <summary>
        /// 记录业务日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLog(string message)
        {
            LogInfo.Info(message);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteError(Exception ex)
        {
            StringBuilder content = new StringBuilder();
            content.Append("错误源：" + ex.TargetSite.ReflectedType.FullName);
            content.Append("\r\n");
            content.Append("方法名：" + ex.TargetSite.Name);
            content.Append("\r\n");
            content.Append("错误信息：" + ex.Message);
            LogError.Error(content);
        }

        /// <summary>
        /// 记录错误日志重载
        /// </summary>
        /// <param name="classNamer">执行类名</param>
        /// <param name="functionName">当前执行的方法名</param>
        /// <param name="ex"></param>
        public static void WriteError(string classNamer,string functionName,Exception ex)
        {
            StringBuilder content = new StringBuilder();
            content.Append("当前类名：" + classNamer);
            content.Append("当前方法名：" + functionName);
            content.Append("错误源：" + ex.TargetSite.ReflectedType.FullName);
            content.Append("\r\n");
            content.Append("方法名：" + ex.TargetSite.Name);
            content.Append("\r\n");
            content.Append("错误信息：" + ex.Message);
            LogError.Error(content);
        }
    }
}
