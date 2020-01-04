using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Du.VS.Model
{
    public class RuningSolidWorkInfoModel
    {
        private SldWorks swApp;

        private string RevisionVersion;
        public RuningSolidWorkInfoModel(SolidWorks.Interop.sldworks.SldWorks app)
        {
            swApp = app;
            if (swApp != null)
            {
                _SolidWorksResult = "获取到SolidWorks进程";
            }
            else
            {
                _SolidWorksResult = "未获取到Solid Works进程";
                return;
            }
            RevisionVersion = swApp.RevisionNumber();
        }

        private string _SolidWorksResult;
        public string SolidWorksResult { get { return _SolidWorksResult; } }


        #region SolidWorks窗口大小
        [Category("SolidWorks窗体属性")]
        [DisplayName("是否可见")]
        [Description("是否隐藏SolidWorks")]
        public bool Visible
        {
            get { return swApp.Visible; }
            private set { swApp.Visible = value; }
        }
        public int FrameHeight
        {
            get { return swApp.FrameHeight; }
            private set
            {
                if (value > 0)
                {
                    swApp.FrameHeight = value;
                }
            }
        }
        public int FrameLeft {
            get { return swApp.FrameLeft; }
            private set
            {
                if (value > 0)
                {
                    swApp.FrameLeft = value;
                }
            }
        }
        public swWindowState_e FrameState
        {
            get { return (swWindowState_e)swApp.FrameState; }
            private set
            {
                if (value > 0)
                {
                    swApp.FrameState = (int)value;
                }
            }
        }
        public int FrameTop
        {
            get { return swApp.FrameTop; }
            private set
            {
                if (value > 0)
                {
                    swApp.FrameTop = value;
                }
            }
        }
        public int FrameWidth
        {
            get { return swApp.FrameWidth; }
            private set
            {
                if (value > 0)
                {
                    swApp.FrameWidth = value;
                }
            }
        }
        #endregion
        #region 设置属性
        [Category("语言")]
        [DisplayName("SolidWorks语言")]
        [Description("当前SolidWorks的语言")]
        public string Language
        {
            get { return swApp.GetCurrentLanguage(); }
        }
        #endregion

        [Category("文档")]
        [DisplayName("最近文档")]
        [Description("最近打开的SolidWroks文档")]
        public string[] RecentFile
        {
            get { return swApp.GetRecentFiles(); }
        }

        #region 单位类型
        private UserUnit LengthUnit { get { return swApp.GetUserUnit((int)swUserUnitsType_e.swLengthUnit); } }
        private UserUnit AngleUnit { get { return swApp.GetUserUnit((int)swUserUnitsType_e.swAngleUnit); } }

        #endregion

        #region 版本信息
        [Category("版本信息")]
        [DisplayName("SolidWorks版本")]
        [Description("当前启动的SolidWorks版本")]
        public string SWVersionNum
        {
            get
            {
                string[] Nums = RevisionVersion.Split('.');
                if (Nums.Length == 3)
                {
                    int verNum;
                    if (int.TryParse(("20" + Nums[0].Trim()), out verNum))
                    {
                        verNum = verNum - 8;
                        return verNum.ToString();
                    }
                    VersionMess = "正常版本";
                }
                else
                {
                    VersionMess = ("您可能安装了Alpha, beta, and pre-release releases 的版本,版本号为:" + RevisionVersion);
                }
                return "请查看版本信息";
            }
        }

        private string _VersionMess;
        [Category("版本信息")]
        [DisplayName("版本信息")]
        [Description("当前启动的SolidWorks版本信息")]
        public string VersionMess
        {
            get { return _VersionMess; }
            private set { _VersionMess = value; }
        }
        #endregion
    }
}
