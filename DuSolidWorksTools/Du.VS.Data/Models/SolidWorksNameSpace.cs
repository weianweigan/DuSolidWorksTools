using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.Models
{
    public class SolidWorksNameSpace:SolidWorksApiModel
    {
        public SolidWorksNameSpace()
        { }
        public SolidWorksNameSpace(string name,string description,
            List<SolidWorksInterfaceModel> interfaceModels, 
            List<SolidWorksDelegateModel> delegateModels,
            List<SolidWorksApiEnumModel> enumModels
            )
        {
            Name = name;
            Description = description;
            InterfaceModels = interfaceModels;
            DelegateModels = delegateModels;
            EnumModels = enumModels;
        }

        /// <summary>
        /// 接口
        /// </summary>
        public List<SolidWorksInterfaceModel> InterfaceModels { get; set; }
        /// <summary>
        /// 委托事件
        /// </summary>
        public List<SolidWorksDelegateModel> DelegateModels { get; set; }

        public List<SolidWorksApiEnumModel> EnumModels { get; set; }
    }
}
