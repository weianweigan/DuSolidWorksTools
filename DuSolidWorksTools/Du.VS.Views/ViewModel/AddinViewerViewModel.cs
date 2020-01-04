using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using Xceed.Wpf.Toolkit;
using Microsoft.Win32;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using Du.VS.Model;

namespace Du.ViewModel
{
    public class AddinViewerViewModel:GalaSoft.MvvmLight.ViewModelBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public  AddinViewerViewModel()
        {
            //读取注册表里的Solidworks安装信息
            ReadRegasmInfo();
        }


        #region 属性
        private ObservableCollection<swAddinModel> _AddinList = new ObservableCollection<swAddinModel>();
        /// <summary>
        /// 插件列表
        /// </summary>
        public ObservableCollection<swAddinModel> AddinList { get { return _AddinList; }
            set {
                _AddinList = value;
                RaisePropertyChanged("AddinList");
            }
        }

        private int _AddinSelectedIndex;

        public int AddinSelectedIndex
        {
            get { return _AddinSelectedIndex; }
            set { _AddinSelectedIndex = value;
                if (value >= 0)
                {
                    SelectedAddinModel = AddinList[value];
                }
            }
        }
        private swAddinModel _SelectedAddinModel;
        public swAddinModel SelectedAddinModel
        {
            get {
                if (AddinSelectedIndex >= 0)
                {
                    _SelectedAddinModel = AddinList[AddinSelectedIndex];
                    return _SelectedAddinModel;
                }
                else
                {
                    return null;
                }
            }
            set { _SelectedAddinModel = value;
                RaisePropertyChanged("SelectedAddinModel");
            }
        }

        private ObservableCollection<SolidWorksInfoModel> _SolidWorksList = new ObservableCollection<SolidWorksInfoModel>();
        /// <summary>
        /// Solidworks版本
        /// </summary>
        public ObservableCollection<SolidWorksInfoModel> SolidWorksList
        {
            get { return _SolidWorksList; }
            set
            {
                _SolidWorksList = value;
                RaisePropertyChanged("SolidWorksList");
            }
        }
        private int _SolidWorkInfoSelectedIndex;
        public int SolidWorkInfoSelectedIndex { get { return _SolidWorkInfoSelectedIndex; }
            set { _SolidWorkInfoSelectedIndex = value;
                if (value >= 0)
                {
                    SelectedSoliWorksInfoModel = SolidWorksList[value];
                }
                RaisePropertyChanged("SolidWorkInfoSelectedIndex");
            }
        }
        private SolidWorksInfoModel _SelectedSoliWorksInfoModel;
        public SolidWorksInfoModel SelectedSoliWorksInfoModel {
            get {
                if (SolidWorkInfoSelectedIndex >= 0)
                {
                    return SolidWorksList[SolidWorkInfoSelectedIndex];
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

        private string _Description;

        public string Description { get { return _Description; } set { _Description = value;
                RaisePropertyChanged("Description");
            } }

        #endregion

        #region command事件

        private RelayCommand _UnLoadAddinCommand;

        public RelayCommand UnLoadAddinCommand {
            get { if (_UnLoadAddinCommand == null) _UnLoadAddinCommand = new RelayCommand(UnLoadClick);
                return _UnLoadAddinCommand;
            }
            set { _UnLoadAddinCommand = value; }
        }

        private RelayCommand _ForceUnLoadCommand;

        public RelayCommand ForceUnLoadCommand
        { get { if (_ForceUnLoadCommand == null) _ForceUnLoadCommand = new RelayCommand(ForceUnLoadClick);
                return _ForceUnLoadCommand;
            }
            set { _ForceUnLoadCommand = value; }
        }

        private RelayCommand _InstallAddinCommand;

        public RelayCommand InstallAddinCommand
        {
            get
            {
                if (_InstallAddinCommand == null)
                {
                    _InstallAddinCommand = new RelayCommand(InstallClick);
                }
                return _InstallAddinCommand;
            }
            set { _InstallAddinCommand = value; }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 读取Sw信息
        /// </summary>
        private void ReadRegasmInfo()
        {
            //if (!Du.Setting.DuSWExPathManager.IsAdministrator())
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("当前无法获取管理员权限，无法获取信息，请以管理员权限运行SolidWorks");
            //    return;
            //}
            //ObservableCollection<Du.Model.swAddinModel> myAddinList = new ObservableCollection<Du.Model.swAddinModel>();
            //try
            //{
            //    Microsoft.Win32.RegistryKey localMachine64 = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64);


            //    //读取注册表
            //    RegistryKey addinKey = localMachine64.OpenSubKey(@"SOFTWARE\solidworks\AddIns");

            //    RegistryKey CLSIDKey = localMachine64.OpenSubKey(@"SOFTWARE\WOW6432Node\Classes\CLSID");
            //    if (addinKey != null)
            //    {
            //        var addinGUID = addinKey.GetSubKeyNames();

            //        foreach (var item in addinGUID)
            //        {
            //            Du.Model.swAddinModel model = new Du.Model.swAddinModel() { GUID = item };
            //            //读取描述和名称
            //            var myAddin = addinKey.OpenSubKey(item);
            //            if (myAddin != null)
            //            {
            //                model.Description = myAddin.GetValue("Description").ToString();
            //                model.Title = myAddin.GetValue("Title").ToString();
            //            }
            //            //读取clsid相关信息
            //            var myCLSID = CLSIDKey.OpenSubKey(item);
            //            if (myCLSID != null)
            //            {
            //                var server = myCLSID.OpenSubKey("InprocServer32");
            //                if (server != null)
            //                {
            //                    //程序集信息
            //                    model.AssemblyInfo = server.GetValue("Assembly").ToString();
            //                    //类名
            //                    model.ClassName = server.GetValue("Class").ToString();
            //                    //CodeBase
            //                    model.CodeBase = server.GetValue("CodeBase").ToString();
            //                    //.net运行时信息
            //                    model.DotNetRuntimeVersion = server.GetValue("RuntimeVersion").ToString();
            //                    model.ThreadingModel = server.GetValue("ThreadingModel").ToString();
            //                }
            //            }
            //            myAddinList.Add(model);
            //            //读取是否启动时加载
            //            //---->>>Todo
            //        }
            //        AddinList = myAddinList;
            //    }

            //    //读取Solidworks信息
            //    ReadSolidWorksInfo();
            //}
            //catch (Exception ex)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());
            //}
            
        }

        private void ReadSolidWorksInfo()
        {
             //SolidWorksList = Core.DuSolidWorks.ReadSolidWorksInfo();
        }

        /// <summary>
        /// 卸载插件
        /// </summary>
        private void UnLoadClick()
        {
            //if (SelectedAddinModel != null &&  AddinSelectedIndex > -1 )
            //{
            //    if (string.IsNullOrEmpty(SelectedAddinModel.CodeBase))
            //    {
            //        Xceed.Wpf.Toolkit.MessageBox.Show("当前选择的插件没有CodeBase信息,无法找到卸载源文件");
            //        return;
            //    }
            //    string filePath = SelectedAddinModel.CodeBase.Replace("file:///", "");
            //    if (System.IO.File.Exists(filePath))
            //    {
            //         var result = Xceed.Wpf.Toolkit.MessageBox.Show("您确定要卸载此插件\n" + SelectedAddinModel.Title,"卸载插件",MessageBoxButton.YesNo);
            //        if (result == MessageBoxResult.Yes)
            //        {
            //            string CMDStr = filePath.ToCharArray()[0].ToString() + ":\n"
            //            + Du.Setting.DuSWExPathManager.RegasmPath + " " + filePath + " /u";
            //            //+ "\npause";
            //            Debug.Print(CMDStr);
            //            RunCMD(CMDStr);
            //        }
                    
            //    }
            //    else
            //    {
            //        Xceed.Wpf.Toolkit.MessageBox.Show("未找打当前插件文件位置--" + SelectedAddinModel.CodeBase);
            //    }
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("请选择一个要卸载的插件");
            //}
        }
        /// <summary>
        /// 强制卸载插件--等待开发
        /// </summary>
        private void ForceUnLoadClick()
        {
            
        }

        /// <summary>
        /// 点击加载插件按钮
        /// </summary>
        private void InstallClick()
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //var result = openFileDialog.ShowDialog();
            
            //if (result == result.Value)
            //{
            //    if (System.IO.File.Exists( openFileDialog.FileName))
            //    {
            //        if (System.IO.Path.GetExtension(openFileDialog.FileName).ToLower() == ".dll")
            //        {
            //            var EnsureResult = Xceed.Wpf.Toolkit.MessageBox.Show("请确认您将要注册插件/n" + openFileDialog.FileName, "注册插件", MessageBoxButton.YesNoCancel);
            //            if (EnsureResult == MessageBoxResult.Yes)
            //            {
            //                string CMDStr = openFileDialog.FileName.ToCharArray()[0].ToString() + ":\n"
            //            + Du.Setting.DuSWExPathManager.RegasmPath + " " + openFileDialog.FileName + " /codebase"
            //            + "\npause";
            //                Debug.Print(CMDStr);
            //                RunCMD(CMDStr);
            //            }
            //        }
            //        else
            //        {
            //            Xceed.Wpf.Toolkit.MessageBox.Show("请选择一个dll文件");
            //        }
            //    }
            //    else
            //    {
            //        Xceed.Wpf.Toolkit.MessageBox.Show("未找到所选文件");
            //    }
            //}
        }
        private void RunCMD(string CMDStr)
        {
            try
            {
                //创建一个进程
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                //p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序


                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine(CMDStr + "&exit");

                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();


                Xceed.Wpf.Toolkit.MessageBox.Show(output);
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
        }
        #endregion
    }
}
