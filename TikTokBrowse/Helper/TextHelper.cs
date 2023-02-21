using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TikTokBrowse.Helper
{
    public class TextHelper
    {
        private static ReaderWriterLockSlim TextWriteLock = new ReaderWriterLockSlim();
        public static T Extract<T>(string fileName) where T: new()
        {

            try
            {
                string text = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<T>(text);
            }
            catch(Exception ex)
            {

            }
            return default(T);
        }
        public static void Storage<T>(T t, string fileName)
        {
            string text = "";
            try
            {
                text = JsonConvert.SerializeObject(t, Formatting.Indented);
                TextWriteLock.EnterWriteLock();
                File.WriteAllText(fileName, text);
                
            }catch(Exception ex)
            {

            }
            finally
            {
                TextWriteLock.ExitWriteLock();
            }
        }

        public static string[] Read(string fileName)
        {
            try
            {
                return  File.ReadAllLines(fileName);

            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static void Write(string raw, string fileName, int sizeLimit = -1)
        {
            try
            {
                TextWriteLock.EnterWriteLock();
                File.WriteAllText(fileName, raw);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                TextWriteLock.ExitWriteLock();
            }
        }

        public static void AppendLine(string line, string fileName, int sizeLimit = -1)
        {
            try
            {
                TextWriteLock.EnterWriteLock();
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
                 
                File.AppendAllText(fileName, line+"\r\n");
                //using (FileStream fs = fileInfo.OpenWrite())
                //{
                //    StreamWriter w = new StreamWriter(fs, Encoding.UTF8);
                //    w.BaseStream.Seek(0, SeekOrigin.End);
                //    w.WriteLine(raw);
                //    w.Flush();
                //    w.Close();
                //}

            }
            catch (Exception ex)
            {

            }
            finally
            {
                TextWriteLock.ExitWriteLock();
            }
        }
    }
}
