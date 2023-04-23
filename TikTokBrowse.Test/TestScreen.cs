using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TikTokBrowse.Test
{
    [TestClass]
    public class TestScreen
    {
        [TestMethod]
        public void TestScreenIndex()
        {
            int v = Screen.AllScreens.Count();
            Rectangle screenArea = Screen.AllScreens[0].WorkingArea;
            //SingleWorkStart workStart = new SingleWorkStart(_containerCode, ActionTypes.NEXT_VIDEO);
            //_client.WebWork(workStart);
        }
    }
}
