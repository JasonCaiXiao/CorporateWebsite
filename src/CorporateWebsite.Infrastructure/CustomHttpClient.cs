using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorporateWebsite.Infrastructure
{
    /*******************************
     * FileName: CustomHttpClient
     * Author: caixiao
     * Description: 自定义http请求工具类
     * CreateTime: 2016/6/15 
     *******************************/

    public class CustomHttpClient
    {
        private HttpWebRequest _request;
        private HttpWebResponse _response;
        /// <summary>
        /// 最大请求次数
        /// </summary>
        private int _maxTry;
        /// <summary>
        /// 两次请求间隔时间
        /// </summary>
        private int _sleep;
        /// <summary>
        /// 请求超时时间
        /// </summary>
        private int _timeOut;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="maxTry">重复请求次数</param>
        /// <param name="sleep">线程休息时间</param>
        /// <param name="timeOut">请求超时时间</param>
        public CustomHttpClient(int maxTry, int sleep, int timeOut)
        {
            this._maxTry = maxTry;
            this._sleep = sleep;
            this._timeOut = timeOut;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="uriString">请求目的地址</param>
        /// <param name="sendString">需要传的数据</param>
        public string HttpPost(string uriString, byte[] sendString)
        {
            _request = (HttpWebRequest)WebRequest.Create(uriString);
            _request.Timeout = _timeOut;
            _request.Method = "POST";
            _request.Accept = "application/json";
            _request.ContentType = "application/json";
            int retry = 0;
            string result = "";
            while (retry < _maxTry)
            {
                retry++;
                try
                {
                    _response = _request.GetResponse() as HttpWebResponse;
                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream s = _response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(s, Encoding.UTF8);
                            result = reader.ReadToEnd();
                        }
                        _response.Close();
                        break;
                    }
                }
                catch (Exception)
                {
                    if (retry < _maxTry)
                    {
                        Thread.Sleep(_sleep);
                        _request = (HttpWebRequest)WebRequest.Create(uriString);
                        _request.Timeout = _timeOut;
                        _request.Method = "POST";
                        _request.Accept = "application/json";
                        _request.ContentType = "application/json";
                    }
                    else
                    {

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="uriString"></param>
        /// <returns></returns>
        public string HttpGet(string uriString)
        {
            _request = WebRequest.Create(uriString) as HttpWebRequest;
            _request.Timeout = _timeOut;
            _request.Method = "GET";
            int retry = 0;
            string result = "";
            while (retry < _maxTry)
            {
                retry++;
                try
                {
                    _response = _request.GetResponse() as HttpWebResponse;
                    if (_response.StatusCode == HttpStatusCode.OK)
                    {  
                        using (Stream s = _response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(s, Encoding.UTF8);
                            result= reader.ReadToEnd();
                        }
                        _response.Close();
                        break;
                    }
                }
                catch (Exception )
                {
                    if (retry<_maxTry)
                    {
                        Thread.Sleep(_sleep);
                        _request = WebRequest.Create(uriString) as HttpWebRequest;
                        _request.Timeout = _timeOut;
                        _request.Method = "GET";
                    }
                    else
                    {
                        
                    }
                }
            }
            return result;
        }

    }
}
