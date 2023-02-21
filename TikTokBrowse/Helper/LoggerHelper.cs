using log4net;
using log4net.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TikTokBrowse.Models;

namespace TikTokBrowse.Helper
{
    public static class LoggerHelper
    {
        private static log4net.ILog log;
        static LoggerHelper()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(baseDirectory, "log4net.config");
            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
            log = LogManager.GetLogger(typeof(LoggerHelper));
        }
        public static void Info(string id, string content)
        {
            log.Info($" | {id} | {content}");//写入一条新log
        }
        public static void Debug(string id, string content)
        {
            log.Debug($" | {id} | {content}");//写入一条新log
        }
    }
}
