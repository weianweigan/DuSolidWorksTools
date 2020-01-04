
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
using Xceed.Wpf.Toolkit;
using System.Windows.Shapes;

namespace Du.View
{
    /// <summary>
    /// SelectionInfo.xaml 的交互逻辑
    /// </summary>
    public partial class SelectionInfo : UserControl
    {
        public Du.ViewModel.SelectionInfoViewModel viewModel;
        public SelectionInfo()
        {
            //预加载程序集
            Xceed.Wpf.Toolkit.MessageBox ms = new Xceed.Wpf.Toolkit.MessageBox();
            InitializeComponent();
            //绑定viewmodel上下文
            viewModel = new Du.ViewModel.SelectionInfoViewModel();
            DataContext = viewModel;
        }
    }
}
