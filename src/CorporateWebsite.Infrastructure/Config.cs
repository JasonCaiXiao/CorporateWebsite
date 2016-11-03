using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;

namespace CorporateWebsite.Infrastructure
{
    /*******************************
     * FileName: Config
     * Author: caixiao 
     * Description: 读取配置文件
     * CreateTime: 2015/9/7 11:18:12
     *******************************/
    public class Config
    {
        public static string IsEnableCaching;//是否开启缓存功能
        public static string CustomCacheTimeOut;//配置开奖票据缓存过期时间
      
        static Config()
        {
            try
            {
                IsEnableCaching = ConfigurationManager.AppSettings["IsEnableCaching"];
                CustomCacheTimeOut = ConfigurationManager.AppSettings["CustomCacheTimeOut"];
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(string.Format("{0}WebConfig.xml配置文件出错，原因：{1}", DateTime.Now, ex));
            }
        }
    }
}
