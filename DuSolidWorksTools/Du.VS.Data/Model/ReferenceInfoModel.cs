using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Model
{
    /// <summary>
    /// 引用的dll信息
    /// </summary>
    public class ReferenceInfoModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_SolidWorksInfo">SolidWork信息</param>
        /// <param name="name">命名空间-dll名称</param>
        /// <param name="version">SolidWorks版本</param>
        /// <param name="description">描述</param>
        /// <param name="filepath">此dll的文件路径</param>
        public ReferenceInfoModel(SolidWorksInfoModel _SolidWorksInfo,string name,string version,string description,string filepath, string dllPicSource)
        {
            Name = name;
            Version = version;
            Description = description;
            FilePath = filepath;
            DllPicSource = dllPicSource;
        }

        public SolidWorksInfoModel SolidWorksInfo { get; private set; }

        /// <summary>
        /// 命名空间-dll名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// SolidWorks版本
        /// </summary>
        public string Version { get; private set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// 此dll的文件路径
        /// </summary>
        public string FilePath { get; private set; }

        public string DllPicSource { get; private set; }
    }
}
