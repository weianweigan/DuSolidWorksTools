using EnvDTE80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Core.Extension
{
    public static class DTE2Extension
    {
        /// <summary>
        /// 获取当前打开文件的路径
        /// </summary>
        /// <param name="dte"></param>
        /// <returns></returns>
        public static string GetActiveDocumentFilePath(this DTE2 dte)
        {
            return dte.ActiveDocument.FullName;
        }
    }
}
