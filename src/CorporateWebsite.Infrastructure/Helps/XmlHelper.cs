using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CorporateWebsite.Infrastructure.Helps
{
    public class XmlHelper
    {
        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception )
            {
                return null;
            }
        }
       
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion

        /// <summary>
        /// 获取对应XML节点的值 
        /// </summary>
        /// <param name="stringRoot">XML节点的标记</param>
        /// <param name="xmlPath">xml文件路径</param>
        /// <returns></returns>
        public static string XmlAnalysis(string stringRoot, string xmlPath)
        {
            var xmlStr = string.Empty;
            try
            {
                var xmlLoad = new XmlDocument();
                xmlLoad.Load(xmlPath);
                xmlStr = string.IsNullOrEmpty(stringRoot)
                    ? xmlLoad.DocumentElement.InnerXml
                    : xmlLoad.DocumentElement.SelectSingleNode(stringRoot).InnerXml.Trim();
            }
            catch (Exception)
            {
            }
            return xmlStr;
        }

    }
}
