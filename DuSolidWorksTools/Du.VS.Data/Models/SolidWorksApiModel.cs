using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.Models
{
    public class SolidWorksApiModel
    {
        public SolidWorksApiModel()
        { }
        public string ApiInnerHtml { get; set; }
        
        public string Name { get; set; }

        public string Url { get; set; }

        private int _Version = 2018;
        /// <summary>
        /// Api版本
        /// </summary>
        public int Version { get { return _Version; } set { _Version = value; } }

        private bool _IsObsolete = false;
        /// <summary>
        /// 是否弃用
        /// </summary>
        public bool IsObsolete { get { return _IsObsolete; }set { _IsObsolete = value; } }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 中文描述
        /// </summary>
        public string CHDescription { get; set; }

        /// <summary>
        /// 示例
        /// </summary>
        public List<SolidWorksApiExample> Examples { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 中文评论
        /// </summary>
        public string CHRemark { get; set; }
        /// <summary>
        /// 相关Api
        /// </summary>
        public List<SeeAlsoLink> SeeAlsoLinkList { get; set; }

        public Availability ApiAvailability { get; set; }
    }

    public class Availability
    {
        public Availability() { }
        public string AvailabiltyStr { get; set; }
        public Availability(string Str)
        {
            AvailabiltyStr = Str;
            //Todo 处理为可用版本
        }
        /// <summary>
        /// 可用版本
        /// </summary>
        public int Version { get { return 2018; } }
    }

    /// <summary>
    /// 其他内容
    /// </summary>
    public class SeeAlsoLink
    {
        public SeeAlsoLink() { }
        public string Description { get; set; }

        public string LinkUrl { get; set; }

        public SeeAlsoLink(string description, string linkUrl) {
            Description = description;
            LinkUrl = linkUrl;
        }
    }

    public class SolidWorksApiExample
    {
        public SolidWorksApiExample() { }
        /// <summary>
        /// 描述
        /// </summary>
        public string ExampleStr { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string ExampleUrl { get; set; }
        /// <summary>
        /// 示例类型
        /// </summary>
        public SolidWorksApiExampleType_e ExampleType { get; set; }
        public enum SolidWorksApiExampleType_e
        {
            CSharp,
            VBA,
            VB_Dot_NET
        }
    }
}
