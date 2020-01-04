using Du.VS.Core;
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


namespace Du.VS.Views.View
{
    /// <summary>
    /// AboutPage.xaml 的交互逻辑
    /// </summary>
    public partial class AboutPage : BaseDialogWindow
    {
        private static AboutPage _Singleton;
        private static object Singleton_Lock = new object();
        public static AboutPage GetInstance()
        {
            if (_Singleton == null) //双if +lock
            {
                lock (Singleton_Lock)
                {
                    if (_Singleton == null)
                    {
                        _Singleton = new AboutPage();
                    }
                }
            }
            return _Singleton;
        }
        public AboutPage()
        {
            InitializeComponent();
            this.HasMaximizeButton = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/weianweigan/DuSolidWorksTools");
                //System.Diagnostics.Process.Start("https://github.com/weianweigan/DuSolidWorksTools");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://www.jianshu.com/nb/21702052");
        }

        private void BaseDialogWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
