using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTokBrowse.Hubstudio.Models;

namespace TikTokBrowse.Models
{
    public class AppData
    {
        public string ConfigFileName { get; set; }
        public string[] VideoTargetTags { get; set; }

        public string OptimalLabelCount { get; set; }

        public string HubStudioConnectorFileName { get; set; }
        public Secret HubStudioSecret { get; set; }

    }
}
