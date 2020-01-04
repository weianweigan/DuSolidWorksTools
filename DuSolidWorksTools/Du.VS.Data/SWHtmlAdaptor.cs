using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Du.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuApiDataBase
{

    public class SWHtmlAdaptor
    {
        public enum DocType
        {
            Method,
            Property,
            Interface,
            Example,
            NotKonw,
            Delegate,
            Enum
        }

        #region 单例适配器
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private SWHtmlAdaptor()
        { }
        private static SWHtmlAdaptor adaptor;
          public static SWHtmlAdaptor Adaptor
        {
            get
            {
                if (adaptor == null)
                {
                    adaptor = new SWHtmlAdaptor();
                }
                return adaptor;
            }
        }
        #endregion
        /// <summary>
        /// 获取命名控件对象
        /// </summary>
        /// <param name="FileFolder"></param>
        /// <returns></returns>
        public Du.Models.SolidWorksNameSpace GetNameSpaceObj(string FileFolder,string NameSpacesName,string Des)
        {
            List<string> ErrorFile = new List<string>();
            List<SolidWorksInterfaceModel> InterfaceList = new List<SolidWorksInterfaceModel>();
            List<SolidWorksDelegateModel> DelegateList = new List<SolidWorksDelegateModel>();
            List<SolidWorksApiEnumModel> EnumList = new List<SolidWorksApiEnumModel>();
            //遍历文件夹下所有文件
            var files = System.IO.Directory.GetFiles(FileFolder);
            int i = 1;
            Console.WriteLine("个数 " + (files.Length + 1).ToString());
            foreach (var item in files)
            {
                if (Path.GetExtension(item).ToLower().Trim() != ".html" )
                {
                    ErrorFile.Add(item);
                    Console.WriteLine("跳过文件: " + item);
                    continue;
                }
                string[] NameStrArray = Path.GetFileNameWithoutExtension(item).Split('~','_');
                if (NameStrArray[NameStrArray.Length-1] == "members" 
                    || NameStrArray[NameStrArray.Length - 1] == "methods"
                    || NameStrArray[NameStrArray.Length - 1] == "properties"
                    )
                {
                    ErrorFile.Add(item);
                    Console.WriteLine("     Error--" + "文件名字--" + item);
                    continue;
                }
                Console.WriteLine("第 " + i.ToString()+ " 个");
                i++;
                //if (i == 1000)
                //{
                //    break;
                //}
                Console.WriteLine("处理中: " + item);
                string fileStr = GetFileStr(item);
                var obj = GetMethodOrProertyOrEnumObj(fileStr,item,out DocType doctype);
                if (obj == null)
                {
                    Console.WriteLine("Error: " + item);
                    continue;
                }
                Console.WriteLine("完成: " + item);
                Console.WriteLine();
                if (doctype == DocType.Method)
                {
                    var Method = obj as SolidWorksApiMethodModel;
                    //确定接口
                    string InterfaceName = Method.Name.Split('~')[1];
                    bool isContain = false;
                    foreach (var OneInterface in InterfaceList)
                    {
                        if (OneInterface.Name == InterfaceName)
                        {
                            OneInterface.Methods.Add(Method);
                            isContain = true;
                        }
                    }
                    if (!isContain)
                    {
                        SolidWorksInterfaceModel interfaceModel = new SolidWorksInterfaceModel(InterfaceName, new List<SolidWorksApiMethodModel>(), new List<SolidWorksApiPropertyModel>());
                        interfaceModel.Methods.Add(Method);
                        InterfaceList.Add(interfaceModel);
                    }
                    //MethodList.Add(obj as SolidWorksApiMethodModel);
                }
                if (doctype == DocType.Property)
                {
                    var Property = obj as SolidWorksApiPropertyModel;
                    //确定接口
                    string InterfaceName = Property.Name.Split('~')[1];
                    bool isContain = false;
                    foreach (var OneInterface in InterfaceList)
                    {
                        if (OneInterface.Name == InterfaceName)
                        {
                            OneInterface.Properties.Add(Property);
                            isContain = true;
                        }
                    }
                    if (!isContain)
                    {
                        SolidWorksInterfaceModel interfaceModel = new SolidWorksInterfaceModel(InterfaceName, new List<SolidWorksApiMethodModel>(), new List<SolidWorksApiPropertyModel>());
                        interfaceModel.Properties.Add(Property);
                        InterfaceList.Add(interfaceModel);
                    }
                    //PropertyList.Add(obj as SolidWorksApiPropertyModel);
                }
                if (doctype == DocType.Delegate)
                {
                    var Delegate = obj as SolidWorksDelegateModel;
                    //确定接口
                    DelegateList.Add(Delegate as SolidWorksDelegateModel);
        
                }
                if (doctype == DocType.Enum)
                {
                    var Enum = obj as SolidWorksApiEnumModel;
                    EnumList.Add(Enum);
                }
                if (doctype == DocType.Interface)
                {
                    var Interface = obj as SolidWorksInterfaceModel;
                    bool IsContain = false;
                    foreach (var OneInterface in InterfaceList)
                    {
                        if (OneInterface.Name == Interface.Name)
                        {
                            OneInterface.Description = Interface.Description;
                            OneInterface.Remark = Interface.Remark;
                            IsContain = true;
                            break;
                        }
                    }
                    if (!IsContain)
                    {
                        InterfaceList.Add(Interface);
                    }
                }
            }
            Console.WriteLine("处理完成");
            foreach (var item in ErrorFile)
            {
                Console.WriteLine("Error--"+item);
            }
            Console.ReadKey();
            return  new SolidWorksNameSpace(NameSpacesName, Des, InterfaceList,DelegateList, EnumList);
        }
        
        private object GetMethodOrProertyOrEnumObj(string fileStr,string filePath, out DocType thisDocType)
        {
            thisDocType = DocType.NotKonw;
            try
            {
                //获取文档
                var doc = GetAngleSharpDoc(fileStr);
                //获取文档类型
                thisDocType = GetDocType(doc);

                if (thisDocType == DocType.NotKonw)
                {
                    Debug.Print("无效文件" + fileStr);
                    return null;
                }
                if (filePath.Contains("SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.ISimulation~Animation.html"))
                {
                    //string a = "5";
                }
                //获取评论信息
                string Remark = GetRemark(doc);
                //获取描述
                string Description = GetDescription(doc);
                //获取可用版本信息
                string aviablity = GetAvailability(doc);

                if (thisDocType == DocType.Property)
                {
                    return new SolidWorksApiPropertyModel(Path.GetFileNameWithoutExtension(filePath), Description, Remark,aviablity);
                }

                if (thisDocType == DocType.Method)
                {
                    SolidWorksApiParameter ReturnValue = null;
                    List<SolidWorksApiParameter> SWParam = GetParams(doc, ref ReturnValue);

                    return new SolidWorksApiMethodModel(Path.GetFileNameWithoutExtension(filePath), Description, Remark,aviablity, SWParam, ReturnValue);
                }

                if (thisDocType == DocType.Delegate)
                {
                    SolidWorksApiParameter ReturnValue = null;
                    List<SolidWorksApiParameter> SWParam = GetParams(doc, ref ReturnValue);

                    return new SolidWorksDelegateModel(Path.GetFileNameWithoutExtension(filePath), Description, Remark,aviablity, SWParam);
                }
                if (thisDocType == DocType.Enum)
                {
                    List<SolidWorksApiEnumMemberModel> SWEnumMembers = GetEnumMembers(doc);
                    return new SolidWorksApiEnumModel(Path.GetFileNameWithoutExtension(filePath), Description, Remark, aviablity, SWEnumMembers);
                }
                if (thisDocType == DocType.Interface)
                {
                    return new SolidWorksInterfaceModel(Path.GetFileNameWithoutExtension(filePath).Split('~')[1],Description,Remark ,new List<SolidWorksApiMethodModel>(), new List<SolidWorksApiPropertyModel>());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("   Error----"+ex.ToString());
            }
            return null;
        }
        /// <summary>
        /// 获取可用版本信息
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private string GetAvailability(IHtmlDocument doc)
        {
            var availablityNode = doc.QuerySelectorAll("dov").Where(p => p.Id == "availabilitySection");
            if (availablityNode != null && availablityNode.Count() > 0)
            {
                return availablityNode.Single().InnerHtml;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取枚举成员
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private List<SolidWorksApiEnumMemberModel> GetEnumMembers(IHtmlDocument doc)
        {
            List<SolidWorksApiEnumMemberModel> memberList = new List<SolidWorksApiEnumMemberModel>();
            try
            {
                var enumSection = doc.QuerySelectorAll("div").Where(p => p.Id == "enummembersSection").Select(p => p);
                if (enumSection !=null && enumSection.Count() > 0)
                {
                    var EnumNode = enumSection.Single();
                    var tBody = EnumNode.QuerySelectorAll("tbody").Single();
                    if (tBody != null)
                    {
                        var childs = tBody.Children;
                        foreach (var tr in childs)//<tr>节点
                        {
                            string Name = string.Empty;
                            string Description = string.Empty;
                            foreach (var td in tr.Children)
                            {
                                if (td.NodeName.ToLower() == "td" && td.ClassName == "MemberNameCell")
                                {
                                    Name = td.Children[0].InnerHtml;
                                }
                                if (td.NodeName.ToLower() == "td" && td.ClassName == "DescriptionCell")
                                {
                                    Description = td.InnerHtml;
                                }
                            }
                            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Description))
                            {
                                memberList.Add(new SolidWorksApiEnumMemberModel(Name, Description));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("     Error--" + ex.ToString());
            }
            return memberList;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        private List<SolidWorksApiParameter> GetParams(IHtmlDocument doc,ref SolidWorksApiParameter returnValue)
        {
            List<SolidWorksApiParameter> SWParams = new List<SolidWorksApiParameter>();
            var syntaxNode = doc.QuerySelectorAll("div").Where(p => p.Id == "syntaxSection").Select(p => p).Single();
            if (syntaxNode != null)
            {
                //查询语法节点
                var ParamNodeEnum = syntaxNode.Children.Where(p => p.InnerHtml == "Parameters").Select(p => p);
                if (ParamNodeEnum != null && ParamNodeEnum.Count() > 0)
                {
                    var ParamNode = ParamNodeEnum.Single();
                    var h4Params = ParamNode.NextElementSibling;
                    if (h4Params != null )
                    {
                        foreach (var item in h4Params.Children)
                        {
                            if (item.NodeName.ToLower() == "dt")
                            {
                                //构建参数列表
                                string name =(item.Children != null && item.Children.Length > 0)? item.Children[0].InnerHtml : string.Empty ;
                                string ParamValue = string.Empty;
                                if (item.NextElementSibling != null)
                                {
                                    ParamValue = item.NextElementSibling.TextContent;
                                }
                                SolidWorksApiParameter apiParam = new SolidWorksApiParameter(name,ParamValue);
                                SWParams.Add(apiParam);
                            }
                        }
                        //元素后的节点为返回值
                        //返回值
                        var ReturnNode = h4Params.NextElementSibling;
                        if (ReturnNode != null && ReturnNode.InnerHtml.Trim() == "Return Value")
                        {
                            returnValue = new SolidWorksApiParameter("Return Value", ReturnNode.NextElementSibling != null ? ReturnNode.NextElementSibling.TextContent : string.Empty);
                        }
                    }
                }
                else
                {
                    //只有返回值
                    var ReturnNodeEnum = syntaxNode.Children.Where(p => (p.NodeName.ToLower() == "h4" && p.InnerHtml == "Return Value")).Select(p => p);
                    if (ReturnNodeEnum != null && ReturnNodeEnum.Count() > 0)
                    {
                        var ReturnNode = ReturnNodeEnum.Single();
                        if (ReturnNode != null && ReturnNode.InnerHtml.Trim() == "Return Value")
                        {
                            returnValue = new SolidWorksApiParameter("Return Value", ReturnNode.NextElementSibling != null ? ReturnNode.NextElementSibling.TextContent : string.Empty);
                        }
                    }
                }

            }
            if (SWParams.Count == 0)
            {
                SWParams = null;
            }
            return SWParams;
        }

        /// <summary>
        /// 获取描述信息
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private string GetDescription(IHtmlDocument doc)
        {
            var DivNode = doc.QuerySelectorAll("div");

            var alHistoryNode = DivNode.Where(p => (p.Id == "allHistory" &&
            p.ClassName == "saveHistory"
            )).Select(p => p);

            if (alHistoryNode != null)
            {
                var myNode = alHistoryNode.Single();
                if (myNode != null)
                {
                    if (myNode.NextSibling != null)
                    {
                        if (!string.IsNullOrEmpty(myNode.NextSibling.TextContent.Replace("\n", "").Trim()))
                        {
                            return myNode.NextSibling.TextContent.Trim();
                        }
                        else
                        {
                            return myNode.NextElementSibling.InnerHtml.Trim();
                        }
                    }
                }
            }
            //var mainbody = (from node in DivNode
            //                where node.Id == "mainbody" && node.ParentElement.Id == "pagebody"
            //                select node).Single();

            //foreach (var item in mainbody.ChildNodes)
            //{
            //    //截取描述
            //    bool IsDescription = true;
            //    if (IsDescription && item.NodeName.ToLower() == "#text" && item.NextSibling.NodeName.ToLower() == "h1")
            //    {
            //        IsDescription = false;
            //        return item.TextContent.Replace("\n", "").Trim();
            //        break;
            //    }
            //    //Debug.Print(item.NodeName);
            //    //Debug.Print(item.NodeValue);
            //    //Debug.Print(item.TextContent);
            //}
            //var divNode = doc.QuerySelectorAll("div").Where(p => p.Id == "allHistory").Select(p => p).Single();
            //if (divNode != null)
            //{
            //    return divNode.NextElementSibling.Text();
            //}
            return string.Empty;
        }

        /// <summary>
        /// 获取remark节点的内容
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private string GetRemark(IHtmlDocument doc)
        {
            var DivNode = doc.QuerySelectorAll("div");



            var mainbody = (from node in DivNode
                            where node.Id == "mainbody" && node.ParentElement.Id == "pagebody"
                            select node).Single();
            //遍历DotNET synatx remark
            foreach (var item in mainbody.Children)
            {
                
                //获取Remark
                if (item.Id == "remarksSection")
                {
                    return item.InnerHtml;
                }
                
            }
            //var RemarkDivNode = doc.QuerySelectorAll("div").Where(p => p.Id == "remarksSection").Select(p => p).Single();
            //if (RemarkDivNode != null)
            //{
            //    return RemarkDivNode.Children[0].TextContent;
            //}
            return string.Empty;
        }

        /// <summary>
        /// 确定文档类型
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private DocType GetDocType(IHtmlDocument doc)
        {
            var pageTitle = doc.QuerySelectorAll("span").Where(p => p.Id == "pagetitle").Select(p => p).Single();
            if (pageTitle != null)
            {
                var strArray = pageTitle.InnerHtml.Split(' ');
                if (strArray.Length >= 2)
                {
                    if (strArray[1].Trim() == "Method")
                    {
                        return DocType.Method;
                    }
                    if (strArray[1].Trim() == "Property")
                    {
                        return DocType.Property;
                    }
                    if (strArray[1].Trim() == "Delegate")
                    {
                        return DocType.Delegate;
                    }
                    if (strArray[1].Trim() == "Enumeration")
                    {
                        return DocType.Enum;
                    }
                    if (strArray[1].Trim() == "Interface")
                    {
                        return DocType.Interface;
                    }
                }
            }
            return DocType.NotKonw;
        }

        private IHtmlDocument GetAngleSharpDoc(string fileStr)
        {
            //解析字符串文档
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<IHtmlParser>();
            var document = parser.ParseDocument(fileStr);

            return document;
        }

        /// <summary>
        /// 获取文件字符串
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string GetFileStr(string FilePath)
        {
            string Filestr = string.Empty;
            using (StreamReader sr = new StreamReader(FilePath))
            {
                Filestr = sr.ReadToEnd();
            }
            return Filestr;
        }

        #region 私有方法
        /// <summary>
        /// 获取可用版本内容
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static string GetAvailabilitySection(IElement item)
        {

            return "";
        }
        /// <summary>
        /// 获取SeeAlso内容
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static List<SeeAlsoLink> GetSeeAlsoVlaue(IElement item)
        {
            List<SeeAlsoLink> links = new List<SeeAlsoLink>();

            return links;
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 获取评论内容
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static string GetRemarkFormElement(IElement item)
        {
            //throw new NotImplementedException();
            return "";
        }

        /// <summary>
        /// 获取.net syntax 的内容
        /// </summary>
        /// <param name="item"></param>
        /// <param name="methodModel"></param>
        private static void GetDotNetSyntax(IElement item, out string[] SyntaxValue)
        {
            SyntaxValue = new string[4];
            //遍历各个节点
            foreach (var divNode in item.Children)
            {
                if (divNode.Id == null)
                {
                    continue;
                }
                if (divNode.Id == "Syntax_VB")
                {
                    SyntaxValue[0] = GetDotNetSyntaxNodeString(divNode);
                }
                if (divNode.Id == "Syntax_VBUsage")
                {
                    SyntaxValue[1] = GetDotNetSyntaxNodeString(divNode);
                }
                if (divNode.Id == "Syntax_CS")
                {
                    SyntaxValue[2] = GetDotNetSyntaxNodeString(divNode);
                }
                if (divNode.Id.Contains("Syntax_CPP"))
                {
                    SyntaxValue[3] = GetDotNetSyntaxNodeString(divNode);
                }
            }
        }
        /// <summary>
        /// 获取语法节点下的字符串
        /// </summary>
        /// <param name="divNode"></param>
        /// <returns></returns>
        private static string GetDotNetSyntaxNodeString(IElement divNode)
        {
            return divNode.InnerHtml;
        }
        #endregion
    }
}
