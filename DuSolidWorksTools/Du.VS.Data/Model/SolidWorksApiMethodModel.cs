using Du.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Model
{
    public class SolidWorksApiMethodModel : SolidWorksApiModel, IApiVisualBasic, IApiCSharp, IApiCpp
    {
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

