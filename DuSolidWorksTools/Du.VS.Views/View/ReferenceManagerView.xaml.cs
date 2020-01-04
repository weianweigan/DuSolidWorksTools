using Du.VS.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Du.VS.Views.View
{
    /// <summary>
    /// ReferenceManagerView.xaml 的交互逻辑
    /// </summary>
    public partial class ReferenceManagerView : BaseDialogWindow
    {
        public Du.ViewModel.ReferenceManagerViewModel viewmodel;
        public ReferenceManagerView()
        {
            InitializeComponent();
            //绑定上下文文
            viewmodel = new Du.ViewModel.ReferenceManagerViewModel();
            DataContext = viewmodel;
        }
        public new void ShowModal()
        {
            //获取visual stdio 项目信息
            viewmodel.GetVisualStdioInfo();
            base.ShowModal();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Debug.Print("Click");
        }
    }
}
