using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TikTokBrowse.Hubstudio.Models;

namespace TikTokBrowse.Hubstudio
{
    public class HubstudioClient
    {
        Process _hubstudioConnector;
        readonly string _serverMode = "http";
        readonly string _httpPort = "6873";
        readonly string _appId = "202301301069736085241851904";
        readonly string _groupCode = "11429245";
        readonly string _appSecret = "MIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCofkuihJVYOIA2GNV13qjck15jgmKMTehykrJWFYIqhJZVEnX7muOX47vmMYy4xp4VO40ruBseVGJ9QNb1dNn+HSH3qEKtrq6M7tDSDCC+ct6CCFqF32gscjyhfHPXm/afM8krtiGB4/U2PNyEpSpYG12V2Fc4eLiobl6Bfp/iqOYlVW7rT/B5khsJ7zV5ihLneiS9a6niwwzD0uCRIK5g4d8CbqjHbYGofc3TBr7fCHktCbwhD91q9J+qLySrXvT3emVTSIr/SL4BeNn8wJYCZ8ZA13/zRWBRA8+7+AQ486rIpT4ORothK7xGctp/7WKUoe7tvINd2/OAQI3AVy4RAgMBAAECggEAP+gPFegFoP1lG5+Vruwxzd+TSFjWufJ+vJ4JR/9GbIv3XPLwjuqzchOtW+TlQ9wJb3Iz3CYrGvjUlj82iMi2Odyg2ocWKzv69ndJ+rEg5js5S8aRVv9iSqFVf8ZtRZThGIcSwSKGWPa2NckltqXShrJyb3grtL6NA01BSQpW6Ceb8sEnlWZtiFfbp/4P0ockmbYYbDnU2XK66HGMWXoNYw/s6zjfMBgDO1beoaaAiV8dWzcI6Zfg9N5w/VquAB48GFuJERrZuar+KeCNUZ2cJ5bWLhha+SsobnXhwyQDLzl0SUj1e6h+3m6H93MoUtzDMWCn9vbRZsXXba9NF2leAQKBgQDU3Xj1T2SDxYGRdZzXVYZ0AM8A2BW6JnVnLmbd+e3+3mJ4t/SNbfKcsvZdYmjVn1IVYMSc7eNshXfBj5bozjv2w7tvbjie1j/DCKXIzb6bt0Rwj4Qiw10kLpF6SYqNwCmyfGSBA4JNThv7PtHO8BL4e4jSEznm0qjcp9Epl03VIQKBgQDKowFp6wkl4VBhX70JE27p1mD3UaBIlNT4h4DeF01PRotjQFBpocQbILN3pM9ya94TB83RZ+ARpPim0koXpQabY2cd458HEOW39/ZZYzawnPE+Q2ujSVLSizQyuqf6U4qgWQ1JmGB2EgRpK4T+RrBXw7jAqWBX3/UEANnP67ZK8QKBgCAE2Gb99D6l/OFmcZsqcDkOzhRwbIQ9uLc2kZ6eM6B8zw8djJmhijbr7IcLgH1xo6U3kxuP5P+z69mfwbFvJDHwK0eNqtKpo5mwuU9FM4C0xoSv8c5Q2LfSkWt1mHPODfedInkNkBIUx7y5LFIWZqQd4OzIm5MO6PuX+qxo5/pBAoGAObuXe4XrZU98h0GvqhZPU3Aw0EYBVKySwPxaSux4qk1/CRgZ0P610MTQXRYnxIHXE7T1fuQJgv1tmpnvYi0yZLM9fdaMSIcX7AJJvc32lvsgAI1U7YDGiBYBGTL1CO0kYer9TiqL0RfxCcXMbmXVeCvbR4j6Wg8Ez88uP374wQECgYA2X10p/1rUD4EavElJlhd6U4XlwCq/bd3reLh73aNYPQBjgukEcBl/my4bZGdbA6a+ydSwkH1rXXDfeYTeziabKeZZH2QQ98xQrgzpBqF6+7LvV+7YiN7yJR9qTvphlGQEQQDlC/t8AP5TZcAq8zvHirNt6fZx2kNi82kYDlmWHQ==";
        readonly string _localAddress = @"http://127.0.0.1:6873";

        public bool IsOpenConnector { get; private set; }
        public HubstudioClient()
        {

        }

        public void OpenConnector(string connectorFileName)
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
                        _hubstudioConnector.StartInfo.FileName = connectorFileName;
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
                    IsOpenConnector = true;
                }
            }
            catch (Exception ex)
            {
                IsOpenConnector = false;
                throw ex;
            }
        }

        public void KillConnector()
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Group[]> GetGroupsAsync()
        {
            return await JsonRequestAsync<Group[]>($"{_localAddress}/api/v1/group/list", null, ".data");
        }
        public async Task<Container[]> GetContainersAsync(params string[] tagGroupNames)
        {
            string tag = JsonConvert.SerializeObject(tagGroupNames);
            string body = $"{{\n\t\"tagNames\":{tag}\n}}";
            return await JsonRequestAsync<Container[]>($"{_localAddress}/api/v1/env/list", body, "..data.list" );
        }
        public async Task<Container[]> GetContainerAsync(params string[] containerCodes)
        {
            string tag = JsonConvert.SerializeObject(containerCodes);
            string body = $"{{\n\t\"containerCodes\":{tag}\n}}";
            return await JsonRequestAsync<Container[]>($"{_localAddress}/api/v1/env/list", body, "..data.list");
        }
        public async Task<Web> OpenWebAsync(string containerCode)
        {
            string body = $"{{\n\t" +
                $"\"containerCode\":\"{containerCode}\",\n\t" +
                $"\"isWebDriverReadOnlyMode\":false,\n\t" +
                $"\"args\":[\"--no-sandbox\"]\n" +
                $"}}";
            return await JsonRequestAsync<Web>($"{_localAddress}/api/v1/browser/start", body, null);
        }

        public async Task<int> CloseWebAsync(string containerCode)
        {
            string body = $"containerCode={containerCode}";
            return await JsonRequestAsync<int>($"{_localAddress}/api/v1/browser/stop", body, ".code", method:"GET");
        }

        private T JsonRequest<T>(string url, string body = null, string responseToken = null, string method="POST")
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
                    request = (HttpWebRequest)WebRequest.Create(url+$"?{body}");
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

                response.Close();
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


    }
}
