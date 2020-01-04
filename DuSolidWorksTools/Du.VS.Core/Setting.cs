using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Core
{
    /// <summary>
    /// 设置类-单例模式
    /// </summary>
    public class Setting
    {
        private static readonly Lazy<Setting> lazy =
           new Lazy<Setting>(() => new Setting());

        private Setting() {}

        public static Setting Instance { get { return lazy.Value; } }
        /// <summary>
        /// Api打开方式
        /// </summary>
        public ApiHelpOpen_Enum OpenMethod { get; set; }
    }

    public enum ApiHelpOpen_Enum
    {
        InToolBox,
        InToolBoxWithBrowse,
        InVisualStudioBrowser,
        InOuterBroser
    }
}
