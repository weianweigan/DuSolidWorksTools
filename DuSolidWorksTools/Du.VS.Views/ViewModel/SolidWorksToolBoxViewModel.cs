using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
//using DuSolidWorksTools.Core;

namespace DuSolidWorksTools
{
    public class SolidWorksToolBoxViewModel:GalaSoft.MvvmLight.ViewModelBase
    {
        #region 字段
        public SolidWorksToolBoxControl myWindow;

        //Du.Core.SolidWorksURLContructor uRLContructor;
        public List<int> ApiVersionList
        {
            get {
                return new List<int> { 2010,2011,2012,2013,2014,2015,2016,2017,2018,2019,2020};
            }
        }

        //private string URL;
        #endregion

        #region 构造函数
        public SolidWorksToolBoxViewModel(SolidWorksToolBoxControl window)
        {
            myWindow = window;
        }
        #endregion

        #region 属性
        private bool _IsBrowserModel = false;
        //是否使用浏览器模式
        public bool IsBrowserModel { get { return _IsBrowserModel; }
             set { _IsBrowserModel = value;
                RaisePropertyChanged("IsBrowserModel");
                if (BrowserModelEnable)
                {
                     SetApiBrowserModel(value);
                }
            }
        }
        private int _TabSelectedIndex;
        /// <summary>
        /// Tab页所在位置
        /// </summary>
        public int TabSelectedIndex
        {
            get { return _TabSelectedIndex; }
            set { _TabSelectedIndex = value;
                RaisePropertyChanged("TabSelectedIndex");
            }
        }
        private int _SelectedVersionIndex = 8;

        public int SelectedVersionIndex {
            get { return _SelectedVersionIndex; }
            set { _SelectedVersionIndex = value;
                VersionChanged(ApiVersionList[value]);
            }
        }
        

        private int _SelectedVersion;
        public int SelectedVersion
        { get { return _SelectedVersion; }
            set { _SelectedVersion = value;
                //Du.Core.SolidWorksURLContructor.NowVersion = value;
            }
        }

        private bool _BrowserModelEnable = true;

        public bool BrowserModelEnable
        {
            get { return _BrowserModelEnable; }
            set { _BrowserModelEnable = value;RaisePropertyChanged("BrowserModelEnable"); }
        }

        private object _SelectedSoliWorksApiModel;

        public object SelectedSoliWorksApiModel
        {
            get { return _SelectedSoliWorksApiModel; }
            set { _SelectedSoliWorksApiModel = value;RaisePropertyChanged("SelectedSoliWorksApiModel"); }
        }
        #endregion

        #region Command 命令
        private RelayCommand _OpenInBrowser;

        public RelayCommand OpenInBrowser
        {
            get
            {
                return _OpenInBrowser == null ? _OpenInBrowser = new RelayCommand(OpenInBrowserClick) : _OpenInBrowser;
            }
            set { _OpenInBrowser = value; }
        }

        private RelayCommand _AwardCommand;

        public RelayCommand AwardCommand { get
            {
                if (_AwardCommand == null)
                {
                    _AwardCommand = new RelayCommand(AwardClick);
                }
                return _AwardCommand;
            }
            set
            {
                _AwardCommand = value;
            }
        }
        private RelayCommand _BackCommand;
        public RelayCommand BackCommand
        {
            get
            {
                if (_BackCommand == null)
                {
                    _BackCommand = new RelayCommand(BackClick);

                }
                return _BackCommand;
            }
            set { _BackCommand = value; }
        }
        private RelayCommand _HomeCommand;
        public RelayCommand HomeCommand
        {
            get
            {
                if (_HomeCommand == null )
                {
                    _HomeCommand = new RelayCommand(HomeCommandClick);
                }
                return _HomeCommand;
            }
            set { _HomeCommand = value; }
        }
 

        #endregion

        #region 公共方法

        //public void SetApiHelp(string activeDocumentPath, TextViewSelection selection)
        //{
        //    TabSelectedIndex = 3;
        //    foreach (var project in DuSolidWorksToolsPackage.myVSWorkspace.CurrentSolution.Projects)
        //    {
        //        foreach (var doc in project.Documents)
        //        {
        //            if (doc.FilePath == activeDocumentPath)
        //            {
                        
        //                var modelService = doc.GetSemanticModelAsync();
        //                modelService.Wait();

        //                var Model = modelService.Result as Microsoft.CodeAnalysis.SemanticModel;
                        
        //                var root = Model.SyntaxTree.GetRoot();

        //                CSharpCompilation CsharpComp = Model.Compilation as CSharpCompilation; 
                      
        //                var node = root.FindNode(new Microsoft.CodeAnalysis.Text.TextSpan(selection.StartPosition.Postion,( selection.EndPosition.Postion - selection.StartPosition.Postion)));
        //                if (node !=null)
        //                {
        //                    GetSymbolInfo(node, Model);
        //                }
        //                return;
        //            }
        //        }
        //    }
        //}
        
        public void GetSymbolInfo(SyntaxNode node,SemanticModel Model)
        {
            //var symbolInfo = Model.GetSymbolInfo(node);
            //if ( symbolInfo.Symbol != null)
            //{
            //     uRLContructor = new Du.Core.SolidWorksURLContructor(symbolInfo.Symbol);
            //    if (uRLContructor.Result == Du.Core.SolidWorksURLContructor.SolidWorksURLResult.Exist)
            //    {
            //        SetApiBrowser(uRLContructor, symbolInfo.Symbol);
            //    }
            //}
            //else
            //{
                
            //}
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 设置浏览器显示
        /// </summary>
        /// <param name=""></param>
        //private void SetApiBrowser(Du.Core.SolidWorksURLContructor con, ISymbol symbolInfo = null)
        //{
        //    Debug.Print(uRLContructor.URL);
        //    myWindow.ApiBrowser.Source = new Uri(uRLContructor.URL);
        //    if (symbolInfo != null)
        //    {
        //        SelectedSoliWorksApiModel = DuSymblosService.GetApiDataBaseObj(symbolInfo);
        //    }
        //}
        /// <summary>
        /// 切换版本加载页面
        /// </summary>
        /// <param name="v"></param>
        private void VersionChanged(int version)
        {
            //if (uRLContructor != null )
            //{
            //    uRLContructor.Version = version;
            //    SetApiBrowser(uRLContructor);
            //}
        }
        /// <summary>
        /// 导航到主页
        /// </summary>
        private void HomeCommandClick()
        {
           //myWindow.ApiBrowser.Source = new Uri(Du.Core.SolidWorksURLContructor.NowApiWelcomeUrl);
        }

        /// <summary>
        /// 前一个网页
        /// </summary>
        private void BackClick()
        {
            myWindow.ApiBrowser.GoBack();
        }

        /// <summary>
        /// 上一个网页
        /// </summary>
        private void AwardClick()
        {
            myWindow.ApiBrowser.GoForward();
        }

        /// <summary>
        /// 在浏览器中打开url
        /// </summary>
        private void OpenInBrowserClick()
        {
            if (myWindow.ApiBrowser.Source != null)
            {
                System.Diagnostics.Process.Start(myWindow.ApiBrowser.Source.OriginalString);
            }
        }

        /// <summary>
        /// 设置api显示模式
        /// </summary>
        /// <param name="value"></param>
        private void SetApiBrowserModel(bool value)
        {
            BrowserModelEnable = false;

            //导航到短视图
            if (value)
            {
                //var HtmlStr = await SolidWorksUrlTrim.GetStringFormUrlAsync(uRLContructor.URL);

                //if (string.IsNullOrEmpty(HtmlStr))
                //{
                //    myWindow.ApiBrowser.Navigate(HtmlStr);
                //}
            }
            //导航到网页视图
            else
            {
                //myWindow.ApiBrowser.Source = new Uri(uRLContructor.URL);
            }
            BrowserModelEnable = true;
        }
        private void SetBrowserStr()
        {
            //string HtmlStr = SolidWorksUrlTrim.GetStringFormUrlAsync(uRLContructor.URL);
            //if (string.IsNullOrEmpty(HtmlStr))
            //{
            //    myWindow.ApiBrowser.Navigate(HtmlStr);
            //}
        }
        #endregion
    }
}
