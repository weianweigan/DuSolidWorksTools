using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;

namespace Du.VS.Model
{
    public class VisualStdioProjectInfoModel
    {
        public Project project;

        public VisualStdioProjectInfoModel(Project _project)
        {
            this.project = _project;
           
        }
        [Obsolete]
        public VisualStdioProjectInfoModel(string _Name,string _ProPath,List<string> _Reference)
        {
            //Name = _Name;
            //ProFilePath = _ProPath;
            //Reference = _Reference;
        }
        /// <summary>
        /// 项目名
        /// </summary>
        public string Name { get { return project.Name; }  }
        /// <summary>
        /// 项目路径
        /// </summary>
        public string ProFilePath { get {
                return "";
               //     project.FilePath;

            } }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsCheck {
            
            get; 

            set; 
        }

        private string _Version;
        /// <summary>
        /// 当前选中的dll版本
        /// </summary>
        public string Version
        {
            get
            {
                return _Version;
            }
        }

        private string _InstallState;

        public string InstallState
        {
            get { return _InstallState; }
            set { _InstallState = value; }
        }

        private bool _IsInstalled = false;

        public bool IsInstalled { get { return _IsInstalled; } private set { _IsInstalled = value; } }
        #region 公共方法
        public bool setVersion(ReferenceInfoModel referenceInfo)
        {
            //foreach (var item in project.MetadataReferences)
            //{
            //    if (System.IO.Path.GetFileNameWithoutExtension(item.Display) == System.IO.Path.GetFileNameWithoutExtension(referenceInfo.FilePath))
            //    {
            //        InstallState = "此项目已引用" + System.IO.Path.GetFileNameWithoutExtension(item.Display);
            //        IsInstalled = true;
            //        return true;
            //    }
            //    else
            //    {
            //        InstallState = "未引用" + System.IO.Path.GetFileNameWithoutExtension(referenceInfo.Name);
            //    }
            //}
            //IsInstalled = false;
            return false;
        }
        #endregion
    }
}
