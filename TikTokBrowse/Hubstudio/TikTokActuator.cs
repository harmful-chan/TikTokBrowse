using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TikTokBrowse.Hubstudio.Extensions;
using TikTokBrowse.Hubstudio.Models;

namespace TikTokBrowse.Hubstudio
{
    // 方向键可以滑动
    // 选项卡列表          //*[@id="app"]/div[2]/div[2]/div[1]
    // 第一个选项卡        //*[@id="app"]/div[2]/div[2]/div[1]/div[1] class="tiktok-1nncbiz-DivItemContainer etvrc4k0"
    // 个人页连接          //*[@id="app"]/div[2]/div[2]/div[1]/div[1]/a href="/@apdo_magdy" class="avatar-anchor tiktok-k03g04 etvrc4k4"
    // 用户名             //*[@id="app"]/div[2]/div[2]/div[1]/div[1]/div/div[1]/div[1]/a[2]/h3 inhtml class="tiktok-debnpy-H3AuthorTitle emt6k1z0"
    // Follow            //*[@id="app"]/div[2]/div[2]/div[1]/div[5]/div/div[1]/button
    // 播放视频           //*[@id="app"]/div[2]/div[2]/div[1]/div[5]/div/div[2]/div[1]/div tiktok-3g8031-DivVideoPlayerContainer e1bh0wg715
    // like              //*[@id="app"]/div[2]/div[2]/div[1]/div[2]/div/div[2]/div[2]/button[1]/span
    // like 数            //*[@id="app"]/div[2]/div[2]/div[1]/div[2]/div/div[2]/div[2]/button[1]/strong
    // 评论数             //*[@id="app"]/div[2]/div[2]/div[1]/div[2]/div/div[2]/div[2]/button[2]/strong
    // 个人信息弹窗        //*[@id="app"]/div[2]/div[2]/div[1]/div[2]/div[2]
    // 正在播放会弹出进度条 //*[@id="app"]/div[2]/div[2]/div[1]/div[1]/div/div[2]/div[1]/div/div[4] class="tiktok-fsk16c-DivVideoControlContainer e1n49v436"
    // 播放进度           //*[@id="app"]/div[2]/div[2]/div[1]/div[1]/div/div[2]/div[1]/div/div[4]/div[2] class="tiktok-1atuw3p-DivSeekBarTimeContainer e1n49v432
    //                   //*[@id="app"]/div[2]/div[2]/div[1]/div[3]/div/div[2]/div[1]/canvas
    // 标题区域           //*[@id="main-content-homepage_hot"]/div[1]/div[1]/ div/div[1]/div[2]/div/div[2]/div
    //                   //*[@id="main-content-homepage_hot"]/div[1]/div[2]/ div/div[1]/div[2]/div/div[2]/div

    // 上传连接           //https://www.tiktok.com/upload?lang=en
    // 上传按钮           /html/body/div/div/div/div/div/div/div/div/div[5]/button
    // 上传表单           /html/body/div/div/div/div/div/div/div/input class="jsx-4258277349 "
    // 上传狂             /html/body/div[1]/div/div/div/div/div[2]/div[1]/div/div jsx-4258277349 upload-card uploading-stage upload-card-narrow
    // 上传进度           /html/body/div[1]/div/div/div/div/div[2]/div[1]/div/div/div[1]/div
    // 预览              /html/body/div[1]/div/div/div/div/div[2]/div[1]/div[1] jsx-750277322 mobile-preview-player
    // title 文本框      /html/body/div[1]/div/div/div/div/div[2]/div[2]/div[2]/div/div[1]/div[2]/div jsx-1043401508 jsx-723559856 jsx-1657608162 jsx-3887553297 container-v2
    //                  /html/body/div[1]/div/div/div/div/div[2]/div[2]/div[2]/div/div[1]/div[2]/div/div[1]/div/div/div/div/div/div/span
    //                  /html/body/div[1]/div/div/div/div/div[2]/div[2]/div[2]/div/div[1]/div[2]/div/div[1]/div/div/div/div/div/div/span text
    //                  /html/body/div[1]/div/div/div/div/div[2]/div[2]/div[2]/div/div[1]/div[2]/div/div[1]/div/div/div/div/div/div/span[2]/span/span text

    // 大屏，点击视频会出现 //*[@id="app"]/div[2]/div[3] tiktok-1qg2388-DivBrowserModeContainer e11s2kul0
    //                   /html/body/div[2]/div[2]/div[3]
    // 大屏，关闭按钮           /html/body/div[2]/div[2]/div[3]/div[1]/button[1]
    // 大屏，评论面板           /html/body/div[2]/div[2]/div[3]/div[2]/div[3]
    // 大屏，评论面板第一个用户名 /html/body/div[2]/div[2]/div[3]/div[2]/div[3]/div[1]/div/div[1]/a/span text
    // 大屏，评论面板第一个评论   /html/body/div[2]/div[2]/div[3]/div[2]/div[3]/div[1]/div/div[1]/p[1]/span text
    // 大屏，评论面板第一个时间   /html/body/div[2]/div[2]/div[3]/div[2]/div[3]/div[1]/div/div[1]/p[2]/span[1] text
    // 大屏，用户名             /html/body/div[2]/div[2]/div[3]/div[2]/div[1]/a[2]/span[1] text
    // 大屏，follower按钮       /html/body/div[2]/div[2]/div[3]/div[2]/div[1]/button
    // 大屏，like按钮           /html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div[1]/div[1]/button[1]
    // 大屏，like数量           /html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div[1]/div[1]/button[1]/strong text
    // 大屏，comment数量        /html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div[1]/div[1]/button[2]/strong text
    //                         /html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div[1]/div[1]/button[2]/strong
    // 大屏，弹出框停留位置          /html/body/div[2]/div[2]/div[3]/div[2]/div[1]/a[2]
    // 大屏。弹出信息框 follower数   /html/body/div[2]/div[2]/div[3]/div[2]/div[1]/div[1]/div[2]/p/span text
    // 大屏。弹出信息框 bio         /html/body/div[2]/div[2]/div[3]/div[2]/div[1]/div[1]/div[2]/p[2] text
    // 大屏，播放进度               /html/body/div[2]/div[2]/div[3]/div[1]/div[2]/div[2]/div[1]/div[2]
    // 大屏，播放时长               /html/body/div[2]/div[2]/div[3]/div[1]/div[2]/div[2]/div[2]
    // 大屏，视频标题区             /html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[1] span.text 内容， a.href="/tag/标签" 可以有多个
    //                     
    // 输入框                     /html/body/div[2]/div[2]/div[3]/div[2]/div[4]/div/div[1]/div
    // 输入框文本                  div/div/div/div/span/span text
    public class TikTokActuator
    {
        private ChromeDriver _driver;
        private string _containerCode;
        public string Id { get { return _containerCode; } }
       

        public TikTokActuator(string containerCode, ChromeDriver driver)
        {
            _containerCode = containerCode;
            _driver = driver;
        }

        private  bool IsBigScreen()
        {
            try
            {
                _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]"));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsWebsiteReady()
        {
            if (IsBigScreen())
            {
                return true;
            }
            else
            {
                try
                {
                    IWebElement webElement = _driver.FindElement(By.ClassName("tiktok-fsk16c-DivVideoControlContainer"));
                    return webElement != null;
                }catch(NoSuchElementException ex)
                {
                    return false;
                }
                


            }
        }
        // 通用模式
        public void NextVideo()
        {
            if (IsBigScreen())
            {
                new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]"))).Perform();
            }
            else
            {
                new Actions(_driver).MoveToElement(ActiveWindows()).Perform();
            }


            new Actions(_driver).SendKeys(Keys.Down).Perform();
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
        }
        public void PreviousVideo()
        {
            if (IsBigScreen())
            {
                new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]"))).Perform();
            }
            else
            {
                new Actions(_driver).MoveToElement(ActiveWindows()).Perform();
            }

            new Actions(_driver).SendKeys(Keys.Up).Perform();
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
        }
        public IWebElement LikeButton()
        {
            if(IsBigScreen())
            {
                return _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div[1]/div[1]/button[1]"));   
            }
            else
            {
                return ActiveWindows().FindElement(By.XPath("div/div[2]/div[2]/button[1]/span"));       // like按钮
            }
        }
        public IWebElement FollowButton()
        {
            if (IsBigScreen())
            {
                return ActiveWindows().FindElement(By.XPath(" /html/body/div[2]/div[2]/div[3]/div[2]/div[1]/button"));
            }
            else
            {
                return ActiveWindows().FindElement(By.XPath("div/div[1]/button"));       // follow按钮
            }
                
        }
        public string GetPlayBarData()
        {
            if (IsBigScreen())
            {
                string text = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[1]/div[2]/div[2]/div[1]/div[2]")).GetAttribute("style"); // 播放进度条
                text = text.Replace("left: calc(", "").Replace(");", "");
                return text;
            }
            else
            {
                string text = _driver.FindElement(By.ClassName("tiktok-ifi2lf-DivSeekBarCircle")).GetAttribute("style"); // 播放进度条
                text = text.Replace("left: calc(", "").Replace(");", "");
                return text;
            }

        }
        public VideoData GetVideoData()
        {
            VideoData bd = new VideoData();
            try
            {
                if (IsBigScreen())
                {
                    bd.BloggerNickName = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[1]/a[2]/span[1]")).Text;
                    var titleArea = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[1]"));
                    foreach (var item in titleArea.FindElements(By.XPath("span")))
                    {
                        bd.Title += item.Text;
                    }
                    var titleA = titleArea.FindElements(By.XPath("a"));
                    bd.TitleTags = new string[titleA.Count];
                    for (int i = 0; i < bd.TitleTags.Length; i++)
                    {
                        bd.TitleTags[i] = titleA[i].FindElement(By.XPath("strong")).Text;
                    }

                    bd.LikeNumber = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div[1]/div[1]/button[1]/strong")).Text;
                    bd.CommentNumber = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div[1]/div[1]/button[2]/strong")).Text;
                    // 弹出框信息
                    new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[1]/a[2]"))).Perform();
                    Thread.Sleep(2000);
                    bd.BloggerFollwers = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[1]/div[1]/div[2]/p/span")).Text;
                    try
                    {
                        bd.BloggerBio = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[1]/div[1]/div[2]/p[2]")).Text;
                    }
                    catch(Exception e)
                    {
                        // 允许没有bio
                    }
                    new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[1]/button"))).Perform();
                    Thread.Sleep(1000);
                }
                else
                {
                    var data = ActiveWindows();
                    var titleArea = data.FindElement(By.XPath("div/div[1]/div[2]/div/div[2]/div"));
                    foreach (var item in titleArea.FindElements(By.XPath("span")))
                    {
                        bd.Title += item.Text;
                    }
                    var titleA = titleArea.FindElements(By.XPath("a"));
                    bd.TitleTags = new string[titleA.Count];
                    for (int i = 0; i < bd.TitleTags.Length; i++)
                    {
                        bd.TitleTags[i] = titleA[i].FindElement(By.XPath("strong")).Text;
                    }
                    bd.LikeNumber = data.FindElement(By.XPath("div/div[2]/div[2]/button[1]/strong")).Text;
                    bd.CommentNumber = data.FindElement(By.XPath("div/div[2]/div[2]/button[2]/strong")).Text;
                    // share = data.FindElement(By.XPath("div/div[2]/div[2]/button[3]/strong")).Text;
                    bd.BloggerNickName = data.FindElement(By.XPath("div/div[1]/div[1]/a[2]/h3")).Text;
                    new Actions(_driver).MoveToElement(data.FindElement(By.XPath("div/div[1]/div[1]/a[2]/h3"))).Perform();
                    Thread.Sleep(2000);
                    bd.BloggerFollwers = data.FindElement(By.XPath("div[2]/div[2]/p/span")).Text;
                    try
                    {
                        bd.BloggerBio = data.FindElement(By.XPath("div[2]/div[2]/p[2]")).Text;

                    }catch(Exception e)
                    {
                        // 允许没有 bio
                    }
                    new Actions(_driver).MoveToElement(data.FindElement(By.XPath("div/div[1]/button"))).Perform(); // 选择关注键停留
                }

            }catch(Exception ex)
            {

            }
            return bd;
               
        }
        public string GetBloggerNickName()
        {
            if (IsBigScreen())
            {
                return _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[1]/a[2]/span[1]")).Text;
            }
            else
            {
                var data = ActiveWindows();
                return data.FindElement(By.XPath("div/div[1]/div[1]/a[2]/h3")).Text;
            }

        }
        public void SwitchWebsite()
        {
            string url = _driver.Url;
            // 检查一下，我们还没有打开其他的窗口并跳转
            while (!url.StartsWith("https://www.tiktok.com/") && _driver.WindowHandles.Count != 2)
            {
                Thread.Sleep(1000);
            }
            if (!url.StartsWith("https://www.tiktok.com/"))
            {
                _driver.Close();
            }
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        }

        public void JumpWebsite()
        {
            _driver.Navigate().GoToUrl(@"https://www.tiktok.com/");
        }

        public void Resize(Rectangle rectangle)
        {
            _driver.Manage().Window.Size = rectangle.Size;
            _driver.Manage().Window.Position = rectangle.Location;
        }

        public void BigScreenMode()
        {
            if (!IsBigScreen())
            {
                Point position = _driver.Manage().Window.Position;
                _driver.Manage().Window.Position = new Point(position.X - 600, position.Y);
                _driver.Manage().Window.Size = new Size(1200, 900);
                ActiveWindows().FindElement(By.XPath("div/div[2]/div[1]/div")).Click();
                
            }
        }
        public void ExitBigScreenMode()
        {
            if (IsBigScreen())
            {
                _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[1]/button[1]")).Click();
                Point position = _driver.Manage().Window.Position;
                _driver.Manage().Window.Position = new Point(position.X + 600, position.Y);
                _driver.Manage().Window.Size = new Size(600, 900);
            }
        }


        #region 上传视频
        public static int WM_CHAR = 0x102;    // 未知
        public static int WM_CLICK = 0x00F5;   // 按钮点击
        public static int WM_SETTEXT = 0x000C; //设置文本
        public static int WM_LBUTTONDOWN = 0x0201; //按钮按下
        public static int WM_LBUTTONUP = 0x0202;//按钮松开
        public static int WM_CLOSE = 0x0010;//关闭
        public static int WM_GETTEXT = 0x000D;//获取文本

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
            string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public void JumpUploadSite()
        {
            _driver.Navigate().GoToUrl(@"https://www.tiktok.com/upload?lang=en");
        }


        public IntPtr FindUploadDialog()
        {
            return FindWindow(null, "打开");
        }
        public void UploadFile(IntPtr mainDialog, string fileName)
        {
            IntPtr ok = FindWindowEx(mainDialog, IntPtr.Zero, null, "打开(&O)");
            IntPtr pathPtr = FindWindowEx(mainDialog, IntPtr.Zero, "ComboBoxEx32", null);
            IntPtr path1Ptr = FindWindowEx(pathPtr, IntPtr.Zero, "ComboBox", null);
            IntPtr edit = FindWindowEx(path1Ptr, IntPtr.Zero, "Edit", null);

            SendMessage(edit, WM_SETTEXT, IntPtr.Zero, fileName);
            SendMessage(ok, WM_CLICK, IntPtr.Zero, null);
        }
        public IWebElement UploadButton()
        {
            //大屏上传按钮 //*[@id=\"root\"]/div/div/div/div/div/div/div/div[5]/button
            //小屏上传按钮 //*[@id=\"root\"]/div/div/div/div/div[2]/div[1]/div/div/div[4]/button
            IWebElement btn1 = By.XPath("//*[@id=\"root\"]/div/div/div/div/div/div/div/div[5]/button").Try(Frame());
            IWebElement btn2 = By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div[1]/div/div/div[4]/button").Try(Frame());
            return btn1 ?? btn2;
        }
        public IWebElement PostButton()
        {
            //POST按钮  //*[@id="root"]/div/div/div/div[2]/div[2]/div[2]/div[7]/div[2]/button css-y1m958
            IWebElement btn1 = By.XPath("//*[@id=\"root\"]/div/div/div/div[2]/div[2]/div[2]/div[7]/div[2]/button").Try(Frame());
            return btn1;
        }
        public IWebElement CanelButton()
        {
            //取消按钮  //*[@id="root"]/div/div/div/div/div[2]/div[1]/div/div/button
            IWebElement btn1 = By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div[1]/div/div/button").Try(Frame());
            return btn1;
        }
        public IWebElement PreviewPlayer()
        {
            //预览窗口   mobile-preview-player
            IWebElement btn1 = By.ClassName("mobile-preview-player").Try(Frame());
            return btn1;
        }
        public string GetVideoTitle()
        {
            //视频标题 //*[@id="root"]/div/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div[2]/div/div[1]/div/div/div/div/div/div/span[1]/span
            return By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div[2]/div/div[1]/div/div/div/div/div/div/span[1]/span")
             .Try(Frame())?.Text;
        }


        private IWebElement Frame()
        {
            return By.XPath("/html/body/div/div/div[2]/div/iframe").Try(_driver);
        }
        #endregion



        // 普通模式
        private IWebElement ActiveWindows()
        {
            return _driver.FindElement(By.ClassName("tiktok-fsk16c-DivVideoControlContainer")).FindElement(By.XPath("../../../../.."));
        }   
        public IWebElement LoginAvatar()
        {
            return _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div/div[2]/div[4]"));
        }

        // 大屏模式

        public CommentData[] GetCommentsDatas()
        {
            var divs = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[3]")).FindElements(By.XPath("div"));
            CommentData[] cds = new CommentData[divs.Count];
            for (int j = 0; j < cds.Length; j++)
            {
                CommentData cd = new CommentData();
                cd.Name = divs[j].FindElement(By.XPath("div/div[1]/a/span")).Text;
                cd.Value = divs[j].FindElement(By.XPath("div/div[1]/p[1]/span")).Text;
                cd.Time = divs[j].FindElement(By.XPath("div/div[1]/p[2]/span[1]")).Text;
                cds[j] = cd;
            }

            return cds;
        }
        public void PushCommentData(string msg)
        {
            IWebElement webElement = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/div[2]/div[4]/div/div[1]/div"));
            new Actions(_driver)
                .Click(webElement)
                .Pause(TimeSpan.FromMilliseconds(500))
                .SendKeys(msg)
                .Pause(TimeSpan.FromMilliseconds(500))
                .SendKeys(Keys.Enter)
                .Perform();
        }


    }
}
