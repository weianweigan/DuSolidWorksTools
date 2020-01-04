using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Core.Interface
{
    public interface IVisualStudioWorkSpace
    {
        /// <summary>
        /// 工作空间服务
        /// </summary>
        Microsoft.VisualStudio.LanguageServices.VisualStudioWorkspace VSWorkspace { get; set; }
    }
}
