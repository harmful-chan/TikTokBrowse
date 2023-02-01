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

namespace TikTokBrowse
{
    public partial class MainForm : Form
    {
        private HubstudioClient _client = new HubstudioClient();
        private Dictionary<string, Hubstudio.Models.Container> _workContainer = new Dictionary<string, Hubstudio.Models.Container>();
        private Dictionary<string, Hubstudio.Models.Web> _workWeb = new Dictionary<string, Hubstudio.Models.Web>();
        private Dictionary<string, ChromeDriver> _workDriver = new Dictionary<string, ChromeDriver>();
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public bool  isWork(string containerId)
        {
            return _workContainer.ContainsKey(containerId) 
                && _workWeb.ContainsKey(containerId) 
                && _workDriver.ContainsKey(containerId);
        }

        private void Log(string msg,bool isWait = false)
        {
            this.lbWait.Visible = isWait;
            this.lbLog.Text = msg;

        }

        private void btnConnectPathSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"D:\Program Files\Hubstudio\2.19.0.1";
            openFileDialog.Title = "请选择连接器";
            openFileDialog.Filter = "所有文件(*.*)|*.*";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.lbConnectorFileName.Text = openFileDialog.FileName;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!_client.IsOpenConnector)
            {

                Log("正在打开连接器...",true);
                _client.OpenConnector(this.lbConnectorFileName.Text);
                this.btnConnect.Text = "关闭连接器";
                Log("打开连接器完成");
            }
            else
            {
                Log("正在关闭连接器...", true);
                _client.KillConnector();
                this.btnConnect.Text = "打开连接器";
                Log("关闭连接器完成");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            for (int i = 0; i < gird.Rows.Count; i++)
            {
                this.gird.Rows[i].HeaderCell.Value = $"{i + 1}";
            }
            this.gird.Refresh();
        }

        private async void btnGetGroup_Click(object sender, EventArgs e)
        {
            Log("正在获取分组列表...", true);
            this.btnGetGroup.Enabled = false;
            Hubstudio.Models.Group[] groups = await _client.GetGroupsAsync();
            this.cbGroup.Items.Clear();
            this.cbGroup.Items.AddRange(Array.ConvertAll(groups, g => g.TagName));
            this.cbGroup.SelectedIndex = 0;
            this.btnGetGroup.Enabled = true;
            Log("获取分组列表完成");
        }

        private DataGridViewRow CreateContainerRow(Hubstudio.Models.Container container)
        {
            DataGridViewTextBoxCell textboxcell1 = new DataGridViewTextBoxCell() { Value = container.ContainerCode };
            DataGridViewTextBoxCell textboxcell2 = new DataGridViewTextBoxCell() { Value = container.ContainerName };
            
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(textboxcell1);
            row.Cells.Add(textboxcell2);
            return row;
        }

        private async void btnChangeGroup_Click(object sender, EventArgs e)
        {
            Log("正在获取环境列表...", true);
            btnChangeGroup.Enabled = false;
            string group = this.cbGroup.Text;
            Hubstudio.Models.Group[] tagGroups = await _client.GetGroupsAsync();
            Hubstudio.Models.Group tagGroup = tagGroups.Where(p => p.TagName.Equals(group)).FirstOrDefault();
            Hubstudio.Models.Container[] containers = await _client.GetContainersAsync(tagGroup.TagName);

            gird.Rows.Clear();
            foreach (var item in containers)
            {
                gird.Rows.Add(CreateContainerRow(item));
            }
            btnChangeGroup.Enabled = true;
            Log("获取环境列表完成");
        }


        private async void 打开环境ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> containerIDs = new List<string>();


            for (int i = this.gird.SelectedRows.Count-1; i >= 0 ; i--)
            {
                DataGridViewRow row = this.gird.SelectedRows[i];
                string containerID = row.Cells[0].Value as string;
                string name = row.Cells[1].Value as string;
                Log($"正在打开环境，{name}，{containerID}...", true);

                if (!isWork(containerID))
                {
                    row.Cells[2].Value = "打开中...";
                    Hubstudio.Models.Web web = await _client.OpenWebAsync(containerID);
                    if (web.Code == Hubstudio.Models.WebStatusTypes.成功)
                    {
                        _workWeb.Add(containerID, web);
                        containerIDs.Add(containerID);

                        // 设置驱动
                        row.Cells[2].Value = "安装驱动中...";
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.BinaryLocation = web.Data.BrowserPath;
                        chromeOptions.DebuggerAddress = $"127.0.0.1:{web.Data.DebuggingPort}";
                        // 关闭黑窗
                        ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(web.Data.Webdriver));
                        chromeDriverService.HideCommandPromptWindow = true;
                        _workDriver.Add(containerID, new ChromeDriver(chromeDriverService, chromeOptions));
                        row.Cells[2].Value = "已打开";
                    }
                    else
                    {
                        row.Cells[2].Value = $"{web.Code}";
                    }
                }
                else
                {
                    row.Cells[2].Value = "已打开";
                }

                Log($"打开环境完成，{name}，{containerID}", false);
            }

            Hubstudio.Models.Container[] containers = await _client.GetContainerAsync(containerIDs.ToArray());
            if(containers != null)
            {
                foreach (var item in containers)
                {
                    _workContainer.Add(item.ContainerCode, item);
                }
            }
        }

        private void 登录指定网站ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = this.gird.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = this.gird.SelectedRows[i];
                string containerID = row.Cells[0].Value as string;
                string name = row.Cells[1].Value as string;

                if (isWork(containerID))
                {
                    Log($"正在打开指定网站，{name}，{containerID}...", true);
                    row.Cells[2].Value = "跳转中...";
                    Work(containerID);
                    row.Cells[2].Value = $"已跳转";
                    Log($"打开指定网站完成，{name}，{containerID}", false);
                }
            }
            //

            //var driver = new ChromeDriver();
            //
        }

        private void Work(string containerId)
        {
            ChromeDriver driver = _workDriver[containerId];
            driver.Manage().Window.Size = new Size(500, 768);
            driver.Manage().Window.Position = new Point(0, 0);
            driver.Navigate().GoToUrl("https://whoer.net/");
            new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                        .Until(drv => drv.FindElement(By.XPath("//*[@id=\"main\"]/section[1]/div/div/div/div[1]/div/strong")));
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl("https://www.tiktok.com/");
            new WebDriverWait(driver, TimeSpan.FromSeconds(3))
            .Until(drv => drv.FindElement(By.XPath("//*[@id=\"main\"]/section[1]/div/div/div/div[1]/div/strong")));
        }
        private async void 关闭环境ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            for (int i = this.gird.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = this.gird.SelectedRows[i];
                string containerID = row.Cells[0].Value as string;
                string name = row.Cells[1].Value as string;

                if (isWork(containerID))
                {
                    Log($"正在关闭环境，{name}，{containerID}...", true);
                    row.Cells[2].Value = "关闭中...";
                    int code = await _client.CloseWebAsync(containerID);
                    if (code == 0)
                    {
                        _workContainer.Remove(containerID);
                        _workWeb.Remove(containerID);
                        _workDriver.Remove(containerID);
                        row.Cells[2].Value = "已关闭";
                        Log($"打开环境完成，{name}，{containerID}", false);
                    }
                    else
                    {
                        row.Cells[2].Value = $"关闭失败";
                    }
 
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
