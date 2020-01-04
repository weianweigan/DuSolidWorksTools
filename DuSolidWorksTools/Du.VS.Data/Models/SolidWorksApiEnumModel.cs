using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.Models
{
    public class SolidWorksApiEnumModel : SolidWorksApiModel
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SolidWorksApiEnumModel() { }

        public SolidWorksApiEnumModel(string name,string description,string remark, string avail, List<SolidWorksApiEnumMemberModel> memberList)
        {
            Name = name;
            Description = description;
            MemberList = memberList;
            Remark = remark;
            ApiAvailability = new Availability(avail);
        }

        /// <summary>
        /// 枚举成员
        /// </summary>
        public List<SolidWorksApiEnumMemberModel> MemberList { get; set; }
    }

    public class SolidWorksApiEnumMemberModel
    {
        /// <summary>
        /// 用于序列化的默认构造函数
        /// </summary>
        public SolidWorksApiEnumMemberModel() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="memberDecription"></param>
        public SolidWorksApiEnumMemberModel(string memberName, string memberDecription)
        {
            MemberName = memberName;
            MemberDecription = memberDecription;
        }

        public string MemberName { get; set; }

        public string MemberDecription { get; set; }
    }
}
