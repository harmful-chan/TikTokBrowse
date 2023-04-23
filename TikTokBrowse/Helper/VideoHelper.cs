using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TikTokBrowse.Models;

namespace TikTokBrowse.Helper
{
    public class VideoHelper
    {
        private ConcurrentDictionary<string, string[]> _titleDict
            = new ConcurrentDictionary<string, string[]>();

        private readonly string _titleFileDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Titles");

        private static readonly ThreadLocal<Random> _threadRandom = new ThreadLocal<Random>(() => new Random());


        public VideoHelper()
        {
            lock (this)
            {
                InitTitleData();
            }
        }
        public void InitTitleData()
        {
            if (_titleDict.Count == 0 && Directory.Exists(_titleFileDirectory))
            {

                string[] txts = Directory.GetFiles(_titleFileDirectory);
                foreach (var txt in txts)
                {
                    string category = Path.GetFileNameWithoutExtension(txt);
                    string[] raws = TextHelper.Read(txt);
                    string[] titles = new string[raws.Length];
                    for (int i = 0; i < raws.Length; i++)
                    {
                        int s = raws[i].IndexOf(' ');
                        titles[i] = raws[i].Substring(s + 2).Replace('\"', '\0');
                    }
                    _titleDict.TryAdd(category, titles);
                }
            }
            else
            {
                throw new FileNotFoundException(_titleFileDirectory);
            }
        }

        public string[] GetTitleCategory()
        {
            return _titleDict.Keys.ToArray();
        }

        public string[] GetDailyVideoFileName(string videoDir)
        {
            lock (videoDir)
            {
                if (!Directory.Exists(videoDir))
                    return null;

                string day = DateTime.Now.ToString("yyyyMMdd");
                return Directory.GetFiles(videoDir, day+"*.mp4");
            }

        }
        public void MaskDailyVideo(string videoFileName)
        {
            lock (videoFileName)
            {
                if (!File.Exists(videoFileName))
                    return;
                string dir = Path.GetDirectoryName(videoFileName);
                string name = Path.GetFileNameWithoutExtension(videoFileName);
                string ext = Path.GetExtension(videoFileName);
                string dstFileName = Path.Combine(dir, $"{name}（已发）{ext}");
                File.Move(videoFileName, dstFileName);
            }
        }
        public string RandomOneTitle(string category)
        {
            return _titleDict.ContainsKey(category) ? 
                _titleDict[category][_threadRandom.Value.Next(0, _titleDict[category].Length - 1)] : "this is a title";
        }
    }
}
