using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio.Models
{
    public class WorkStatus
    {
        public Container Container { get; set; }
        public Web Web { get; set; }
        public ChromeDriver Driver { get; set; }
        public ActionTypes Result { get; set; }
        public Rectangle Area { get; set; }

        public bool IsExecuting { get; set; }

    }
}
