using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuApiDataBase.ViewModels
{
    public class ApiVisualizationViewModel:GalaSoft.MvvmLight.ViewModelBase
    {
        private List<Du.Models.SolidWorksNameSpace> _SolidWorksNameSpaces = null;

        public List<Du.Models.SolidWorksNameSpace> SolidWorksNameSpaces
        {
            get { return _SolidWorksNameSpaces; }
            set { _SolidWorksNameSpaces = value;RaisePropertyChanged("SolidWorksNameSpaces"); }
        }
        public ApiVisualizationViewModel()
        {
            SolidWorksNameSpaces = Context.myContext.GetData();
        }
    }
}
