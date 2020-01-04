using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Du.VS.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Du.ViewModel
{
    public class SolidWorksInfoViewModel : ViewModelBase
    {
        #region 构造函数
        public SolidWorksInfoViewModel()
        {
            GetSolidWorrkInfoList();
        }

        #endregion

        #region 属性
       

        private ObservableCollection<SolidWorksInfoModel> _SolidWorksList;
        /// <summary>
        /// 本地安装的sw
        /// </summary>
        public ObservableCollection<SolidWorksInfoModel> SolidWorksList {
            get { return _SolidWorksList; }
            set { _SolidWorksList = value;
                RaisePropertyChanged("SolidWorksList");
               
            }
        }
        private int _SolidWorkInfoSelectedIndex;
        public int SolidWorkInfoSelectedIndex
        {
            get { return _SolidWorkInfoSelectedIndex; }
            set
            {
                _SolidWorkInfoSelectedIndex = value;
                if (value >= 0)
                {
                    SelectedSoliWorksInfoModel = SolidWorksList[value];
                }
                RaisePropertyChanged("SolidWorkInfoSelectedIndex");
            }
        }
        private SolidWorksInfoModel _SelectedSoliWorksInfoModel;
        /// <summary>
        /// 选择的SolidWorks信息
        /// </summary>
        public SolidWorksInfoModel SelectedSoliWorksInfoModel
        {
            get
            {
                if (SolidWorkInfoSelectedIndex >= 0)
                {
                    _SelectedSoliWorksInfoModel = SolidWorksList[SolidWorkInfoSelectedIndex];
                    return _SelectedSoliWorksInfoModel;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _SelectedSoliWorksInfoModel = value;
                RaisePropertyChanged("SelectedSoliWorksInfoModel");
            }
        }

        private RuningSolidWorkInfoModel _RuningSWModel;
        /// <summary>
        /// 当前运行的Solidworks信息
        /// </summary>
        public RuningSolidWorkInfoModel RuningSWModel
        {
            get { return _RuningSWModel; }
            set { _RuningSWModel = value;
                RaisePropertyChanged("RuningSWModel");
            }
        }

        private Visibility _RuningSWInfoVisilility;
        public Visibility RuningSWInfoVisilility
        {
            get { return _RuningSWInfoVisilility; }
            set { _RuningSWInfoVisilility = value;
                RaisePropertyChanged("RuningSWInfoVisilility");
            }
        }
        #endregion



        #region 事件
        private RelayCommand _RuningSWCommand;
        /// <summary>
        /// 刷新运行中的solidworks
        /// </summary>
        public RelayCommand RuningSWCommand {
            get
            {
                if (_RuningSWCommand == null)
                {
                    _RuningSWCommand = new RelayCommand(RuningSWClick);
                }
                return _RuningSWCommand;
            }
            set { _RuningSWCommand = value; }
        }

        private RelayCommand _StartSWCommand;
        /// <summary>
        /// 启动选中的SolidWorks
        /// </summary>
        public RelayCommand StartSWCommand {
            get {
                if (_StartSWCommand == null)
                {
                    _StartSWCommand = new RelayCommand(StartSWClick);
                }
                return _StartSWCommand; }
            set { _StartSWCommand = value; }
        }

        private RelayCommand _OpenInFolderCommand;

        public RelayCommand OpenInFolderCommand
        {
            get
            {
                if (_OpenInFolderCommand == null)
                {
                    _OpenInFolderCommand = new RelayCommand(OpenInFolderClick);
                } 
                return _OpenInFolderCommand; }
            set { _OpenInFolderCommand = value;
           }
        }
        private RelayCommand _OpenReferenceManagerCommand;

        public RelayCommand OpenReferenceManagerCommand
        {
            get
            {
                if (_OpenReferenceManagerCommand == null)
                {
                    _OpenReferenceManagerCommand = new RelayCommand(OpenReferenceManagerClick);
                }
                return _OpenReferenceManagerCommand;
            }
            set {  _OpenReferenceManagerCommand = value; }
        }



        #endregion

        #region 私有方法
        /// <summary>
        /// 打开引用管理器
        /// </summary>
        private void OpenReferenceManagerClick()
        {
            //DuSolidWorksTools.View.ReferenceManagerView referenceManager = new DuSolidWorksTools.View.ReferenceManagerView();
            //referenceManager.ShowModal();
        }
        /// <summary>
        /// 启动SolidWorks
        /// </summary>
        private void StartSWClick()
        {
            if (SelectedSoliWorksInfoModel != null )
            {
                if (System.IO.File.Exists(SelectedSoliWorksInfoModel.SolidWorksExe))
                {
                    Process.Start(SelectedSoliWorksInfoModel.SolidWorksExe);
                    RuningSWClick();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("当前路径下不存在SolidWorks程序，请检查SolidWorks是否已经被卸载");
                }
            }
            else
            {
                MessageBox.Show("请选择一个SolidWorks版本");
            }
        }
        /// <summary>
        /// 在文件夹中打开
        /// </summary>
        private void OpenInFolderClick()
        {
            if (SelectedSoliWorksInfoModel != null)
            {
                if (System.IO.File.Exists(SelectedSoliWorksInfoModel.SolidWorksExe))
                {
                    System.Diagnostics.Process.Start("Explorer", "/select," + SelectedSoliWorksInfoModel.SolidWorksFolder + "\\" + "SLDWORKS.exe");
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("当前路径下不存在SolidWorks程序，请检查SolidWorks是否已经被卸载");
                }
            }
            else
            {
                MessageBox.Show("请选择一个SolidWorks版本");
            }
        }
        /// <summary>
        /// 获取安装的SolidWorks信息
        /// </summary>
        private void GetSolidWorrkInfoList()
        {
            //SolidWorksList = DuSolidWorks.ReadSolidWorksInfo();
        }
        /// <summary>
        /// 获取运行中的solidworks
        /// </summary>
        private void RuningSWClick()
        {
            //var swApp = DuSolidWorks.GetActiveswApp();
            //if (swApp != null)
            //{
                

            //    RuningSWInfoVisilility = Visibility.Visible;

            //    RuningSWModel = new DuSolidWorksTools.Models.RuningSolidWorkInfoModel((SolidWorks.Interop.sldworks.SldWorks)swApp);

               
            //}
            //else
            //{
            //    RuningSWInfoVisilility = Visibility.Collapsed;

            //    MessageBox.Show("启动SolidWorks失败");
            //}
        }
        #endregion
    }
}
