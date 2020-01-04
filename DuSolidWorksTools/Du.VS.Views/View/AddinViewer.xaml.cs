
using Du.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace Du.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddinViewer : UserControl
    {
        public AddinViewerViewModel viewmodel;
        public AddinViewer()
        {
            Xceed.Wpf.Toolkit.MessageBox ss = new Xceed.Wpf.Toolkit.MessageBox();
            Xceed.Wpf.Toolkit.AutoSelectTextBox at = new AutoSelectTextBox();
            // ColorZoneAssist.SetMode(new CheckBox(), ColorZoneMode.Accent);
            //Hue hue = new Hue("xyz", System.Windows.Media.Color.FromArgb(1, 2, 3, 4), System.Windows.Media.Color.FromArgb(1, 5, 6, 7));

            //Du.Setting.DuSWExPathManager.LoadMaterialDesignDll();
            //Du.Setting.DuSWExPathManager.LoadMaterialDesignDll();

            InitializeComponent();
            //判断是否以管理员权限运行
            //if (Du.Setting.DuSWExPathManager.IsAdministrator())
            //{
            //    viewmodel = new AddinViewerViewModel();

            //    DataContext = viewmodel;

            //    AdminInfo.Visibility = Visibility.Collapsed;

            //}
            //else
            //{
            //    AdminInfo.Visibility = Visibility.Visible;
            //}
        }
    }
}
