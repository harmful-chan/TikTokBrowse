using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Models
{
    public class LogInfo
    {
        private int _id;
        /// <summary>
        /// 日志ID
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _createTime;
        /// <summary>
        /// 日志时间
        /// </summary>
        public string CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private string _content;
        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private string _logFileName;
        /// <summary>
        /// 日志保存位置
        /// </summary>
        public string LogFileName
        {
            get { return _logFileName; }
            set { _logFileName = value; }
        }
    }
}
