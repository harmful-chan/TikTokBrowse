using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio.Models
{
    public class Container
    {
        public Account[] Accounts { get; set; }
        public string AllOpenTime { get; set; }    //环境最后打开时间
        public string AsDynamicType { get; set; }    //代理使用方式，1-静态，2-动态
        public string ContainerCode { get; set; }    //环境ID
        public string ContainerName { get; set; }    //环境名称
        public string CreateTime { get; set; }    //创建时间
        public string LastCity { get; set; }    //上一次IP的城市
        public string LastCountry { get; set; }    //上一次IP的国家
        public string LastRegion { get; set; }    //洲或省的名称
        public string LastUsedIp { get; set; }    //上一次使用的IP
        public string OpenTime { get; set; }    // 打开时间
        public string ProxyHost { get; set; }    //代理主机
        public string ProxyPort { get; set; }    //代理端口号
        public string ProxyTypeName { get; set; }    // 代理类型
        public string TagName { get; set; }    //环境分组名称
        public string TagCode { get; set; }    //环境ID
    }
}
