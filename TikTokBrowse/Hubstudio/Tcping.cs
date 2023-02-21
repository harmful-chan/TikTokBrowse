using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio
{
    internal static class Tcping
    {

        internal async static Task<double> Ping5Async(string ip, int port, int count = 5)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < count; i++)
            {
                var time = await Tcping.PingAsync(ip, port);
                result.Add(time);
            }

            return result.Average();
        }
        internal async static Task<double> PingAsync(string ip, int port)
        {
            return await Task.Run(() =>
            {
                var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                double time = double.MaxValue;
                sock.Blocking = true;
                var stopwatch = new Stopwatch();
                try
                {
                    stopwatch.Start();
                    IAsyncResult asyncResult = sock.BeginConnect(ip, port, null, null);
                    if (!asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(200)))
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
    }
}
