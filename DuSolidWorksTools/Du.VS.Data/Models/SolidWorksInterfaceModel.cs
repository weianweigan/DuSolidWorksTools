using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.Models
{
    public class SolidWorksInterfaceModel:SolidWorksApiModel
    {
        public SolidWorksInterfaceModel()
        { }
        public SolidWorksInterfaceModel(string name,string description,string remark, List<SolidWorksApiMethodModel> methods, List<SolidWorksApiPropertyModel> properties)
        {
            Name = name;
            Description = description;
            Remark = remark;
            Methods = methods;
            Properties = properties;
        }
        public SolidWorksInterfaceModel(string name,  List<SolidWorksApiMethodModel> methods, List<SolidWorksApiPropertyModel> properties)
        {
            Name = name;
            Methods = methods;
            Properties = properties;
        }

        /// <summary>
        /// 方法
        /// </summary>
        public List<SolidWorksApiMethodModel> Methods { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public List<SolidWorksApiPropertyModel> Properties { get; set; }
    }
}
