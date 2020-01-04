using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Du.Interface;

namespace Du.VS.Model
{
    public class SolidWorksApiPropertyModel:SolidWorksApiModel,IApiVisualBasic,IApiCSharp,IApiCpp
    {
        
        /// <summary>
        /// 属性描述
        /// </summary>
        public string PropertyValue { get; set; }
        #region 语法
        public string VisualBasicDeclarationSyntax { get ; set ; }
        public string VisualBasicUsageSyntax { get ; set ; }
        public string CppSyntax { get; set; }
        public string CSharpSyntax { get; set ; }
        #endregion
    }
}
