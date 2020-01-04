using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Du.VS.Model;

namespace Du.ViewModel
{
    public class ReferenceManagerViewModel:ViewModelBase
    {
        #region 属性
       
        /// <summary>
        /// SolidWroks版本信息
        /// </summary>
        public ObservableCollection<SolidWorksInfoModel> SoldWorksVersionList
        {
            get {
                return null;
                //return DuSolidWorksTools.Core.SolidWorksReferenceAdapter.SolidWorksInfoList;
            }
        }

        private int _SolidWorksVersionSelectedIndex = 0;
        /// <summary>
        /// 选择的SolidWorks版本
        /// </summary>
        public int SolidWorksVersionSelectedIndex
        {
            get { return _SolidWorksVersionSelectedIndex; }
            set { _SolidWorksVersionSelectedIndex = value;RaisePropertyChanged("SolidWorksVersionSelectedIndex");
                SetReferenceList();
                ; }
        }

        
        private string _SelectedRefName;
        /// <summary>
        /// 当前选择的dll名字
        /// </summary>
        public string SelectedRefName { get { return _SelectedRefName; }
            set { _SelectedRefName = value;RaisePropertyChanged("SelectedRefName"); }
        }

        private ObservableCollection<ReferenceInfoModel> _ReferenceList;
       /// <summary>
       /// dll列表
       /// </summary>
        public ObservableCollection<ReferenceInfoModel> ReferenceList 
        {
            get
            {
                return null;
                //if (SolidWorksVersionSelectedIndex >= 0 && _ReferenceList == null)
                //{
                //    foreach (var item in DuSolidWorksTools.Core.SolidWorksReferenceAdapter.SolidWorksReferenceCollection)
                //    {
                //        if (item.Key == SoldWorksVersionList[SolidWorksVersionSelectedIndex].SolidWorksExe)
                //        {
                //            _ReferenceList = new ObservableCollection<DuSolidWorksTools.Models.ReferenceInfoModel>();
                //            foreach (var dll in item.Value)
                //            {
                //                _ReferenceList.Add(dll);
                //            }
                //            return _ReferenceList;
                //        }
                //    } 
                //}
                //return _ReferenceList;
            }
            set
            {
                _ReferenceList = value;
                RaisePropertyChanged("ReferenceList");
            }
        }

        private ReferenceInfoModel _SelectedReference;
        /// <summary>
        /// 当前选择的dll
        /// </summary>
        public ReferenceInfoModel SelectedReference
        { get
            { return _SelectedReference; }
            set {
                _SelectedReference = value;
                SelectedRefName = value == null ? "": value.Name;
                RaisePropertyChanged("SelectedReference");
                SetProjectInfo();
            }
        }

       

        private ObservableCollection<VisualStdioProjectInfoModel> _VisualStduioProjects;
        /// <summary>
        /// Vs项目
        /// </summary>
        public ObservableCollection<VisualStdioProjectInfoModel> VisualStduioProjects
        {
            get;
            //get
            //{
            //    if (_VisualStduioProjects == null)
            //    {
            //        _VisualStduioProjects = new ObservableCollection<VisualStdioProjectInfoModel>();

            //        VisualStdioProjectAdapter.Adapter.GetProjects().ForEach(p =>
            //        {
            //            if (SelectedReference != null)
            //            {
            //                p.setVersion(SelectedReference);
            //            }
            //            _VisualStduioProjects.Add(p);
            //        }
            //            );
            //    }
            //    return _VisualStduioProjects;
            //}

            //set { _VisualStduioProjects = value;RaisePropertyChanged("VisualStduioProjects"); }
        }
        private VisualStdioProjectInfoModel _SelectedVSProject;
        public VisualStdioProjectInfoModel SelectedVSProject
        {
            get { return _SelectedVSProject; }
            set { 
                _SelectedVSProject = value; 
                //UpdateButtonState();
                if (_SelectedVSProject != null)
                {
                    //_SelectedVSProject.IsCheck = !_SelectedVSProject.IsCheck;
                }
                RaisePropertyChanged("VisualStduioProjects");
            }
        }

        private bool _IsInstallButtonEnable = true;
        /// <summary>
        /// 控制安装按钮是否可见
        /// </summary>
        public bool IsInstallButtonEnable
        {
            get { return _IsInstallButtonEnable; }
            set { _IsInstallButtonEnable = value;
                RaisePropertyChanged("IsInstallButtonEnable");
            }
        }
        private bool _IsUnInstallButtonEnable = true;
        /// <summary>
        /// 控制卸载按钮是否可见
        /// </summary>
        public bool IsUnInstallButtonEnable
        {
            get { return _IsUnInstallButtonEnable; }
            set
            {
                _IsUnInstallButtonEnable = value;
                RaisePropertyChanged("IsUnInstallButtonEnable");
            }
        }
        #endregion

        #region 命令
        private RelayCommand _UnInstallCommand;
        public RelayCommand UnInstallCommand
        {
            get
            {
                if (_UnInstallCommand == null)
                {
                    _UnInstallCommand = new RelayCommand(UnInstallClick);
                } 
                return _UnInstallCommand; }
            set { _UnInstallCommand = value;
            }
        }
        private RelayCommand _InstallCommand;
        public RelayCommand InstallCommand
        {
            get
            {
                if (_InstallCommand == null)
                {
                    _InstallCommand = new RelayCommand(InstallClick);
                }
                return _InstallCommand;
            }
            set
            {
                _InstallCommand = value;
            }
        }


        #endregion

        #region 私有方法
        /// <summary>
        /// 更新按钮是否可以使用
        /// </summary>
        [Obsolete("暂时不添加此功能")]
        private void UpdateButtonState()
        {
            //foreach (var item in VisualStduioProjects)
            //{
            //    if (item.IsCheck)
            //    {
            //        IsInstallButtonEnable = true;
            //        IsUnInstallButtonEnable = true;
            //        return;
            //    }
            //    else
            //    {
            //        IsInstallButtonEnable = false;
            //        IsUnInstallButtonEnable = false;
            //    }
            //}
        }
        /// <summary>
        /// 设置项目列表中是否安装
        /// </summary>
        private void SetProjectInfo()
        {
            //if (SelectedReference != null)
            //{
            //    var VSProject = new ObservableCollection<VisualStdioProjectInfoModel>();

            //    DuSolidWorksTools.Core.VisualStdioProjectAdapter.Adapter.GetProjects().ForEach(p =>
            //    {
                   
            //            p.setVersion(SelectedReference);
                    
            //        VSProject.Add(p);
            //    }
            //        );
            //    VisualStduioProjects = VSProject;
            //}
        }
        /// <summary>
        /// 卸载按钮执行的动作
        /// </summary>
        private void UnInstallClick()
        {

            //List<string> ProjectsToInstall = new List<string>();
            //foreach (var item in VisualStduioProjects)
            //{
            //    if (item.IsCheck && !item.IsInstalled)
            //    {
            //        ProjectsToInstall.Add(item.Name);
            //    }
            //}
            //if (ProjectsToInstall.Count == 0)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("没选中需要安装的项目");
            //    return;
            //}
            //string Mess = string.Empty;
            //ProjectsToInstall.ForEach(p => Mess = Mess + "\n" + p);
            //var res = Xceed.Wpf.Toolkit.MessageBox.Show(Mess, "将要卸载 " + SelectedReference.Name + " 从", System.Windows.MessageBoxButton.OKCancel);
            //if (res == System.Windows.MessageBoxResult.OK)
            //{
            //    foreach (var item in VisualStduioProjects)
            //    {
            //        DuSolidWorksTools.DuSolidWorksToolsPackage.myVSWorkspace.CanApplyChange(Microsoft.CodeAnalysis.ApplyChangesKind.RemoveMetadataReference);

            //        if (item.IsCheck && !item.IsInstalled)
            //        {
            //            item.project = item.project.RemoveMetadataReference(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(SelectedReference.FilePath));
            //            DuSolidWorksTools.DuSolidWorksToolsPackage.myVSWorkspace.TryApplyChanges(item.project.Solution);
            //        }
            //    }
            //}

        }
        /// <summary>
        /// 安装按钮执行的动作
        /// </summary>
        private void InstallClick()
        {
            if (SelectedReference == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("请选择一个dll");
                return;
            }
            List<string> ProjectsToInstall = new List<string>();
            //foreach (var item in VisualStduioProjects)
            //{
            //    if (item.IsCheck && !item.IsInstalled)
            //    {
            //        ProjectsToInstall.Add(item.Name);
            //    }
            //}
            //if (ProjectsToInstall.Count == 0)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("没选中需要安装的项目");
            //    return;
            //}
            //string Mess = string.Empty;
            //ProjectsToInstall.ForEach(p => Mess = Mess + "\n" + p);
            //var res = Xceed.Wpf.Toolkit.MessageBox.Show(Mess, "将要安装 " + SelectedReference.Name + " 到",System.Windows.MessageBoxButton.OKCancel);
            //if (res == System.Windows.MessageBoxResult.OK)
            //{
            //    DuSolidWorksTools.DuSolidWorksToolsPackage.myVSWorkspace.CanApplyChange(Microsoft.CodeAnalysis.ApplyChangesKind.AddMetadataReference);
            //    foreach (var item in VisualStduioProjects)
            //    {
            //        if (item.IsCheck && !item.IsInstalled)
            //        {
            //            item.project = item.project.AddMetadataReference(Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(SelectedReference.FilePath));
            //            DuSolidWorksTools.DuSolidWorksToolsPackage.myVSWorkspace.TryApplyChanges(item.project.Solution);
            //        }
            //    }
               
            //}
        }
        /// <summary>
        /// 刷新不同版本的列表
        /// </summary>
        private void SetReferenceList()
        {
            _ReferenceList = null;
            RaisePropertyChanged("ReferenceList");
        }

        #endregion

        #region 公有方法
        /// <summary>
        /// 设置visual stdiuo项目信息
        /// </summary>
        public void GetVisualStdioInfo()
        {
           var  VSProjects = new ObservableCollection<VisualStdioProjectInfoModel>();

            //DuSolidWorksTools.Core.VisualStdioProjectAdapter.Adapter.GetProjects().ForEach(p =>
            //{
            //    if (SelectedReference != null)
            //    {
            //        p.setVersion(SelectedReference);
            //    }
            //    VSProjects.Add(p);
            //}
            //    );
            //VisualStduioProjects = VSProjects;
        }
        #endregion
    }
}
