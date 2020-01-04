using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DuApiDataBase
{
    /// <summary>
    /// 用来序列化Xml文件的帮助类
    /// </summary>
    public class XmlHelper
    {
        #region 反序列化  
        /// <summary>  
        /// 反序列化  ，将xml文件序列化为对象
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="xml">XML字符串</param>  
        /// <returns></returns>  
        public static T Deserialize<T>(T obj, string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(obj.GetType());
                try
                {
                    return (T)xmldes.Deserialize(sr);
                }
                catch (Exception ex)
                {
                    return default(T);
                }
            }
        }
        /// <summary>
        /// 反序列化，将xml文件序列化为对象
        /// </summary>
        /// <param name="XmlPath">文件位置</param>
        /// <param name="objtype">对象类型</param>
        /// <returns></returns>
        public static T Deserialize<T>(string XmlPath, T obj)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(XmlPath);


                T xmlObj = Deserialize(obj, xDoc.InnerXml);
                return xmlObj;
            }
            catch
            {
                return default(T);
            }

        }
        /// <summary>  
        /// 反序列化  ，将xml文件序列化为对象
        /// </summary>  
        /// <param name="type">文件类型</param>  
        /// <param name="xml">文件流</param>  
        /// <returns></returns>  
        public static object Deserialize<T>(T obj, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(obj.GetType());
            return (T)xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化  
        /// <summary>  
        /// 序列化  将对象序列化为字符串
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="obj">对象</param>  
        /// <returns></returns>  
        public static string Serializer<T>(T obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(obj.GetType());
            //序列化对象  
            xml.Serialize(Stream, obj);
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion
        /// <summary>
        /// 保存成xml文件
        /// </summary>
        /// <param name="str"></param>
        /// <param name="XmlPath"></param>
        public static void SaveAsXml(string str, string XmlPath)
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml(str);

            xdoc.Save(XmlPath);
        }

        public static void SaveAsXml<T>(T obj, string XmlPath)
        {
            SaveAsXml(Serializer<T>(obj), XmlPath);
        }
    }
}
