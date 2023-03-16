using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TikTokBrowse.Helper
{
    public static class  NetworkResultTypes
    {
        public static readonly string Unstable = "未确定";
        public static readonly string Success = "可用";
        public static readonly string Error = "不可用";

        public static readonly string None = "";

    }
    public class NetworkHelper
    {


        public async static Task<string> TcpTestAsync(string ip, int port, int count = 3)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < count; i++)
            {
                var time = await TcpingAsync(ip, port);
                result.Add(time);
            }
            int positive = result.Where(i => i > 0).Count();
            int negative = result.Count - positive;
            double scale = positive / result.Count;
            return scale >= 0.6 ? NetworkResultTypes.Success :
                scale >= 0.3 ? NetworkResultTypes.Unstable : NetworkResultTypes.Error;
        }

        public async static Task<double> TcpingAsync(string ip, int port)
        {
            return await Task.Run(() =>
            {
                var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                double time = double.MinValue;
                sock.Blocking = true;
                var stopwatch = new Stopwatch();
                try
                {
                    stopwatch.Start();
                    IAsyncResult asyncResult = sock.BeginConnect(ip, port, null, null);
                    if (!asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(800)))
                        throw new TimeoutException("connect timeout!");
                    time = stopwatch.Elapsed.TotalMilliseconds;
                }
                catch (Exception e)
                {
                   
                }
                finally
                {
                    stopwatch.Stop();
                    sock.Close();
                    Thread.Sleep(100);
                }
                return time;
            });

        }


        public async static Task<bool> ProxyPingAsync(string uri)
        {
            return await Task.Run(() => 
            {
                return ProxyPing(uri);
            });
        }



        public static bool ProxyPing(string uri)
        {
            bool ret = false;
            try
            {
                WebProxy proxyObject = new WebProxy(uri);
                HttpWebRequest Req = WebRequest.Create("https://www.google.com") as HttpWebRequest;
                Req.Proxy = proxyObject; //设置代理
                Req.Timeout = 2000;   //超时
                HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
                Encoding bin = Encoding.GetEncoding("UTF-8");
                using (StreamReader sr = new StreamReader(Resp.GetResponseStream(), bin)) 
                {
                    string str = sr.ReadToEnd();
                    if (str.Contains("<title>Google</title>"))
                    {
                        ret = true;
                    }
                    sr.Close();
                }
            }catch(Exception ex)
            {
                ret = false;
            }
            return ret;

        } 
        
    }
}
