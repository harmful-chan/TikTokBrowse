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
    }
}
