using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio.Models
{
    public class CycleWorkStart
    {
        public string ContainerCode { get; set; }
        public bool IsContinuousCycle { get; set; } = false;
        public CycleWorkEventDelegate CycleWorkEvent { get; set; }
        public delegate void CycleWorkEventDelegate(string containerCode, Func<SingleWorkStart, ActionTypes> work);
    }
}
