using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TikTokBrowse.Hubstudio.Models;

namespace TikTokBrowse.Hubstudio
{
    public class HubstudioClient
    {
        private Process _hubstudioConnector;
        private string _serverMode;
        private int _httpPort;
        private string _appId;
        private string _groupCode;
        private string _appSecret;
        private string _localAddress;
        private string _connectorFileName;        
        private ConcurrentDictionary<string, WorkStatus> _workStatusInfo = new ConcurrentDictionary<string, WorkStatus>();
        private ConcurrentDictionary<int, string[]> _workArea = new ConcurrentDictionary<int, string[]>();
        public delegate void ActuatorEventDelegate(TikTokActuator actuator);
        public delegate void CycleActuatorEventDelegate(TikTokActuator actuator, ref bool isContinue, ref int count);
        public bool IsOpenConnector { get; private set; }
        public bool IsWork(string containerCode)
        {
            return _workStatusInfo.ContainsKey(containerCode);
        }

        private int _screenCount;
        private int _screenContainerCount;
        public HubstudioClient(string connectorFileName, Secret appSecret)
        {
            _connectorFileName = connectorFileName;
            _serverMode = appSecret.ServerMode;
            _httpPort = appSecret.HttpPort;
            _appId = appSecret.AppId;
            _groupCode = appSecret.GroupCode;
            _appSecret = appSecret.AppSecret;
            _localAddress = $"http://127.0.0.1:{_httpPort}";

            _screenCount = Screen.AllScreens.Count();
            _screenContainerCount = 10; // 2行，每行5个
            
            for (int i = 0; i < _screenCount; i++)
            {
                _workArea[i] = new string[_screenContainerCount];
            }
            
            
            ThreadPool.SetMaxThreads(10, 10);
        }


        #region 连接器
        public async Task<bool> OpenConnectorAsync()
        {
            try
            {
                if (_hubstudioConnector == null)
                {
                    Process[] processes = Process.GetProcesses();
                    Process hubstudio = processes.Where(p => p.ProcessName.ToLower().Equals("hubstudio")).FirstOrDefault();
                    if (hubstudio != null)
                    {
                        _hubstudioConnector = hubstudio;
                    }
                    else
                    {
                        _hubstudioConnector = new Process();
                        _hubstudioConnector.StartInfo.FileName = _connectorFileName;
                        //_hubstudioConnect.StartInfo.RedirectStandardInput = true;
                        //_hubstudioConnect.StartInfo.RedirectStandardOutput = true;
                        //_hubstudioConnect.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                        //_hubstudioConnect.StartInfo.CreateNoWindow = true;
                        //_hubstudioConnect.OutputDataReceived += _hubstudioConnect_OutputDataReceived;
                        _hubstudioConnector.StartInfo.UseShellExecute = true;
                        _hubstudioConnector.StartInfo.Arguments = $"--server_mode={_serverMode} --http_port={_httpPort} --app_id={_appId} --group_code={_groupCode} --app_secret={_appSecret}";
                        _hubstudioConnector.Start();
                        //_hubstudioConnect.BeginOutputReadLine();
                        //_hubstudioConnect.WaitForExit();
                    }


                    // 等待端口可用
                    return await Task.Run(async ()=>
                    {
                        while (true)
                        {
                            double time = await Tcping.Ping5Async("127.0.0.1", _httpPort, 2);
                            if (time < 1000.00)
                            {
                                IsOpenConnector = true;
                                return true;
                            }
                            Thread.Sleep(1000);
                        }
                    });


                }
            }
            catch (Exception ex)
            {
                IsOpenConnector = false;
                throw ex;
            }

            return false;
        }

        public bool KillConnector()
        {
            try
            {
                if (_hubstudioConnector != null)
                {
                    _hubstudioConnector.Kill();
                    _hubstudioConnector.Close();
                    _hubstudioConnector = null;
                    Process[] processes = Process.GetProcessesByName("Hubstudio");
                    for (int i = 0; i < processes.Length; i++)
                    {
                        processes[i].Kill();
                    }
                    IsOpenConnector = false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }
        #endregion

        #region API接口
        public async Task<Group[]> GetGroupsAsync()
        {
            return await JsonRequestAsync<Group[]>($"{_localAddress}/api/v1/group/list", null, ".data");
        }
        
        public async Task<Container[]> GetContainersByGroupNameAsync(params string[] tagNames)
        {
            string tag = JsonConvert.SerializeObject(tagNames);
            string body = $"{{" +
                $"\n\t\"tagNames\":{tag}," +
                $"\n\t\"size\":150" +
                $"\n}}";
            return await JsonRequestAsync<Container[]>($"{_localAddress}/api/v1/env/list", body, "..data.list");
        }
        
        public async Task<Container[]> GetContainersByCodeAsync(params string[] containerCodes)
        {
            string tag = JsonConvert.SerializeObject(containerCodes);
            string body = $"{{\n\t\"containerCodes\":{tag}\n}}";
            return await JsonRequestAsync<Container[]>($"{_localAddress}/api/v1/env/list", body, "..data.list" );
        }

        public async Task<bool> OpenWebAsync(string containerCode, Rectangle area)
        {

            string body = $"{{" +
                $"\n\t\"containerCode\":\"{containerCode}\"," +
                $"\n\t\"isWebDriverReadOnlyMode\":false," +
                $"\n\t\"args\":[\"--no-sandbox\"]" +
                $"\n}}";
            Hubstudio.Models.Web web = await JsonRequestAsync<Web>($"{_localAddress}/api/v1/browser/start", body, null);
            if (web.Code == WebStatusTypes.成功)
            {

                Hubstudio.Models.Container[] containers = await GetContainersByCodeAsync(containerCode);
                ChromeDriver chromeDriver = GetChromeDriver(web);
                WorkStatus wc = new WorkStatus();
                wc.Web = web;
                wc.Container = containers[0];
                wc.Driver = chromeDriver;
                wc.Area = area;
                wc.Result = ActionTypes.NONE;
                _workStatusInfo[containerCode] = wc;
                await Task.Run(() =>
                {
                    new TikTokActuator(containerCode, chromeDriver).Resize(area);
                    new TikTokActuator(containerCode, chromeDriver).SwitchWebsite();
                });

                return true;
            }
            return false;
        }
        
        public async Task<bool> CloseWebAsync(string containerCode)
        {
            string body = $"containerCode={containerCode}";
            if( 0 == await JsonRequestAsync<int>($"{_localAddress}/api/v1/browser/stop", body, ".code", method: "GET"))
            {
                WorkStatus workContainerInfo;
                _workStatusInfo.TryRemove(containerCode, out workContainerInfo);
                if (workContainerInfo.Container.ContainerCode.Equals(containerCode))
                {
                    return true;
                }
            }
            return false;
        }
        
        private T JsonRequest<T>(string url, string body = null, string responseToken = null, string method = "POST")
        {
            T t = default(T);
            HttpWebRequest request = null;

            HttpWebResponse response = null;
            Stream responseStream = null;
            StreamReader streamReader = null;
            try
            {
                if (method.Equals("GET"))
                {
                    request = (HttpWebRequest)WebRequest.Create(url + $"?{body}");
                    request.ContentType = "application/json;charset=utf-8";
                    request.Method = method;
                }
                else
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.ContentType = "application/json;charset=utf-8";
                    request.Method = method;
                    // 设置请求表单
                    if (!string.IsNullOrWhiteSpace(body))
                    {
                        byte[] payload = Encoding.GetEncoding("utf-8").GetBytes(body);
                        request.ContentLength = payload.Length;
                        using (Stream write = request.GetRequestStream())
                        {
                            write.Write(payload, 0, payload.Length);
                        }
                    }

                }
                response = (HttpWebResponse)request.GetResponse();
                responseStream = response.GetResponseStream();
                streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                // 解析响应body
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    JObject o = (JObject)JToken.ReadFrom(jsonTextReader);
                    string v = (!string.IsNullOrWhiteSpace(responseToken) ? o.SelectToken(responseToken) : o).ToString();
                    t = JsonConvert.DeserializeObject<T>(v);
                }
                streamReader.Close();
                responseStream.Close();
            }
            catch (Exception ex)
            {
                t = default(T);
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return t;
        }
        
        private Task<T> JsonRequestAsync<T>(string url, string body = null, string responseToken = null, string method = "POST")
        {
            return Task.Run<T>(() =>
            {
                return JsonRequest<T>(url, body, responseToken, method);
            });
        }
        #endregion
        private ChromeDriver GetChromeDriver(Hubstudio.Models.Web web)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.BinaryLocation = web.Data.BrowserPath;
            chromeOptions.DebuggerAddress = $"127.0.0.1:{web.Data.DebuggingPort}";
            // 关闭黑窗
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(web.Data.Webdriver));
            chromeDriverService.HideCommandPromptWindow = true;
            return new ChromeDriver(chromeDriverService, chromeOptions);

        }


        public void SetAreaHolder(int screenNumber, int index, string containerCode)
        {
            if (screenNumber <= _screenCount)
            {
                _workArea[screenNumber][index] = containerCode;
            }
        }
        public int GetAvailableIndex(int screenNumber)
        {
            if( screenNumber <= _screenCount)
            {
                Rectangle screenArea = Screen.AllScreens[screenNumber].WorkingArea;
                int i;
                for ( i = _workArea[screenNumber].Length -1; i >=0 ; i--)
                {
                    if (string.IsNullOrWhiteSpace(_workArea[screenNumber][i]))
                    {
                        break;
                    }
                }
                return i;
            }
            return -1;
        }
        public Rectangle GetOrdinaryRectangle(int screenNumber, int index)
        {
            return GetRectangle(screenNumber, index, new Size(600, 900));
        }
        public Rectangle GetRectangle(int screenNumber, int index, Size size) 
        {
            if (screenNumber <= _screenCount)
            {
                Rectangle screenArea = Screen.AllScreens[screenNumber].WorkingArea;
                int x = screenArea.X + (screenArea.Width - size.Width) / 4 * (index % 5);
                int y = screenArea.Height / 2 * (index < 5 ? 1 : 0);
                return new Rectangle(x, y, size.Width, size.Height);

            }
            return new Rectangle(0, 0, size.Width, size.Height);
        }



        public void SingleWorks(string code, ActuatorEventDelegate actuator)
        {
            ThreadPool.QueueUserWorkItem((status)=> 
            {
                try
                {
                    actuator?.Invoke(new TikTokActuator(code, _workStatusInfo[code].Driver));
                }
                catch (NoSuchElementException ex)
                {

                }
                catch (Exception ex)
                {

                }

            });
        }

        public void CycleWork(string code, CycleActuatorEventDelegate actuator)
        {
            ThreadPool.QueueUserWorkItem((status) =>
            {
                bool result = false;
                int count= 0;
                do
                {
                    try
                    {
                        count++;
                        actuator?.Invoke(new TikTokActuator(code, _workStatusInfo[code].Driver), ref result, ref count);
                    }
                    catch (NoSuchElementException ex)
                    {

                    }
                    catch (Exception ex)
                    {

                    }

                } while (result);
            });
        }
    }
}
