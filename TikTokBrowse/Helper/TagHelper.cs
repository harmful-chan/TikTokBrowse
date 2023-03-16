using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTokBrowse.Models;

namespace TikTokBrowse.Helper
{
    public class Taghelper
    {
        private ConcurrentDictionary<string, Tag[]> _data = new ConcurrentDictionary<string, Tag[]>();

        private readonly string _tagsFileDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Tags");

        public Taghelper()
        {
            if(_data.Count ==0 && Directory.Exists(_tagsFileDirectory))
            {
          
                string[] txts = Directory.GetFiles(_tagsFileDirectory);
                foreach (var item in txts)
                {
                    string tag = Path.GetFileNameWithoutExtension(item);
                    string[] raws = TextHelper.Read(item);
                    _data.TryAdd(tag, Tag.Converts(raws));
                }
            }
            else
            {
                throw new FileNotFoundException(_tagsFileDirectory);
            }
        }
        
        public Dictionary<string, Tag[]> Identify(params string[] tags)
        {
            Tag[] ts = Tag.Converts(tags);
            return Identify(ts);
        }

        public Dictionary<string, Tag[]> Identify(params Tag[] tags)
        {
            Dictionary<string, Tag[]> dic = new Dictionary<string, Tag[]>();
            foreach (var key in _data.Keys)
            {
                lock (_data[key])
                {
                    IEnumerable<Tag> enumerable = _data[key].Intersect(tags);
                    if (enumerable.Count() > 0)
                    {
                        dic[key] = enumerable.ToArray();
                    }
                }
            }
            return dic;
        }
    }
}
