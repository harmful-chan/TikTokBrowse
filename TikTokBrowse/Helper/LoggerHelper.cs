using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using System;
using System.Collections;
using System.Collections.Concurrent;
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
        private static ConcurrentDictionary<string, ReaderWriterLockSlim> _dictWriterLock = new ConcurrentDictionary<string, ReaderWriterLockSlim>();
        private static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string logDirectory = Path.Combine(baseDirectory, "log");

        static LoggerHelper()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(baseDirectory, "log4net.config");
            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
            log = LogManager.GetLogger(typeof(LoggerHelper));
        }
        public static void WindowsLog(string key, string content)
        {
            log.Info($" | {key} | {content}");//写入一条新log
        }

        public static void ContainerLog(string containerName,  string content)
        {
            string fileName = Path.Combine(logDirectory, containerName, $"{DateTime.Now.ToString("yyyy-MM-dd")}.txt");
            string raw = $"{containerName} {DateTime.Now} {content}";
            ThreadAppendLine(fileName, raw, 20 * 1024 * 1024);// 20M
        }


        private static bool ThreadAppendLine(string fileName, string line, int sizeLimit = -1)
        {
            return ThreadAppend(fileName, line + "\r\n", sizeLimit);
        }
        private static bool ThreadAppend(string fileName, string line, int sizeLimit = -1)
        {
            bool ret = false;
            try
            {
                if (!_dictWriterLock.ContainsKey(fileName))
                {
                    _dictWriterLock[fileName] = new ReaderWriterLockSlim();
                }

                _dictWriterLock[fileName].EnterWriteLock();

                string directory = Path.GetDirectoryName(fileName);
                string name = Path.GetFileNameWithoutExtension(fileName);
                string extension = Path.GetExtension(fileName);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);//不存在就创建目录   
                }

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }
                // 文件大小限制操作
                FileInfo fileInfo = new FileInfo(fileName);
                if (fileInfo.Length > sizeLimit)
                {
                    string file = "";
                    for (int i = 0; i < 100; i++)
                    {
                        file = Path.Combine(directory, $"{name}.over{i}{extension}");
                        if (!File.Exists(file))
                        {
                            break;
                        }
                    }
                    File.Copy(fileName, file);
                    if (File.Exists(file))
                    {
                        File.Delete(fileName);
                        File.Create(fileName).Close();
                    }
                }
                File.AppendAllText(fileName, line);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            finally
            {
                _dictWriterLock[fileName].ExitWriteLock();
            }
            return ret;
        }

    }
}
