using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using TikTokBrowse.Hubstudio;
using System.Threading;
using OpenQA.Selenium.Interactions;
using TikTokBrowse.Models;
using TikTokBrowse.Hubstudio.Models;
using static TikTokBrowse.Hubstudio.Models.SingleWorkStart;
using System.Collections.Concurrent;
using System.Reflection;
using static TikTokBrowse.Hubstudio.HubstudioClient;
using TikTokBrowse.Helper;

namespace TikTokBrowse
{
    public struct Pix 
    {
        public int screen;
        public int index;
    }

    public partial class MainForm : Form
    {

        private HubstudioClient _client = null;
        private Dictionary<string, BindingSource> _groupData = new Dictionary<string, BindingSource>();
        private ConcurrentDictionary<string, ViewData> _viewData = new ConcurrentDictionary<string, ViewData>();
        private Dictionary<string, Area> _area = new Dictionary<string, Area>();
        private string _configFileName = null;
        private readonly int[] _screenSqe = new int[] { 3, 2, 0, 1 };

        public MainForm()
        {            
            //设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            InitializeComponent();


            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.gird.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.gird, true, null);
            // 允许跨线程更新UI
            CheckForIllegalCrossThreadCalls = false;

        }

        public Pix GetPix()
        {
            int i = 0;
            int j = 0;
            for (; i < 4; i++)
            {
                j = _client.GetAvailableIndex(_screenSqe[i]);
                if ( j >= 0)
                {
                    break;
                }
            }
            Pix p = new Pix();
            p.screen = _screenSqe[i];
            p.index = j;

            return p;
        }

        #region private

        delegate void SetTextCallback(string id, string text);
        private void Info(string id, string text)
        {
            LoggerHelper.Info(id, text);
        }

        private void Wait(string msg, bool isWait = false)
        {
            this.lbWait.Visible = isWait;
            this.lbLog.Text = msg;
            Info("主窗口", msg);

        }

        private void Message(string id, string text)
        {
            LoggerHelper.Message(id, text);
        }
        #endregion

        #region 功能
        
        

        /// <summary>
        /// 不阻塞睡眠
        /// </summary>
        /// <param name="milliseconds"></param>
        private void Sleep(int milliseconds)
        {
            DateTime now = DateTime.Now;
            while (now.AddMilliseconds(milliseconds) > DateTime.Now)
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 获取所选的行并排序
        /// </summary>
        /// <returns></returns>
        private List<DataGridViewRow> GetSortSelectedRows()
        {
            // 上到下排序
            return gird.SelectedRows.Cast<DataGridViewRow>().OrderBy(p => p.Index).Select(p => p).ToList();
        }


        /// <summary>
        /// 根据分组名填充_data数据源，并更新表格
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        private async Task RefreshGridDataByGroupNameAsync(string tagName = null)
        {
            Wait("正在获取环境列表...", true);
            btnChangeGroup.Enabled = false;


            Hubstudio.Models.Group[] groups = await _client.GetGroupsAsync();
            Hubstudio.Models.Group group = groups.Where(g => g.TagName == tagName).FirstOrDefault();
            if (_groupData.ContainsKey(group.TagCode)&& _groupData[group.TagCode].Count > 0)
            {
                gird.DataSource = _groupData[group.TagCode];
            }
            else
            {
                Hubstudio.Models.Container[] containers = await _client.GetContainersByGroupNameAsync(group.TagName);
                BindingSource bs = _groupData[group.TagCode];
                gird.DataSource = bs;
                foreach (var item in containers)
                {
                    ViewData va = new ViewData();
                    va.ContainerCode = item.ContainerCode;
                    va.ContainerName = item.ContainerName;
                    bs.Add(va);
                    _viewData[item.ContainerCode] = va;
                }
            }
            btnChangeGroup.Enabled = true;
            Wait("获取环境列表完成");
        }

        /// <summary>
        /// 获取所有分组信息，并填充到下拉框
        /// </summary>
        /// <returns></returns>
        private async Task RefreshGroupInfoAsync()
        {
            if (_client.IsOpenConnector)
            {
                Wait("正在获取分组列表...", true);
                Hubstudio.Models.Group[] groups = await _client.GetGroupsAsync();
                // "Tiktok账号" 拍到最前
                for (int i = 0; i < groups.Length; i++)
                {
                    if (groups[i].TagName.Equals("TikTok账号") && i != 0)
                    {
                        Hubstudio.Models.Group tmp = new Hubstudio.Models.Group();
                        tmp = groups[0];
                        groups[0] = groups[i];
                        groups[i] = tmp;
                    }
                }
                for (int i = 0; i < groups.Length; i++)
                {
                    _groupData.Add(groups[i].TagCode, new BindingSource());
                }

                this.cbGroup.Items.Clear();
                this.cbGroup.Items.AddRange(Array.ConvertAll(groups, g => g.TagName));
                this.cbGroup.SelectedIndex = 0;
                Wait("获取分组列表完成");
            }

        }

        /// <summary>
        /// 打开货关闭连接器
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SwitchConnectorAsync()
        {
            if (!_client.IsOpenConnector)
            {

                Wait("正在打开连接器...", true);
                if( await _client.OpenConnectorAsync())
                {
                    Wait("打开连接器完成");
                    return true;
                }
            }
            else
            {
                Wait("正在关闭连接器...", true);
                if (_client.KillConnector())
                {
                    Wait("关闭连接器完成");
                    return false;
                }
            }

            return false;
        }
        
        /// <summary>
        /// 根据选择行，打开指定容器
        /// </summary>
        /// <returns></returns>
        private async Task OpenWebAsync()
        {

            foreach (var item in GetSortSelectedRows())
            {
                ViewData va = item.DataBoundItem as ViewData;
                if (!_client.IsWork(va.ContainerCode))
                {
                    Pix pix = GetPix();
                    //int index = _client.GetAvailableIndex(2);
                    //int index = pix.index;
                    Rectangle area = _client.GetOrdinaryRectangle(pix.screen, pix.index);
                    if (pix.index >= 0)
                    {
                        Wait($"正在打开环境...{va.ContainerName}，{va.ContainerCode}...", true);
                        va.ContainerStatus = "打开中...";
                        if (await _client.OpenWebAsync(va.ContainerCode, area))
                        {
                            _client.SetAreaHolder(pix.screen, pix.index, va.ContainerCode);
                            va.ContainerPosition = $"{pix.screen}|{pix.index}";
                            va.ContainerStatus = "已打开";
                            _client.CycleWork(va.ContainerCode, IsReadyWait);
                        }
                        else
                        {
                            va.ContainerStatus = "打开失败";
                        }
                        Wait($"打开环境完成");
                    } 


                }
            }
        }
        private void IsReadyWait(TikTokActuator actuator, ref bool isContinue, ref int count)
        {
            Trace(actuator.Id, ActionTypes.WAIT_READY);
            try
            {
                if (actuator.IsWebsiteReady())
                {
                    Trace(actuator.Id, ActionTypes.WAIT_READY_FINISH);
                    isContinue = false;
                    return;

                }
                else if(count < 5 )
                {
                    Trace(actuator.Id, ActionTypes.WAIT_READY_FINISH, count);
                    isContinue = false;
                    return;
                }
                
            }
            catch(Exception ex)
            {

            }

            isContinue = true;
        }

        /// <summary>
        /// 根据选择行，关闭指定容器
        /// </summary>
        /// <returns></returns>
        private async Task CloseWeb()
        {
            foreach (var item in GetSortSelectedRows())
            {
                ViewData va = item.DataBoundItem as ViewData;
                if (_client.IsWork(va.ContainerCode))
                {
                    Wait($"正在关闭环境...{va.ContainerName}，{va.ContainerCode}...", true);
                    va.ContainerStatus = "关闭中...";
                    if (await _client.CloseWebAsync(va.ContainerCode))
                    {

                        va.ContainerStatus = "已关闭";
                    }
                    else
                    {
                        va.ContainerStatus = "关闭失败";
                    }
                    Wait($"关闭环境完成");
                }
            }
        }

        private void Trace(string id, ActionTypes act, int wait = 0)
        {
            switch (act)
            {
                //Log(id, $"
                case ActionTypes.JUMP_WEBSITE: Info(id, $"{_viewData[id].ContainerStatus = "正在跳转"}"); break;
                case ActionTypes.JUMP_WEBSITE_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "跳转完成"}"); break;
                case ActionTypes.LOGIN_ACCOUNT: Info(id, $"{_viewData[id].ContainerStatus = "正在登录"}"); break;
                case ActionTypes.LOGIN_ACCOUNT_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "登录完成"}"); break;
                case ActionTypes.BIG_SCREEN_MODE: Info(id, $"{_viewData[id].ContainerStatus = "正在进入大屏模式"}"); break;
                case ActionTypes.BIG_SCREEN_MODE_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "进入大屏模式完成"}"); break;
                case ActionTypes.EXIT_BIG_SCREEN_MODE: Info(id, $"{_viewData[id].ContainerStatus = "正在退出大屏模式"}"); break;
                case ActionTypes.EXIT_BIG_SCREEN_MODE_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "退出大屏模式完成"}"); break;
                case ActionTypes.RESIZE_BROWSE: Info(id, $"{_viewData[id].ContainerStatus = "重置窗口位置"}"); break;
                case ActionTypes.RESIZE_BROWSE_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "重置窗口位置完成"}"); break;
                case ActionTypes.WAIT_READY: Info(id, $"{_viewData[id].ContainerStatus = "正在准备网页"}"); break;
                case ActionTypes.WAIT_READY_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "准备网页完成"}"); break;
                case ActionTypes.NEXT_VIDEO: Info(id, $"{_viewData[id].ContainerStatus = "正在跳转下一条视频"}"); break;
                case ActionTypes.NEXT_VIDEO_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "跳转下一条视频完成"}"); break;
                case ActionTypes.PREVIOUS_VIDEO: Info(id, $"{_viewData[id].ContainerStatus = "正在跳转上一条视频"}"); break;
                case ActionTypes.PREVIOUS_VIDEO_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "跳转上一条视频完成"}"); break;
                case ActionTypes.UPDATE_BLOGGER_DATA: Info(id, $"{_viewData[id].ContainerStatus = "正在更新博主数据"}"); break;
                case ActionTypes.VIDEO_LIKE: Info(id, $"{_viewData[id].ContainerStatus = "正在点赞"}"); break;
                case ActionTypes.VIDEO_LIKE_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "点赞完成"}"); break;
                case ActionTypes.VIDEO_FOLLOW: Info(id, $"{_viewData[id].ContainerStatus = "正在关注"}"); break;
                case ActionTypes.VIDEO_FOLLOW_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "关注完成"}"); break;
                case ActionTypes.PUSH_COMMENT: Info(id, $"{_viewData[id].ContainerStatus = "正在发表评论"}"); break;
                case ActionTypes.PUSH_COMMENT_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "发表评论完成"}"); break;
                case ActionTypes.UPDATE_BLOGGER_DATA_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "更新博主数据完成"}"); break;
                case ActionTypes.UPDATE_PLAY_BAR:/* Log(id, $"{_viewData[id].ContainerStatus = "正在更新视频进度"}");*/ break;
                case ActionTypes.UPDATE_PLAY_BAR_FINISH: /* Log(id, $"{_viewData[id].ContainerStatus = "更新视频进度完成"}"); */ break;
                case ActionTypes.EXTRACT_COMMENTS: Info(id, $"{_viewData[id].ContainerStatus = "正在提取评论"}"); break;
                case ActionTypes.EXTRACT_COMMENTS_FINISH: Info(id, $"{_viewData[id].ContainerStatus = "提取评论完成"}"); break;
                case ActionTypes.ELEMENT_NOT_FOUND: Info(id, $"{_viewData[id].ContainerStatus = _viewData[id].ContainerStatus + "_ELEMENT_NOT_FOUND"}"); break;
                case ActionTypes.ERROR: Info(id, $"{_viewData[id].ContainerStatus = _viewData[id].ContainerStatus + "_ERROR"}"); break;
 
                default: break;
            }
        }
 
        private void RunTrace(ActionTypes start, ActionTypes end,  ActuatorEventDelegate actuator)
        {
            foreach (var item in GetSortSelectedRows())
            {
                ViewData va = item.DataBoundItem as ViewData;

                _client.SingleWorks(va.ContainerCode, (a) => 
                {
                    Trace(va.ContainerCode, start);
                    actuator?.Invoke(a);
                    Trace(va.ContainerCode, end);
                });
            }
        }

        private bool InitApp()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtConfigFileName.Text) || !File.Exists(txtConfigFileName.Text))
                {
                    Wait("未设置 配置文件 路径");
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = @"D:\Program Files\Hubstudio\2.19.0.1";
                    openFileDialog.Title = "请选择配置文件";
                    openFileDialog.Filter = "所有文件(*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _configFileName = openFileDialog.FileName;
                    }
                    else
                    {
                        return false;
                    }
                }
                _configFileName = txtConfigFileName.Text;
                
                AppData appData = TextHelper.Extract<AppData>(_configFileName);
                if(appData == null)
                {
                    TextHelper.Storage(new AppData(), _configFileName);
                    return false;
                }else if(string.IsNullOrWhiteSpace(appData.HubStudioConnectorFileName))
                {
                    return false;
                }
                
                if(string.IsNullOrWhiteSpace(appData.ConfigFileName))
                {
                    appData.ConfigFileName = _configFileName;
                    TextHelper.Storage<AppData>(appData, _configFileName);
                    txtConfigFileName.Text = _configFileName;
                }
                _client = new HubstudioClient(appData.HubStudioConnectorFileName, appData.HubStudioSecret);
            }catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        private void UploadBloggerData(string id, object value)
        {
            if (value != null)
            {
                VideoData bd = value as VideoData;
                _viewData[id].BloggerName = bd.BloggerNickName;
                _viewData[id].FollowerNumber = bd.BloggerFollwers;
                _viewData[id].LikeNumber = bd.LikeNumber;
                _viewData[id].CommentNumber = bd.CommentNumber;
            }
        }

        private void UploadVideoProgress(string id, object value)
        {
            if (value != null)
            {
                _viewData[id].VideoProgress = value as string;
            }
        }
        #endregion

        #region 界面
        // 表格自动补充序号
        private void gird_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //获取行对象
            var row = gird.Rows[e.RowIndex];
            //对行的第一列value赋值
            row.Cells[0].Value = row.Index + 1;
        }


        // TabControl 拖拽界面
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);//设置移动后的位置
                Location = mouseSet;
            }
        }

        private void tabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为False
            }
        }

        // 画边框
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
            Color.LightSeaGreen, 2, ButtonBorderStyle.Solid, //左边
            Color.LightSeaGreen, 2, ButtonBorderStyle.Solid, //上边
            Color.LightSeaGreen, 2, ButtonBorderStyle.Solid, //右边
            Color.LightSeaGreen, 2, ButtonBorderStyle.Solid);//底边
        }
        #endregion

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            if (InitApp())
            {
                gird.AutoGenerateColumns = false;
                gird.AutoSize = true;
                // 自动执行
                if (await SwitchConnectorAsync())
                {
                    await RefreshGroupInfoAsync();
                    await RefreshGridDataByGroupNameAsync(this.cbGroup.Text);
                }
            }
            else
            {
                MessageBox.Show("配置文件读取错误，请选择正确配置文件路径，重新打开应用", null, MessageBoxButtons.OKCancel);
                Application.Exit();
            }
        }

        private async void btnChangeGroup_Click(object sender, EventArgs e) => await RefreshGridDataByGroupNameAsync(this.cbGroup.Text);

        private async void 打开环境ToolStripMenuItem_Click(object sender, EventArgs e) => await OpenWebAsync();

        private async void 关闭环境ToolStripMenuItem_Click(object sender, EventArgs e) => await CloseWeb();

        private void 下一个视频ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.NEXT_VIDEO, ActionTypes.NEXT_VIDEO_FINISH, (actuator) => 
            {
                actuator.NextVideo();
            });
        }

        private void 上一个视频toolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.PREVIOUS_VIDEO, ActionTypes.PREVIOUS_VIDEO_FINISH, (actuator) =>
            {
                actuator.PreviousVideo();
            });
        }

        private void 获取视频数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.UPDATE_BLOGGER_DATA, ActionTypes.UPDATE_BLOGGER_DATA_FINISH, (actuator) =>
            {
                VideoData videoData = actuator.GetVideoData();
                UploadBloggerData(actuator.Id, videoData);
            });
        }

        private void 获取视频进度ToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            RunTrace(ActionTypes.UPDATE_PLAY_BAR, ActionTypes.UPDATE_PLAY_BAR_FINISH, (actuator) =>
            {
                string bar = actuator.GetPlayBarData();
                UploadBloggerData(actuator.Id, bar);
            });
        }

        private void 点赞ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.VIDEO_LIKE, ActionTypes.VIDEO_LIKE_FINISH, (actuator) =>
            {
                actuator.LikeButton().Click();
            });
        }

        private void 评论ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.PUSH_COMMENT, ActionTypes.PUSH_COMMENT_FINISH, (actuator) =>
            {
                actuator.PushCommentData("123456");
            });
        }

        private void 关注ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.VIDEO_FOLLOW, ActionTypes.VIDEO_FOLLOW_FINISH, (actuator) =>
            {
                actuator.FollowButton().Click();
            });
        }

        private void 重置窗口大小_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.RESIZE_BROWSE, ActionTypes.RESIZE_BROWSE_FINISH, (actuator) =>
            {
                actuator.Resize(new Rectangle());
            });
        }

        private void 开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RunTrace(ActionTypes.BIG_SCREEN_MODE, ActionTypes.BIG_SCREEN_MODE_FINISH, (actuator) =>
            {
                actuator.BigScreenMode();
            });
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RunTrace(ActionTypes.EXIT_BIG_SCREEN_MODE, ActionTypes.EXIT_BIG_SCREEN_MODE_FINISH, (actuator) =>
            {
                actuator.ExitBigScreenMode();
            });
        }


        private void 分析视频权重ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in GetSortSelectedRows())
            {
                ViewData viewData = item.DataBoundItem as ViewData;
                _client.CycleWork(viewData.ContainerCode, MainLoop);
            }

        }

        private void MainLoop(TikTokActuator actuator, ref bool isContinue, ref int count)
        {
            ViewData row = _viewData[actuator.Id];
            string bloggerNickName = actuator.GetBloggerNickName();

            VideoData video = null;
            bool isUploadBollger = false;

            // 20分钟重新进入页面
            if(count >= 1200)
            {
                Info($"{row.ContainerCode} : {row.ContainerName}", "重新进入tk主页");
                actuator.JumpWebsite();
                count = 0;
            }

            // 数据行与实际观看视频不符合
            if (string.IsNullOrWhiteSpace(row.BloggerName) || !row.BloggerName.Equals(bloggerNickName))
            {
                isUploadBollger = true;
            }


            // 根据进度条
            if (!string.IsNullOrWhiteSpace(row.VideoProgress))
            {
                double rate;
                string str = row.VideoProgress.Replace(" ", "").Replace("%", "");
                if (double.TryParse(str, out rate))
                {
                    if (rate > 30)
                    {
                        Info($"{row.ContainerCode} : {row.ContainerName}", "进度大于30%，下一个视频");
                        Trace(actuator.Id, ActionTypes.NEXT_VIDEO);
                        actuator.NextVideo();
                        isUploadBollger = true;
                    }
                }
            }

            if (isUploadBollger)
            {
                video = actuator.GetVideoData();
                Info($"{row.ContainerCode} : {row.ContainerName}", $"更新视频数据, {video.BloggerNickName}");
                Trace(actuator.Id, ActionTypes.UPDATE_BLOGGER_DATA);
                UploadBloggerData(actuator.Id, video);
            }

            if (video != null)
            {
                //TagData[] tagDatas = new TagUtil().Identify(videoData.TitleTags);
                Tag[] tagDatas =  TikTokBrowse.Models.Tag.Converts(video.TitleTags);
                string tag = "";
                foreach (var data in tagDatas)
                {
                    tag += data.ToString() + " ";
                }
                Info($"{row.ContainerCode} : {row.ContainerName}", $"更新视频数据, {tag}");
                row.Tag = tag;

            }

            string bar = actuator.GetPlayBarData();
            UploadVideoProgress(actuator.Id, bar);

            Thread.Sleep(500);

            isContinue = true;
        }

        private void 跳转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.JUMP_WEBSITE, ActionTypes.JUMP_WEBSITE_FINISH, (actuator) =>
            {
                actuator.JumpWebsite();
            });
        }


    }
}
