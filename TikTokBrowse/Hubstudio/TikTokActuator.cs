using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TikTokBrowse.Helper;
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
        private static ConcurrentDictionary<string, string> currentVideoIdDict = new ConcurrentDictionary<string, string>();
        private static ConcurrentDictionary<string, int> VideopathDict = new ConcurrentDictionary<string, int>();

        public string Id { get { return _containerCode; } }
       

        public TikTokActuator(string containerCode, ChromeDriver driver)
        {
            _containerCode = containerCode;
            _driver = driver;
            // 每次实例化是将当前正在播放的视频的id存下来
            GetNowVideoId();
        }

        public void IdNum()
        {

        }

        public  bool IsBigScreen()
        {
            try
            {
                // 打开大屏播放视频的div
                _driver.FindElement(By.XPath("//*[@class='tiktok-15ggvmu-DivVideoWrapper e11s2kul9']"));
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

        public void GetNowVideoId()
        {
            try
            {
                IWebElement div = _driver.FindElement(By.XPath("//*[starts-with(@id, 'xgwrapper')]/video/.."));
                string StrId = div.GetAttribute("id");
                string currentVideoId = StrId.Split('-')[2];
                currentVideoIdDict.AddOrUpdate(_containerCode, currentVideoId, (key, value) => currentVideoId);
            }catch
            {
                
            }
        }


        public string  GetTitleTags(string videoPath)
        {
            // 先用正则表达式匹配出路径中的是哪一种业务，然后找到标题的位置，并随机获取一个标题
            string fileName = "";
            string pattern = @"([\u4e00-\u9fa5]+)";
            MatchCollection matches = Regex.Matches(videoPath, pattern);
            foreach (Match match in matches)
            {
                fileName = match.Value;
            }
            string filePath = Path.Combine(@"Y:\", fileName+".txt");
            string[] fileContent = File.ReadAllLines(filePath);
            Random random = new Random();
            int titleTagsIndex = random.Next(0, fileContent.Length - 1);
            string titleTags = fileContent[titleTagsIndex];
            int startIndex = titleTags.IndexOf('"');
            int endIndex = titleTags.LastIndexOf('"');
            string content = titleTags.Substring(startIndex + 1, endIndex - startIndex - 1);

            return content;
        }

        public bool MyUpload(string videoPath)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            // 获取标题
            string titleTags = GetTitleTags(videoPath);

            // 找到上传的input标签，上传视频，和填写标题，等到post按钮可以点击就表示视频加载完成
            IWebElement postElement = null;
            bool PostEnabled = false;
            do
            {
                var inputElements = _driver.FindElements(By.XPath("//input[@accept='video/*']"));
                if (inputElements.Count > 0)
                {
                    inputElements[0].SendKeys(videoPath);
                    var titleTagsElement = _driver.FindElement(By.XPath("//*[@data-text='true']"));
                    //jsExecutor.ExecuteScript($"arguments[0].textContent = '{content}';", titleTagsElement);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    titleTagsElement.SendKeys(titleTags);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
                postElement = _driver.FindElement(By.XPath("//button[string()='Post']"));
                PostEnabled = postElement.Enabled;
            } while (!PostEnabled);
            // 点击Post按钮上传，等待上传完成，若上传完成，则会出现Upload another video按钮，然后点击
            postElement.Click();
            int speed = 0;
            while (speed < 60)
            {
                try
                {
                     _driver.FindElement(By.XPath("//*[string()='Upload another video']")).Click();
                    return true;
                }
                catch { speed++; }
            }

            return false;

            // _driver.SwitchTo().DefaultContent();
        }
        public void GoUpload()
        {
            // 跳转至上传界面
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                _driver.FindElement(By.XPath("//span[text()='Upload ']")).Click();
            }
            catch
            {
                _driver.Navigate().GoToUrl("https://www.tiktok.com/upload?lang=en");
            }
        }

        public void ClickPost(HubstudioClient _client)
        {
            try
            {
                _driver.SwitchTo().Frame(0);
            }
            finally
            {
                //string dir = _client.GetContainerDirectory(_containerCode);
                string dir = @"Y:\Hubstudio\US成人用品001";
                string[] fileNames = new VideoHelper().GetDailyVideoFileName(dir);

                int videoPathIndex = VideopathDict.TryGetValue(_containerCode, out int index) ? index : 0;

                if (MyUpload(fileNames[videoPathIndex]))
                {
                    VideopathDict.AddOrUpdate(_containerCode, 1, (key, OlderValue) => OlderValue + 1);
                }
            }
        }
        // 通用模式
        public void NextVideo()
        {
            if (IsBigScreen())
            {
                // 大屏模式下，找到下一个视频的按钮点击
                _driver.FindElement(By.XPath("//button[@data-e2e='arrow-right']")).Click();
            }
            else
            {
                // 小屏模式下，直接按 ↓ 键
                new Actions(_driver).SendKeys(Keys.Down).Perform();
            }
            //new Actions(_driver).SendKeys(Keys.Down).Perform();
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
        }
        public void PreviousVideo()
        {
            if (IsBigScreen())
            {
                // 大屏模式下，找到上一个视频的按钮点击
                _driver.FindElement(By.XPath("//button[@data-e2e='arrow-left']")).Click();
            }
            else
            {
                // 小屏模式下，直接按 ↑ 键
                new Actions(_driver).SendKeys(Keys.Up).Perform();
            }
            // new Actions(_driver).SendKeys(Keys.Up).Perform();
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
        }
        public IWebElement LikeButton()
        {
            if(IsBigScreen())
            {
                // 点赞按钮
                return _driver.FindElement(By.XPath("//*[@data-e2e='browse-like-icon']"));
            }
            else
            {
                // 点赞按钮
                return ActiveWindows().FindElement(By.XPath(".//*[@data-e2e='like-icon']"));
            }
        }
        public IWebElement FollowButton()
        {
            if (IsBigScreen())
            {
                // 关注按钮
                return _driver.FindElement(By.XPath("//*[@data-e2e='browse-follow']"));
            }
            else
            {
                // 关注按钮
                return ActiveWindows().FindElement(By.XPath("./preceding-sibling::div[1]//*[@data-e2e='feed-follow']"));
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
                    // 博主名称
                    bd.BloggerNickName = _driver.FindElement(By.XPath("//span[@data-e2e='browse-username']")).GetAttribute("textContent");
                    // 标题
                    bd.Title = _driver.FindElement(By.XPath("//div[@data-e2e='browse-video-desc']/span[1]")).GetAttribute("textContent");
                    // 所有的标签
                    var AllTags = _driver.FindElements(By.XPath("//div[@data-e2e='browse-video-desc']//a"));
                    bd.TitleTags = new string[AllTags.Count];
                    for (int i = 0; i < bd.TitleTags.Length; i++)
                    {
                        bd.TitleTags[i] = AllTags[i].GetAttribute("textContent");
                    }
                    // 获取的点赞次数
                    bd.LikeNumber = _driver.FindElement(By.XPath("//strong[@data-e2e='browse-like-count']")).GetAttribute("textContent");
                    // 获取的评论次数
                    bd.CommentNumber = _driver.FindElement(By.XPath("//strong[@data-e2e='browse-comment-count']")).GetAttribute("textContent");

                    // 后面的改了一下，没有成功，在大屏模式下，所有的内容都被挡住了，元素是不可见的，获取不到。
                    // 弹出框信息
                    IWebElement parentElement = _driver.FindElement(By.XPath("//*[@class='tiktok-p11q58-DivInfoContainer evv7pft0']"));

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
                    var data = ActiveWindows().FindElement(By.XPath("./.."));
                    // 和上面的方法一样，都只找到对应的位置。
                    bd.BloggerNickName = data.FindElement(By.XPath(".//*[@data-e2e='video-author-uniqueid']")).GetAttribute("textContent");
                    bd.Title = data.FindElement(By.XPath(".//*[@data-e2e='video-desc']/span[1]")).GetAttribute("textContent");
                    var AllTags = data.FindElements(By.XPath(".//*[@data-e2e='video-desc']//a"));
                    bd.TitleTags = new string[AllTags.Count];
                    for (int i = 0; i < bd.TitleTags.Length; i++)
                    {
                        bd.TitleTags[i] = AllTags[i].GetAttribute("textContent");
                    }

                    bd.LikeNumber = data.FindElement(By.XPath(".//*[@data-e2e='like-count']")).GetAttribute("textContent");
                    bd.CommentNumber = data.FindElement(By.XPath(".//*[@data-e2e='comment-count']")).GetAttribute("textContent");

                    
                    /*// 使用 JavaScript 执行器获取伪元素 ::after 的内容
                    string script = "return window.getComputedStyle(arguments[0], ':after').content;";
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                    string afterContent = (string)jsExecutor.ExecuteScript(script, parentElement);*/
                    // share = data.FindElement(By.XPath("div/div[2]/div[2]/button[3]/strong")).Text;
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

        public void  BigScreenMode()
        {
            if (!IsBigScreen())
            {
                // 点击正在播放的视频
                _driver.FindElement(By.XPath("//*[starts-with(@id, 'xgwrapper')]/video")).Click();

            }
        }
        public void ExitBigScreenMode()
        {
            if (IsBigScreen())
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                // 获取当前正好在播放视频的div的id
                string currentVideoId = currentVideoIdDict[_containerCode];
                string xpath = $"//*[starts-with(@id, 'xgwrapper') and contains(@id, '{currentVideoId}')]/../../../../../..";
                // 找到大屏上的那个(×）按钮，点击
                 _driver.FindElement(By.XPath("//*[@data-e2e='browse-close']")).Click();

                // 在小屏界面通过刚刚的id找到刚刚在播放的视频的div，用 js 移动到那个位置去
                IWebElement element = _driver.FindElement(By.XPath(xpath));
                js.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'instant', block: 'center', inline: 'nearest' });", element);
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
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            // ReadOnlyCollection<IWebElement> iframes = _driver.FindElements(By.TagName("iframe"));
            _driver.SwitchTo().Frame(0);

            IWebElement postElement = null;
            bool PostEnabled = false;
            do
            {
                var inputElements = wait.Until(driver => driver.FindElements(By.XPath("//input[@accept='video/*']")));
                if (inputElements.Count > 0)
                {
                    string videoPath = @"Y:\Hubstudio\US成人用品001\20230328 (1).mp4";
                    inputElements[0].SendKeys(videoPath);
                    Thread.Sleep(3000);
                }
                postElement = wait.Until(driver => driver.FindElement(By.XPath("//button[string()='Post']")));
                PostEnabled = postElement.Enabled;
            } while (!PostEnabled);
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
            ///html/body/div[2]/div[2]/div[2]/div[1]/div[1]
            //return _driver.FindElement(By.ClassName("tiktok-fsk16c-DivVideoControlContainer")).FindElement(By.XPath("../../../../.."));
            // 返回一个当前正在播放视频的div
            return _driver.FindElement(By.XPath("//*[contains(@class, 'tiktok-kd7foj-DivVideoWrapper') and .//*[starts-with(@id, 'xgwrapper')]/video]"));
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
