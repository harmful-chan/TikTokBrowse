using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using TikTokBrowse.Helper;
using TikTokBrowse.Models;

namespace TikTokBrowse.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTag()
        {
            /*
             * #CareerTok
             * #ContentCreator
             * #CoverLetter
             * #JobSeeker
             * #interview
             * #CareerTikTok
             * #MyJob
             *
             */
            //TagData[] tagDatas = new TagUtil().Identify("#TikTokChallenge", "#Contentcreator");
            //Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestLogger()
        {
            /*
             * #CareerTok
             * #ContentCreator
             * #CoverLetter
             * #JobSeeker
             * #interview
             * #CareerTikTok
             * #MyJob
             *
             */
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(() =>
                {
                    
                    for (int j = 0; j < 10; j++)
                    {
                        LoggerHelper.Info($"{Thread.CurrentThread.ManagedThreadId}:{j}", "日志");
                        Thread.Sleep(200);
                    }

                });
                threads[i].Start();
            }
            while (true)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!threads[i].IsAlive)
                    {
                        Debug.WriteLine($"{i}|已中止");
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}
