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
    public class TagHelper
    {
        private ConcurrentDictionary<string, Tag[]> _data = new ConcurrentDictionary<string, Tag[]>();

        private readonly string _tagsFileDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Tags");

        public TagHelper()
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
        public TagData[] Identify(params string[] tags)
        {
            Tag[] ts = Tag.Converts(tags);
            return Identify(ts);
        }

        public TagData[] Identify(params Tag[] tags)
        {
            List<TagData> tagDatas = new List<TagData>() ;
            foreach (var key in _data.Keys)
            {
                Tag[] value = _data[key];
                lock (value)
                {
                    int count = value.Intersect(tags ).Count();
                    if (count > 0)
                    {
                        tagDatas.Add(new TagData() { Name = key, Count = count });
                    }
                }
            }
            return tagDatas.ToArray();
        }
    }
}
