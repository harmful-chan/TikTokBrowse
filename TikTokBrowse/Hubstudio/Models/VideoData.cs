using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTokBrowse.Hubstudio.Models
{
    public class VideoData
    {
        public string BloggerNickName { get; set; }
        public string BloggerFollwers { get; set; }
        public string BloggerBio { get; set; }
        public string LikeNumber { get; set; }
        public string CommentNumber { get; set; }
        public string Title { get; set; }
        public string[] TitleTags { get; set; }
    }
}
