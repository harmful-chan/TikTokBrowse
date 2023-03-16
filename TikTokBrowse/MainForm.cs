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
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace TikTokBrowse
{

    public partial class MainForm : Form
    {

        private HubstudioClient _client = null;
        private Dictionary<string, BindingSource> _groupData = new Dictionary<string, BindingSource>();
        private ConcurrentDictionary<string, RowData> _rowData = new ConcurrentDictionary<string, RowData>();

        private string _oldTagTitle = "主页";
        private readonly string[] 主页 = { "行为", "标签", "评论数", "LIKE数", "粉丝数", "博主", "进度", "发表评论" };
        private readonly string[] 视频上传 = { "视频路径", "上传进度", "视频标题" };

        //private readonly int[] _screenSqe = new int[] { 0, 3, 1, 2 };
        private readonly int[] _screenSqe = new int[] { 1, 3, 1, 2 };
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

            // 不要行头
            gird.RowHeadersVisible = false;
            gird.AutoGenerateColumns = false;
            gird.AutoSize = true;
        }

        // 获取屏幕定位
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
            p.Screen = _screenSqe[i];
            p.Index = j;

            return p;
        }

        #region private

        /// <summary>
        /// 追加窗口信息
        /// </summary>
        /// <param name="text"></param>
        private void TxtLogAppend(string text)
        {
            lock (txtLog)
            {
                if (!this.txtLog.Text.EndsWith("\r\n"))
                {
                    this.txtLog.AppendText("\r\n");
                }
                this.txtLog.AppendText(text);
                this.txtLog.ScrollToCaret();
            }
        }

        /// <summary>
        /// 主窗口日志信息
        /// </summary>
        /// <param name="key">关键信息</param>
        /// <param name="text">内容</param>
        private void WindowsLog(string key, string text)
        {
            LoggerHelper.WindowsLog(key, text);
            TxtLogAppend($"{key} | {text}");
        }

        /// <summary>
        /// 等待信息
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="isWait">是否显示</param>
        private void WaitLog(string msg, bool isWait = false)
        {
            this.lbWait.Visible = isWait;
            this.lbLog.Text = msg;
            WindowsLog("主窗口", msg);
        }
        #endregion

        #region 功能
        
        

        /// <summary>
        /// 不阻塞睡眠
        /// </summary>
        /// <param name="milliseconds"></param>
        private void ThreadSleep(int milliseconds)
        {
            DateTime now = DateTime.Now;
            while (now.AddMilliseconds(milliseconds) > DateTime.Now)
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 获取已排序选中行
        /// </summary>
        /// <returns>横内容</returns>
        private List<RowData> GetSortSelectedViewDataList()
        {
            // 上到下排序
            return gird.SelectedRows
                .Cast<DataGridViewRow>()
                .OrderBy(p => p.Index)
                .Select(p => p.DataBoundItem as RowData)
                .ToList();
        }

        /// <summary>
        /// 获取已点击选中行
        /// </summary>
        /// <returns>横内容</returns>
        private List<RowData> GetSortCheckedRowDataList()
        {
            return (gird.DataSource as BindingSource).Cast<RowData>()
                .Where(r => r.IsChoose).OrderBy(r => r.Index).ToList();
        }

        /// <summary>
        /// 使用容器组名刷新gird信息
        /// </summary>
        /// <param name="tagName">组名</param>
        /// <param name="isRefreshProxyStatus">是否刷新代理状态</param>
        /// <returns></returns>
        private async Task RefreshGridDataByGroupNameAsync(string tagName = null, bool isRefreshProxyStatus = false)
        {
            WaitLog("正在获取环境列表...", true);
            btnChangeGroup.Enabled = false;


            Hubstudio.Models.Group[] groups = await _client.GetGroupsAsync();
            Hubstudio.Models.Group group = groups.Where(g => g.TagName == tagName).FirstOrDefault();
            Hubstudio.Models.Container[] containers = await _client.GetContainersByGroupNameAsync(group.TagName);
            if (_groupData.ContainsKey(group.TagCode)&& _groupData[group.TagCode].Count > 0)
            {
                gird.DataSource = _groupData[group.TagCode];
            }
            else
            {
                isRefreshProxyStatus = true;
                BindingSource bs = _groupData[group.TagCode];
                gird.DataSource = bs;


                for (int i = 0; i < containers.Length; i++)
                {
                    RowData va = new RowData();
                    bs.Add(va);
                    _rowData[containers[i].ContainerCode] = va;
                    va.ContainerCode = containers[i].ContainerCode;
                    va.ContainerName = containers[i].ContainerName;
                    va.Index = i + 1;
                    va.IsChoose = false;
                }


            }
            btnChangeGroup.Enabled = true;
            WaitLog("获取环境列表完成");

            if (isRefreshProxyStatus)
            {
                RowData[] viewDatas = new RowData[_groupData[group.TagCode].Count];
                for (int i = 0; i < viewDatas.Length; i++)
                {
                    viewDatas[i] = _groupData[group.TagCode][i] as RowData;
                }
                await RefreshProxytatusAsync(viewDatas);
            }


        }

        /// <summary>
        /// 刷新代理状态
        /// </summary>
        /// <param name="rowDatas">行数据</param>
        /// <returns></returns>
        public async Task RefreshProxytatusAsync(RowData[] rowDatas)
        {
            string[] codes = Array.ConvertAll(rowDatas, v => { return v.ContainerCode; });
            Hubstudio.Models.Container[] containers = await _client.GetContainersByCodeAsync(codes);
  

            foreach (var item in rowDatas)
            {

                item.ProxyStatus = NetworkResultTypes.None;// NetworkResultTypes.Unstable;
                Hubstudio.Models.Container container = containers.Where(c => c.ContainerCode.Equals(item.ContainerCode)).FirstOrDefault();
                if(container != null && !string.IsNullOrWhiteSpace(container.ProxyHost) && !string.IsNullOrWhiteSpace(container.ProxyPort))
                {
                    new Thread(async () =>
                    {
                        LoggerHelper.ContainerLog(container.ContainerName, "正在测试代理");
                        string proxyHost = container.ProxyHost;
                        string proxyPort = container.ProxyPort;
                        item.ProxyStatus = await NetworkHelper.TcpTestAsync(proxyHost, int.Parse(proxyPort));
                        LoggerHelper.ContainerLog(container.ContainerName, $"{item.ProxyStatus}");
                    }).Start();
                }

            }
        }

        /// <summary>
        /// 刷新组信息
        /// </summary>
        /// <returns></returns>
        private async Task RefreshGroupInfoAsync()
        {
            if (_client.IsOpenConnector)
            {
                WaitLog("正在获取分组列表...", true);
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
                WaitLog("获取分组列表完成");
            }

        }

        /// <summary>
        /// 开启或者关闭连接器状态
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SwitchConnectorAsync()
        {
            if (!_client.IsOpenConnector)
            {

                WaitLog("正在打开连接器...", true);
                if( await _client.OpenConnectorAsync())
                {
                    WaitLog("打开连接器完成");
                    return true;
                }
            }
            else
            {
                WaitLog("正在关闭连接器...", true);
                if (_client.KillConnector())
                {
                    WaitLog("关闭连接器完成");
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// 关闭容器
        /// </summary>
        /// <returns></returns>
        private async Task CloseWebAsync()
        {
            foreach (var va in GetSortCheckedRowDataList())
            {
                if (_client.IsWork(va.ContainerCode))
                {
                    LoggerHelper.ContainerLog(va.ContainerName, "正在关闭环境...");
                    WaitLog($"正在关闭环境...{va.ContainerName}，{va.ContainerCode}...", true);
                    va.ContainerStatus = "关闭中...";
                    if (await _client.CloseWebAsync(va.ContainerCode))
                    {
                        Pix pix = _client.GetAreaHolder(va.ContainerCode);
                        _client.SetAvailableIndex(pix);
                        va.ContainerStatus = "已关闭";
                    }
                    else
                    {
                        va.ContainerStatus = "关闭失败";
                    }
                    WaitLog($"关闭环境完成");
                    LoggerHelper.ContainerLog(va.ContainerName, "关闭环境完成...");
                }
            }
        }

        /// <summary>
        /// 打开容器
        /// </summary>
        /// <returns></returns>
        private async Task OpenWebAsync()
        {
            foreach (var va in GetSortCheckedRowDataList())
            {
                if (!_client.IsWork(va.ContainerCode))
                {
                    Pix pix = GetPix();
                    //int index = _client.GetAvailableIndex(2);
                    //int index = pix.index;
                    Rectangle area = _client.GetOrdinaryRectangle(pix.Screen, pix.Index);
                    if (pix.Index >= 0)
                    {
                        LoggerHelper.ContainerLog(va.ContainerName, "正在打开环境...");
                        WaitLog($"正在打开环境...{va.ContainerName}，{va.ContainerCode}...", true);
                        va.ContainerStatus = "打开中...";

                        Hubstudio.Models.Container[] containers = await _client.GetContainersByCodeAsync(va.ContainerCode);
                        string ret = await NetworkHelper.TcpTestAsync(containers[0].ProxyHost, int.Parse(containers[0].ProxyPort));
                        if (ret.Equals(NetworkResultTypes.Success) && await _client.OpenWebAsync(va.ContainerCode, area))
                        {
                            _client.SetAreaHolder(pix, va.ContainerCode);
                            int i = 0;
                            for (; i < _screenSqe.Length; i++)
                            {
                                if( _screenSqe[i] == pix.Screen)
                                {
                                    break;
                                }
                            }
                            va.ContainerPosition = $"{i} | {pix.Index}";
                            va.ContainerStatus = "已打开";
                            _client.CycleWork(va.ContainerCode, OpenWebReadyWait);
                        }
                        else
                        {
                            va.ContainerStatus = "打开失败";
                        }
                        WaitLog($"打开环境完成");
                        LoggerHelper.ContainerLog(va.ContainerName, "打开环境完成");
                    } 


                }
            }
        }

        /// <summary>
        /// 打开容器等待循环
        /// </summary>
        /// <param name="actuator">执行器</param>
        /// <param name="isContinue">是否继续</param>
        /// <param name="count">循环计数</param>
        /// <param name="err">错误计数</param>
        private void OpenWebReadyWait(TikTokActuator actuator, ref bool isContinue, ref int count, ref int err)
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
        /// 行为记录
        /// </summary>
        /// <param name="id">容器ID</param>
        /// <param name="act">行为</param>
        /// <param name="wait"></param>
        private void Trace(string id, ActionTypes act, int wait = 0)
        {
            switch (act)
            {
                case ActionTypes.JUMP_WEBSITE: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在跳转"}"); break;
                case ActionTypes.JUMP_WEBSITE_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "跳转完成"}"); break;
                case ActionTypes.LOGIN_ACCOUNT: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在登录"}"); break;
                case ActionTypes.LOGIN_ACCOUNT_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "登录完成"}"); break;
                case ActionTypes.BIG_SCREEN_MODE: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在进入大屏模式"}"); break;
                case ActionTypes.BIG_SCREEN_MODE_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "进入大屏模式完成"}"); break;
                case ActionTypes.EXIT_BIG_SCREEN_MODE: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在退出大屏模式"}"); break;
                case ActionTypes.EXIT_BIG_SCREEN_MODE_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "退出大屏模式完成"}"); break;
                case ActionTypes.RESIZE_BROWSE: WindowsLog(id, $"{_rowData[id].ContainerStatus = "重置窗口位置"}"); break;
                case ActionTypes.RESIZE_BROWSE_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "重置窗口位置完成"}"); break;
                case ActionTypes.WAIT_READY: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在准备网页"}"); break;
                case ActionTypes.WAIT_READY_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "准备网页完成"}"); break;
                case ActionTypes.NEXT_VIDEO: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在跳转下一条视频"}"); break;
                case ActionTypes.NEXT_VIDEO_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "跳转下一条视频完成"}"); break;
                case ActionTypes.PREVIOUS_VIDEO: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在跳转上一条视频"}"); break;
                case ActionTypes.PREVIOUS_VIDEO_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "跳转上一条视频完成"}"); break;
                case ActionTypes.UPDATE_BLOGGER_DATA: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在更新博主数据"}"); break;
                case ActionTypes.VIDEO_LIKE: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在点赞"}"); break;
                case ActionTypes.VIDEO_LIKE_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "点赞完成"}"); break;
                case ActionTypes.VIDEO_FOLLOW: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在关注"}"); break;
                case ActionTypes.VIDEO_FOLLOW_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "关注完成"}"); break;
                case ActionTypes.PUSH_COMMENT: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在发表评论"}"); break;
                case ActionTypes.PUSH_COMMENT_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "发表评论完成"}"); break;
                case ActionTypes.UPDATE_BLOGGER_DATA_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "更新博主数据完成"}"); break;
                case ActionTypes.UPDATE_PLAY_BAR:/* Log(id, $"{_viewData[id].ContainerStatus = "正在更新视频进度"}");*/ break;
                case ActionTypes.UPDATE_PLAY_BAR_FINISH: /* Log(id, $"{_viewData[id].ContainerStatus = "更新视频进度完成"}"); */ break;
                case ActionTypes.EXTRACT_COMMENTS: WindowsLog(id, $"{_rowData[id].ContainerStatus = "正在提取评论"}"); break;
                case ActionTypes.EXTRACT_COMMENTS_FINISH: WindowsLog(id, $"{_rowData[id].ContainerStatus = "提取评论完成"}"); break;
                case ActionTypes.ELEMENT_NOT_FOUND: WindowsLog(id, $"{_rowData[id].ContainerStatus = _rowData[id].ContainerStatus + "_ELEMENT_NOT_FOUND"}"); break;
                case ActionTypes.ERROR: WindowsLog(id, $"{_rowData[id].ContainerStatus = _rowData[id].ContainerStatus + "_ERROR"}"); break;
 
                default: break;
            }
        }
 
        /// <summary>
        /// 运行简单任务
        /// </summary>
        /// <param name="start">开始动作</param>
        /// <param name="end">结束动作</param>
        /// <param name="actuator">执行器</param>
        private void RunTrace(ActionTypes start, ActionTypes end,  ActuatorEventDelegate actuator)
        {
            foreach (var va in GetSortCheckedRowDataList())
            {
                _client.SingleWorks(va.ContainerCode, (a) => 
                {
                    Trace(va.ContainerCode, start);
                    actuator?.Invoke(a);
                    Trace(va.ContainerCode, end);
                });
            }
        }

        /// <summary>
        /// 初始化应用配置及变量
        /// </summary>
        /// <returns></returns>
        private bool InitApp()
        {
            try
            {
                string cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                if (File.Exists(cfgPath))
                {
                    AppData appData = TextHelper.Extract<AppData>(cfgPath);
                    _client = new HubstudioClient(appData.HubStudioConnectorFileName, appData.HubStudioSecret);
                }
            }catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 更新博主数据
        /// </summary>
        /// <param name="id">容器ID</param>
        /// <param name="value">值</param>
        private void UploadBloggerData(string id, object value)
        {
            if (value != null)
            {
                VideoData bd = value as VideoData;
                _rowData[id].BloggerName = bd.BloggerNickName;
                _rowData[id].FollowerNumber = bd.BloggerFollwers;
                _rowData[id].LikeNumber = bd.LikeNumber;
                _rowData[id].CommentNumber = bd.CommentNumber;
            }
        }

        /// <summary>
        /// 更新视频数据
        /// </summary>
        /// <param name="id">容器ID</param>
        /// <param name="value">视频数据</param>
        private void UploadVideoProgress(string id, object value)
        {
            if (value != null)
            {
                _rowData[id].VideoProgress = value as string;
            }
        }

        /// <summary>
        /// 切换tab控件标签
        /// </summary>
        /// <param name="tagPageName">显示tab便签</param>
        private void SwitchGird(string tagPageName)
        {
            if(  tagPageName.Equals("主页"))
            {
                HideGridViewColumn(视频上传);
                ShowGridViewColumn(主页);
            }
            if (tagPageName.Equals("视频上传"))
            {
                HideGridViewColumn(主页);
                ShowGridViewColumn(视频上传);
            }
        }

        /// <summary>
        /// 显示表格列
        /// </summary>
        /// <param name="headerText">表格列</param>
        private void ShowGridViewColumn(params string[] headerText)
        {
            foreach (var item in gird.Columns)
            {
                if (item is DataGridViewTextBoxColumn col)
                {
                    if (headerText.Contains(col.HeaderText))
                    {
                        (item as DataGridViewColumn).Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// 隐藏表格列
        /// </summary>
        /// <param name="headerText">表格列</param>
        private void HideGridViewColumn(params string[] headerText)
        {
            foreach (var item in gird.Columns)
            {
                if( item is DataGridViewTextBoxColumn col)
                {
                    if(headerText.Contains(col.HeaderText))
                    {
                        (item as DataGridViewColumn).Visible = false;
                    }
                }
            }
        }

        #endregion

        #region 界面
        // 表格自动补充序号
        private void gird_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //获取行对象
            //var row = gird.Rows[e.RowIndex];
            //对行的第一列value赋值
            //row.Cells[1].Value = row.Index + 1;
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

        #region 按键功能
        private async void btnChangeGroup_Click(object sender, EventArgs e)
        {
            await RefreshGridDataByGroupNameAsync(this.cbGroup.Text);
        }

        private void gird_MouseUp(object sender, MouseEventArgs e)
        {

            List<RowData> viewDatas = GetSortSelectedViewDataList();
            if (viewDatas.Count == 1)
            {
                RowData viewData = viewDatas.First();
                viewData.IsChoose = !viewData.IsChoose;
            }
            else if (viewDatas.Count > 1)
            {
                viewDatas.ForEach(d => d.IsChoose = true);
                gird.ClearSelection();
            }
        }

        private void gird_MouseLeave(object sender, EventArgs e)
        {
            gird.ClearSelection();
        }

        private async void btnOpenWeb_Click(object sender, EventArgs e)
        {
            await OpenWebAsync();
        }

        private async void btnCloseWeb_Click(object sender, EventArgs e)
        {
            await CloseWebAsync();
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.JUMP_WEBSITE, ActionTypes.JUMP_WEBSITE_FINISH, (actuator) =>
            {
                actuator.JumpWebsite();
            });
        }

        private async void btnTestProxy_Click(object sender, EventArgs e)
        {
            await RefreshProxytatusAsync(GetSortCheckedRowDataList().ToArray());

        }

        private void btnResizeWeb_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.RESIZE_BROWSE, ActionTypes.RESIZE_BROWSE_FINISH, (actuator) =>
            {
                actuator.Resize(new Rectangle());
            });
        }

        private void btnOpenScreen_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.BIG_SCREEN_MODE, ActionTypes.BIG_SCREEN_MODE_FINISH, (actuator) =>
            {
                actuator.BigScreenMode();
            });
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {

            RunTrace(ActionTypes.EXIT_BIG_SCREEN_MODE, ActionTypes.EXIT_BIG_SCREEN_MODE_FINISH, (actuator) =>
            {
                actuator.ExitBigScreenMode();
            });
        }

        private void btnNextVedio_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.NEXT_VIDEO, ActionTypes.NEXT_VIDEO_FINISH, (actuator) =>
            {
                actuator.NextVideo();
            });
        }

        private void btnPreviousVideo_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.PREVIOUS_VIDEO, ActionTypes.PREVIOUS_VIDEO_FINISH, (actuator) =>
            {
                actuator.PreviousVideo();
            });
        }

        private void btnGetBloggerData_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.UPDATE_BLOGGER_DATA, ActionTypes.UPDATE_BLOGGER_DATA_FINISH, (actuator) =>
            {
                VideoData videoData = actuator.GetVideoData();
                UploadBloggerData(actuator.Id, videoData);
            });
        }

        private void btnGetVideoBar_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.UPDATE_PLAY_BAR, ActionTypes.UPDATE_PLAY_BAR_FINISH, (actuator) =>
            {
                string bar = actuator.GetPlayBarData();
                UploadBloggerData(actuator.Id, bar);
            });
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.VIDEO_LIKE, ActionTypes.VIDEO_LIKE_FINISH, (actuator) =>
            {
                actuator.LikeButton().Click();
            });
        }

        private void btnFollower_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.VIDEO_FOLLOW, ActionTypes.VIDEO_FOLLOW_FINISH, (actuator) =>
            {
                actuator.FollowButton().Click();
            });
        }

        private void btnAutoWork_Click(object sender, EventArgs e)
        {
            foreach (var va in GetSortCheckedRowDataList())
            {
                _client.CycleWork(va.ContainerCode, MainLoop);
            }
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            RunTrace(ActionTypes.PUSH_COMMENT, ActionTypes.PUSH_COMMENT_FINISH, (actuator) =>
            {
                actuator.PushCommentData("123456");
            });
        }

        #endregion

        /// <summary>
        /// 自动浏览主循环
        /// </summary>
        /// <param name="actuator">执行器</param>
        /// <param name="isContinue">是否持续</param>
        /// <param name="ok">总计数</param>
        /// <param name="err">错误技术</param>
        private void MainLoop(TikTokActuator actuator, ref bool isContinue, ref int ok, ref int err)
        {
            RowData row = _rowData[actuator.Id] as RowData;
            lock (row)
            {
                Thread.Sleep(500);
                string bloggerNickName = actuator.GetBloggerNickName();
                string bar = actuator.GetPlayBarData();
                UploadVideoProgress(actuator.Id, bar);


                VideoData video = null;
                bool isUploadBollger = false;

                // 20分钟重新进入页面
                if (ok >= 1200)
                {
                    LoggerHelper.ContainerLog(row.ContainerName, "重新进入tk主页");
                    Trace(actuator.Id, ActionTypes.JUMP_WEBSITE);
                    actuator.JumpWebsite();
                    ok = 0;
                }

                // 数据行与实际观看视频不符合
                if (string.IsNullOrWhiteSpace(row.BloggerName) || !row.BloggerName.Equals(bloggerNickName))
                {
                    LoggerHelper.ContainerLog(row.ContainerName, $"显示{row.BloggerName} 当前{bloggerNickName}");
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
                            LoggerHelper.ContainerLog(row.ContainerName, "进度大于30%，下一个视频");
                            Trace(actuator.Id, ActionTypes.NEXT_VIDEO);
                            actuator.NextVideo();
                            isUploadBollger = true;
                        }
                    }
                }

                if (isUploadBollger)
                {
                    LoggerHelper.ContainerLog(row.ContainerName, "更新视频数据");
                    video = actuator.GetVideoData();
                    LoggerHelper.ContainerLog(row.ContainerName, video.BloggerNickName);
                    Trace(actuator.Id, ActionTypes.UPDATE_BLOGGER_DATA);
                    UploadBloggerData(actuator.Id, video);
                }

                if (video != null)
                {
                    //TagData[] tagDatas = new TagUtil().Identify(videoData.TitleTags);
                    Tag[] tagDatas = TikTokBrowse.Models.Tag.Converts(video.TitleTags);
                    string tag = "";
                    foreach (var data in tagDatas)
                    {
                        tag += data.ToString() + " ";
                    }
                    LoggerHelper.ContainerLog(row.ContainerName, $"更新tag,{tag}");
                    row.Tag = tag;
                }
            }
        }


        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            if (InitApp())
            {
                // 自动执行
                if (await SwitchConnectorAsync())
                {
                    await RefreshGroupInfoAsync();
                    await RefreshGridDataByGroupNameAsync(this.cbGroup.Text);
                    SwitchGird("主页");
                    string[] category = new VideoHelper().GetTitleCategory();
                    this.cbTitleCategory.DataSource = category;
                }
            }
            else
            {
                MessageBox.Show("配置文件读取错误，请选择正确配置文件路径，重新打开应用", null, MessageBoxButtons.OKCancel);
                Application.Exit();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tab = sender as TabControl;
            string text = tab.SelectedTab.Text;
            if (!text.Equals(_oldTagTitle))
            {
                SwitchGird(text);
                _oldTagTitle = text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var va in GetSortCheckedRowDataList())
            {
                _client.SingleWorks(va.ContainerCode, UploadVideo);
            }


            RunTrace(ActionTypes.JUMP_WEBSITE, ActionTypes.JUMP_WEBSITE_FINISH, (actuator) =>
            {
                string dir = "";
                lock (_client)
                {
                    dir = _client.GetContainerDirectory(actuator.Id);
                }
            
                dir = Path.Combine(dir, "20230304 (1).mp4");
                //actuator.UploadForm().SendKeys(dir);
                //actuator.UploadForm().Submit();
            
            });
        }

        private void UploadVideo(TikTokActuator actuator)
        {
            string videoFileName = "";
            string dir;
            lock (_client)
            {
                dir = _client.GetContainerDirectory(actuator.Id);
            }

            string[] fileNames = new VideoHelper().GetDailyVideoFileName(dir);
            if (fileNames == null || fileNames.Length <= 0)
            {
                Trace(actuator.Id, ActionTypes.UPLOAD_VIDEO_NOT_EXIST);
                return;
            }
            videoFileName = fileNames.First();

            Trace(actuator.Id, ActionTypes.UPLOAD_VIDEO);
            Trace(actuator.Id, ActionTypes.JUMP_WEBSITE);
            actuator.JumpUploadSite();
            int i = 0;
            do
            {
                actuator.UploadButton()?.Click();
                IntPtr intPtr = actuator.FindUploadDialog();
                if (intPtr != null)
                {
                    actuator.UploadFile(intPtr, videoFileName);
                }

                IWebElement webElement = actuator.UploadButton();
                IWebElement webElement1 = actuator.PreviewPlayer();
                IWebElement webElement2 = actuator.CanelButton();
                IWebElement webElement3 = actuator.PostButton();
                string v = actuator.GetVideoTitle();

            } while (++i < 10);


        }
    }
}
