using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio.Models
{
    public class SingleWorkStart
    {
        public SingleWorkStart()
        {

        }
        public SingleWorkStart(string containerCode, ActionTypes step, WorkEventDelegate workEvent = null)
        {
            ContainerCode = containerCode;
            Step = step;
            WorkEvent = workEvent;

        }
        public string ContainerCode { get; set; }

        public ActionTypes Step { get; set; }

        public WorkEventDelegate WorkEvent { get; set; }


        public TimeSpan TimeSpan { get; set; } = TimeSpan.FromMilliseconds(500);

        public object Input { get; set; }

        public delegate void WorkEventDelegate(string containerCode, ActionTypes ret, object value);

    }
}
