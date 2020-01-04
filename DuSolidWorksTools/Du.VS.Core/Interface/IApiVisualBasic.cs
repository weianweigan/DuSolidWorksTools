using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.Interface
{
    public interface IApiVisualBasic
    {
        /// <summary>
        /// VB描述
        /// </summary>
        string VisualBasicDeclarationSyntax { get; set; }
        /// <summary>
        /// VB用法
        /// </summary>
        string VisualBasicUsageSyntax { get; set; }
        

    }
}
