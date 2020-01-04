using Du.Interface;
using System.Collections.Generic;

namespace Du.Models
{
    public class SolidWorksDelegateModel : SolidWorksApiModel, IApiCpp,IApiCSharp,IApiVisualBasic
    {
        public SolidWorksDelegateModel()
        { }
        public SolidWorksDelegateModel(string name, string description, string remark, string aviablity, List<SolidWorksApiParameter> sWParam )
        {
            Name = name;
            Description = description;
            Remark = remark;
            Param = sWParam;
            ApiAvailability = new Availability(aviablity);
        }

        public string CppSyntax { get ; set ; }
        public string CSharpSyntax { get ; set ; }
        public string VisualBasicDeclarationSyntax { get ; set ; }
        public string VisualBasicUsageSyntax { get ; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public List<SolidWorksApiParameter> Param { get; set; }
    }
}