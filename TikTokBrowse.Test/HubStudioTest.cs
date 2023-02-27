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

namespace TikTokBrowse.Test
{
    [TestClass]
    public class HubStudioTest
    {

        HubstudioClient _client;
        string _containerCode;
        Rectangle area;
        [TestInitialize]
        public  void TestInitialize()
        {
            AppData appData = TextHelper.Extract<AppData>(@"D:\Desktop\config.json");
            _client = new HubstudioClient(appData.HubStudioConnectorFileName, appData.HubStudioSecret);
            
            if (_client.OpenConnectorAsync().Result)
            {
                int index = _client.GetAvailableIndex(0);
                Rectangle area = _client.GetOrdinaryRectangle(0, index);

                Group[] group = _client.GetGroupsAsync().Result;
                Group gt = group.Where(g => g.TagName.Equals("TikTok账号")).FirstOrDefault();
                Container[] containers = _client.GetContainersByGroupNameAsync().Result;
                Container cs = containers.Where(g => g.ContainerName.Equals("英国 - fbs.students - 测试")).FirstOrDefault();
            
                if(_client.OpenWebAsync(cs.ContainerCode, area).Result)
                {
                    _containerCode = cs.ContainerCode;
                }
            }
        }

        [TestMethod]
        public void TestNext()
        {
            SingleWorkStart workStart = new SingleWorkStart(_containerCode, ActionTypes.NEXT_VIDEO);
            //_client.WebWork(workStart);
        }


    }
}
