
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
    /// SolidWorksInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class SolidWorksInfoView : UserControl
    {
        private Du.ViewModel.SolidWorksInfoViewModel viewmodel;
        public SolidWorksInfoView()
        {

            Xceed.Wpf.Toolkit.MessageBox ms = new Xceed.Wpf.Toolkit.MessageBox();

            InitializeComponent();

            //if (Du.Setting.DuSWExPathManager.IsAdministrator())
            //{
            //    viewmodel = new Du.ViewModel.SolidWorksInfoViewModel();
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
