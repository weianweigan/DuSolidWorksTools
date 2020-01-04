using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using Du.Models;
using System.Windows;

namespace DuApiDataBase
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class Context
    {
        private static Context _myContext;

        public static Context myContext
        {
            get
            {
                if (_myContext == null)
                {
                    _myContext = new Context();
                }
                return _myContext;
            }
        }

        private static List<SolidWorksNameSpace> SolidWorksNameSpacesData;

        public List<SolidWorksNameSpace> GetData()
        {
            if (Context.SolidWorksNameSpacesData != null)
            {
                return Context.SolidWorksNameSpacesData;
            }

            SolidWorksNameSpacesData = new List<SolidWorksNameSpace>();
            Assembly assembly = Assembly.GetAssembly(typeof(Context));
            string resourceName = assembly.GetName().Name + ".g";
            ResourceManager rm = new ResourceManager(resourceName, assembly);
            using (ResourceSet set = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                //遍历资源集
                foreach (DictionaryEntry item in set)
                {
                    if (!item.Key.ToString().Contains("SolidWorks.Interop".ToLower()))
                    {
                        continue;
                    }
                    try
                    {
                        //使用资源流
                        using (System.IO.UnmanagedMemoryStream UmMS = item.Value as System.IO.UnmanagedMemoryStream)
                        {
                            if (UmMS.CanRead)
                            {
                                //反序列化
                                using (StreamReader sr = new StreamReader(UmMS))
                                {
                                    string XmlStr = sr.ReadToEnd();
                                    SolidWorksNameSpace NameSpace = new SolidWorksNameSpace();
                                    NameSpace = XmlHelper.Deserialize((NameSpace), XmlStr);
                                    if (NameSpace != null)
                                    {
                                        SolidWorksNameSpacesData.Add(NameSpace);
                                    }
                                }
                                //var NameSpace = XmlHelper.Deserialize(typeof(SolidWorksNameSpace), UmMS) as SolidWorksNameSpace;
                                //if (NameSpace != null)
                                //{
                                //    SolidWorksNameSpacesData.Add(NameSpace);
                                //}

                            }
                            Console.WriteLine(item.Key.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

            return SolidWorksNameSpacesData;
        }
    }
}
