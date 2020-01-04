using Du.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.Models
{
    public class SolidWorksApiMethodModel : SolidWorksApiModel, IApiVisualBasic, IApiCSharp, IApiCpp
    {
        public SolidWorksApiMethodModel() { }
        public SolidWorksApiMethodModel(string name,string description,string remark, string aviablity, List<SolidWorksApiParameter> param, SolidWorksApiParameter returnValue)
        {
            Name = name;
            Description = description;
            Remark = remark;
            Param = param;
            ReturnValue = returnValue;
            ApiAvailability = new Availability(aviablity);
        }
        #region 语法syantax
        public string VisualBasicDeclarationSyntax { get; set; }
        public string VisualBasicUsageSyntax { get; set; }
        public string CSharpSyntax { get; set; }
        public string CppSyntax { get; set; }
        #endregion
        /// <summary>
        /// 参数
        /// </summary>
        public List<SolidWorksApiParameter> Param { get; set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public SolidWorksApiParameter ReturnValue { get; set; }
    }
    public class SolidWorksApiParameter
    {
        public SolidWorksApiParameter()
        { }
        public SolidWorksApiParameter(string paramName, string paramDescription)
        {
            ParamName = paramName;
            ParamDescription = paramDescription;
        }

        /// <summary>
        /// 参数名
        /// </summary>
        public string ParamName { get; set; }
        /// <summary>
        /// 参数描述
        /// </summary>
        public string ParamDescription { get; set; }
    }
}

