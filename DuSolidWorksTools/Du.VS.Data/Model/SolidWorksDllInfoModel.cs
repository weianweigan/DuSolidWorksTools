using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Model
{
    public class SolidWorksDllInfoModel
    {
       
        public SolidWorksDllInfoModel(string _DllName,string _DllDescription,string _PicSource)
        {
            DllName = _DllName;
            DllDescription = _DllDescription;
            DllPicSource = _PicSource;
        }

        public string DllName { get; private set; }

        public string DllDescription { get; private set; }

        public string DllPicSource { get; private set; }
    }
}
