using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio.Models
{
    public class WebDescribe
    {
        public string AccountId { get; set; }
        public string Action { get; set; }
        public string BackgroundPluginId { get; set; }
        public string BrowserID { get; set; }
        public string BrowserPath { get; set; }
        public string DebuggingPort { get; set; }
        public string DownloadPath { get; set; }
        public string Duplicate { get; set; }
        public string Ip { get; set; }
        public string IsDynamicIp { get; set; }
        public string LauncherPage { get; set; }
        public string ProxyTag { get; set; }
        public string ProxyType { get; set; }
        public string ReportPluginId { get; set; }
        public string RunMode { get; set; }
        public string Webdriver { get; set; }//根据当前打开环境的内核返回对应内核webdriver驱动路径
        public string StatusCode { get; set; }
    }
}
