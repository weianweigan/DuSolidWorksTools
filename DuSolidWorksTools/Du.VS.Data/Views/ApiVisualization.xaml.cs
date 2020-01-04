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

namespace DuApiDataBase.Views
{
    /// <summary>
    /// ApiVisualization.xaml 的交互逻辑
    /// </summary>
    public partial class ApiVisualization : UserControl
    {
        private ViewModels.ApiVisualizationViewModel viewmodel;
        public ApiVisualization()
        {
            Xceed.Wpf.Toolkit.MessageBox msgbox = new Xceed.Wpf.Toolkit.MessageBox();
            InitializeComponent();
            viewmodel = new ViewModels.ApiVisualizationViewModel();
            if (viewmodel.SolidWorksNameSpaces != null && viewmodel.SolidWorksNameSpaces.Count > 0)
            {
                DataContext = viewmodel;
            }
        }
    }
}
