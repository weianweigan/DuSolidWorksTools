using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Du.VS.Model
{
    [DisplayName("插件信息")]
    public class swAddinModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Category("插件信息")]
        [DisplayName("插件名")]
        [Description("插件名")]
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Category("插件信息")]
        [DisplayName("描述")]
        [Description("插件描述")]
        public string Description { get; set; }

        /// <summary>
        /// 启动solidworks时启动solidworks
        /// </summary>
        [Category("插件信息")]
        [DisplayName("启动加载")]
        [Description("SolidWorks启动时是否默认加载SolidWorks")]
        public bool AddinStartUp { get; set; }

        /// <summary>
        /// GUID
        /// </summary>
        [Category("程序信息")] 
        [DisplayName("GUID")] 
        [Description("插件的GUID")] 
         public string GUID { get; set; }
        [Category("程序信息")]
        [DisplayName("程序集信息")]
        [Description("插件dll程序集信息")]
        public string AssemblyInfo { get;  set; }
        [Category("程序信息")]
        [DisplayName("类名")]
        [Description("插件入口类名")]
        public string ClassName { get;  set; }
        [Category("程序信息")]
        [DisplayName("CodeBase")]
        [Description("CodeBase")]
        public string CodeBase { get;  set; }
        [Category("程序信息")]
        [DisplayName(".Net版本")]
        [Description(".Net运行时版本")]
        public string DotNetRuntimeVersion { get;  set; }
      
        public string ThreadingModel { get;  set; }

    }
}
