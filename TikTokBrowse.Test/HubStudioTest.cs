using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TikTokBrowse.Hubstudio;
using TikTokBrowse.Models;
using System.Linq;
using TikTokBrowse.Hubstudio.Models;
using TikTokBrowse.Helper;
using System.IO;

namespace TikTokBrowse.Test
{
    [TestClass]
    public class HubStudioTest
    {
        HubstudioClient _client;
        string _containerCode;
        Rectangle area;

        // MSTest，xUtil
        string _name;
        [TestInitialize]
        public  void TestInitialize()
        {
            string cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            AppData appData = TextHelper.Extract<AppData>(cfgPath);
            _client = new HubstudioClient(appData.HubStudioConnectorFileName, appData.HubStudioSecret);
            
            if (_client.OpenConnectorAsync().Result)
            {
                int index = _client.GetAvailableIndex(0);
                Rectangle area = _client.GetOrdinaryRectangle(0, index);

                Group[] group = _client.GetGroupsAsync().Result;
                Group gt = group.Where(g => g.TagName.Equals("TikTok账号")).FirstOrDefault();
                Container[] containers = _client.GetContainersByGroupNameAsync(gt.TagName).Result;
                Container cs = containers.Where(g => g.ContainerName.Equals("英国 - fbs.students - 测试")).FirstOrDefault();

                if(_client.OpenWebAsync(cs.ContainerCode, area).Result)
                {
                    //throw new NotImplementedException();
                }

                // 获取当前video数据，博主的名字，视频的title
           
            }
        }

       //[TestMethod]
       //public void TestNext()
       //{
       //    _client.SingleWorks(_containerCode, (a) =>
       //    {
       //        a.NextVideo();
       //        a.PreviousVideo();
       //    });
       //    
       //}
        [TestMethod]
        public void TestNextVideo()
        {
            _client.SingleWorks(_containerCode, (a) =>
            {
                a.NextVideo();
            });
        }

        [TestMethod]
        public void TestIPreviousVideo()
        {
            _client.SingleWorks(_containerCode, (a) =>
            {
                a.PreviousVideo();
                // 获取当前video的title；
                ;

                Assert.IsTrue(_name.Equals("title"));
            });
        }

        bool isWorking = false;
        [TestMethod]
        public void TestIsBigScreen()
        {
            bool flag  = false;
            isWorking = true;
            _client.SingleWorks(_containerCode, (a) =>
            {
                flag = a.IsBigScreen();
                isWorking = false;
            });

            //Task task = new Task(()=> { });
            //task.Wait();

            while (isWorking)
            {
                Thread.Sleep(200);
            }

            Assert.IsTrue(flag);
        }

    }
}
