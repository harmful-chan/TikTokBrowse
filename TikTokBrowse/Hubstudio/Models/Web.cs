using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio.Models
{
    public enum WebStatusTypes
    {
        该店铺上次请求的startBrowser还未执行结束 = - 10005,
        数据获取异常 = -10004,
        需要设备认证 = -10013,
        登录失败 = -10003,
        Socket参数非法 = -10002,
        内核窗口创建失败 = -10001,
        未知异常 = -10000,
        成功 = 0,
        初始化数据失败 = 1,
        检测到当前IP无法正常使用请联系客服 = 2,
        初始化时区失败 = 4,
        初始化代理失败 = 5,
        初始化黑白名单 = 6,
        启动内核失败 = 7,
        初始化浏览器个人目录 = 8,
        初始化Cookies失败 = 9,
        初始化浏览器设置文件 = 11,
        初始化代理信息配置 = 13,
    }
    public class Web
    {
        public string Msg { get; set; }
        public WebStatusTypes Code { get; set; }
        public WebDescribe Data { get; set; }
    }
}
