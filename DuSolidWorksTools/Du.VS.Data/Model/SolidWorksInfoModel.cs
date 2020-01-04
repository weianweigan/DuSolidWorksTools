using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Model
{
    [DisplayName("SolidWorks信息")]
    public class SolidWorksInfoModel
    {
        private string keyName;
        private int versionNum;
        private string installDate;
        private string installSource;
        private string solidWorksFolder;

        public SolidWorksInfoModel(string keyName, int versionNum, string installDate, string installSource, string solidWorksFolder)
        {
            this.keyName = keyName;
            this.versionNum = versionNum;
            this.installDate = installDate;
            this.installSource = installSource;
            this.solidWorksFolder = solidWorksFolder;
        }

        /// <summary>
        /// solidworks20nn
        /// </summary>
        /// <summary>
        /// 名称
        /// </summary>
        [Category("SolidWorks信息")]
        [DisplayName("版本")]
        [Description("版本")]
        public string KeyName { get { return keyName; } set {; } }
        /// <summary>
        /// 版本号
        /// </summary>
        [Category("SolidWorks信息")]
        [DisplayName("版本号")]
        [Description("版本号")]
        public int VersionNum { get { return versionNum; } set {; } }
        /// <summary>
        /// 安装日期
        /// </summary>
        [Category("SolidWorks信息")]
        [DisplayName("安装日期")]
        [Description("安装日期")]
        public string InstallDate { get { return installDate; } set {; } }
        /// <summary>
        /// 安装源
        /// </summary>
        [Category("位置信息")]
        [DisplayName("安装来源")]
        [Description("安装程序位置")]
        public string InstallSource { get { return installSource; } set {; } }
        /// <summary>
        /// 安装文件夹
        /// </summary>
        [Category("位置信息")]
        [DisplayName("安装位置")]
        [Description("SolidWorks的安装位置")]
        public string SolidWorksFolder { get { return solidWorksFolder; } set {; } }
        /// <summary>
        /// solidworks文件位置
        /// </summary>
        [Category("位置信息")]
        [DisplayName("SolidWorks")]
        [Description("SolidWorks程序路径")]
        public string SolidWorksExe
        {
            get
            { return System.IO.Path.GetDirectoryName(SolidWorksFolder) + "\\" + "SLDWORKS.exe"; }

        }


    }
}
