
namespace TikTokBrowse
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gird = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnComment = new System.Windows.Forms.Button();
            this.panFunc = new System.Windows.Forms.Panel();
            this.btnAutoWork = new System.Windows.Forms.Button();
            this.btnOpenScreen = new System.Windows.Forms.Button();
            this.btnFollower = new System.Windows.Forms.Button();
            this.btnGetBloggerData = new System.Windows.Forms.Button();
            this.btnLike = new System.Windows.Forms.Button();
            this.btnGetVideoBar = new System.Windows.Forms.Button();
            this.btnCloseScreen = new System.Windows.Forms.Button();
            this.btnPreviousVideo = new System.Windows.Forms.Button();
            this.btnNextVedio = new System.Windows.Forms.Button();
            this.btnChangeGroup = new System.Windows.Forms.Button();
            this.btnResizeWeb = new System.Windows.Forms.Button();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.btnTestProxy = new System.Windows.Forms.Button();
            this.btnOpenWeb = new System.Windows.Forms.Button();
            this.btnJump = new System.Windows.Forms.Button();
            this.btnCloseWeb = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbTitleCategory = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbWait = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.选择 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.环境ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.环境名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.代理状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.窗口 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.环境状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.进度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.博主 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.粉丝数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIKE数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.评论数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.标签 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.行为 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发表评论 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.视频路径 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.上传进度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.视频标题 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gird)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panFunc.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gird);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(1324, 579);
            this.panel1.TabIndex = 16;
            // 
            // gird
            // 
            this.gird.AllowUserToAddRows = false;
            this.gird.AllowUserToDeleteRows = false;
            this.gird.AllowUserToResizeRows = false;
            this.gird.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gird.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gird.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gird.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gird.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.选择,
            this.序号,
            this.环境ID,
            this.环境名称,
            this.代理状态,
            this.窗口,
            this.环境状态,
            this.进度,
            this.博主,
            this.粉丝数,
            this.LIKE数,
            this.评论数,
            this.标签,
            this.行为,
            this.发表评论,
            this.视频路径,
            this.上传进度,
            this.视频标题});
            this.gird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gird.GridColor = System.Drawing.SystemColors.Control;
            this.gird.Location = new System.Drawing.Point(2, 2);
            this.gird.Name = "gird";
            this.gird.ReadOnly = true;
            this.gird.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            this.gird.RowTemplate.Height = 20;
            this.gird.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gird.Size = new System.Drawing.Size(1320, 347);
            this.gird.TabIndex = 10;
            this.gird.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gird_RowPostPaint);
            this.gird.MouseLeave += new System.EventHandler(this.gird_MouseLeave);
            this.gird.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gird_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtLog);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 349);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(1320, 206);
            this.panel2.TabIndex = 11;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(433, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(887, 206);
            this.txtLog.TabIndex = 9;
            this.txtLog.Text = "123456789";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(429, 206);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.Tag = "";
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnComment);
            this.tabPage1.Controls.Add(this.panFunc);
            this.tabPage1.Controls.Add(this.btnChangeGroup);
            this.tabPage1.Controls.Add(this.btnResizeWeb);
            this.tabPage1.Controls.Add(this.cbGroup);
            this.tabPage1.Controls.Add(this.btnTestProxy);
            this.tabPage1.Controls.Add(this.btnOpenWeb);
            this.tabPage1.Controls.Add(this.btnJump);
            this.tabPage1.Controls.Add(this.btnCloseWeb);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(421, 180);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnComment
            // 
            this.btnComment.Location = new System.Drawing.Point(7, 151);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(234, 23);
            this.btnComment.TabIndex = 3;
            this.btnComment.Text = "评论";
            this.btnComment.UseVisualStyleBackColor = true;
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // panFunc
            // 
            this.panFunc.Controls.Add(this.btnAutoWork);
            this.panFunc.Controls.Add(this.btnOpenScreen);
            this.panFunc.Controls.Add(this.btnFollower);
            this.panFunc.Controls.Add(this.btnGetBloggerData);
            this.panFunc.Controls.Add(this.btnLike);
            this.panFunc.Controls.Add(this.btnGetVideoBar);
            this.panFunc.Controls.Add(this.btnCloseScreen);
            this.panFunc.Controls.Add(this.btnPreviousVideo);
            this.panFunc.Controls.Add(this.btnNextVedio);
            this.panFunc.Location = new System.Drawing.Point(256, 3);
            this.panFunc.Name = "panFunc";
            this.panFunc.Size = new System.Drawing.Size(162, 175);
            this.panFunc.TabIndex = 0;
            // 
            // btnAutoWork
            // 
            this.btnAutoWork.Location = new System.Drawing.Point(3, 148);
            this.btnAutoWork.Name = "btnAutoWork";
            this.btnAutoWork.Size = new System.Drawing.Size(156, 23);
            this.btnAutoWork.TabIndex = 4;
            this.btnAutoWork.Text = "自动运行";
            this.btnAutoWork.UseVisualStyleBackColor = true;
            this.btnAutoWork.Click += new System.EventHandler(this.btnAutoWork_Click);
            // 
            // btnOpenScreen
            // 
            this.btnOpenScreen.Location = new System.Drawing.Point(3, 3);
            this.btnOpenScreen.Name = "btnOpenScreen";
            this.btnOpenScreen.Size = new System.Drawing.Size(75, 23);
            this.btnOpenScreen.TabIndex = 2;
            this.btnOpenScreen.Text = "打开大屏";
            this.btnOpenScreen.UseVisualStyleBackColor = true;
            this.btnOpenScreen.Click += new System.EventHandler(this.btnOpenScreen_Click);
            // 
            // btnFollower
            // 
            this.btnFollower.Location = new System.Drawing.Point(84, 119);
            this.btnFollower.Name = "btnFollower";
            this.btnFollower.Size = new System.Drawing.Size(75, 23);
            this.btnFollower.TabIndex = 3;
            this.btnFollower.Text = "关注";
            this.btnFollower.UseVisualStyleBackColor = true;
            this.btnFollower.Click += new System.EventHandler(this.btnFollower_Click);
            // 
            // btnGetBloggerData
            // 
            this.btnGetBloggerData.Location = new System.Drawing.Point(3, 61);
            this.btnGetBloggerData.Name = "btnGetBloggerData";
            this.btnGetBloggerData.Size = new System.Drawing.Size(156, 23);
            this.btnGetBloggerData.TabIndex = 2;
            this.btnGetBloggerData.Text = "获取视频数据";
            this.btnGetBloggerData.UseVisualStyleBackColor = true;
            this.btnGetBloggerData.Click += new System.EventHandler(this.btnGetBloggerData_Click);
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(3, 119);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(75, 23);
            this.btnLike.TabIndex = 3;
            this.btnLike.Text = "点赞";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnGetVideoBar
            // 
            this.btnGetVideoBar.Location = new System.Drawing.Point(3, 90);
            this.btnGetVideoBar.Name = "btnGetVideoBar";
            this.btnGetVideoBar.Size = new System.Drawing.Size(156, 23);
            this.btnGetVideoBar.TabIndex = 2;
            this.btnGetVideoBar.Text = "获取视频进度";
            this.btnGetVideoBar.UseVisualStyleBackColor = true;
            this.btnGetVideoBar.Click += new System.EventHandler(this.btnGetVideoBar_Click);
            // 
            // btnCloseScreen
            // 
            this.btnCloseScreen.Location = new System.Drawing.Point(84, 3);
            this.btnCloseScreen.Name = "btnCloseScreen";
            this.btnCloseScreen.Size = new System.Drawing.Size(75, 23);
            this.btnCloseScreen.TabIndex = 2;
            this.btnCloseScreen.Text = "关闭大屏";
            this.btnCloseScreen.UseVisualStyleBackColor = true;
            this.btnCloseScreen.Click += new System.EventHandler(this.btnCloseScreen_Click);
            // 
            // btnPreviousVideo
            // 
            this.btnPreviousVideo.Location = new System.Drawing.Point(84, 32);
            this.btnPreviousVideo.Name = "btnPreviousVideo";
            this.btnPreviousVideo.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousVideo.TabIndex = 2;
            this.btnPreviousVideo.Text = "上一个视频";
            this.btnPreviousVideo.UseVisualStyleBackColor = true;
            this.btnPreviousVideo.Click += new System.EventHandler(this.btnPreviousVideo_Click);
            // 
            // btnNextVedio
            // 
            this.btnNextVedio.Location = new System.Drawing.Point(3, 32);
            this.btnNextVedio.Name = "btnNextVedio";
            this.btnNextVedio.Size = new System.Drawing.Size(75, 23);
            this.btnNextVedio.TabIndex = 2;
            this.btnNextVedio.Text = "下一个视频";
            this.btnNextVedio.UseVisualStyleBackColor = true;
            this.btnNextVedio.Click += new System.EventHandler(this.btnNextVedio_Click);
            // 
            // btnChangeGroup
            // 
            this.btnChangeGroup.Location = new System.Drawing.Point(7, 8);
            this.btnChangeGroup.Name = "btnChangeGroup";
            this.btnChangeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnChangeGroup.TabIndex = 0;
            this.btnChangeGroup.Text = "获取环境";
            this.btnChangeGroup.UseVisualStyleBackColor = true;
            this.btnChangeGroup.Click += new System.EventHandler(this.btnChangeGroup_Click);
            // 
            // btnResizeWeb
            // 
            this.btnResizeWeb.Location = new System.Drawing.Point(85, 66);
            this.btnResizeWeb.Name = "btnResizeWeb";
            this.btnResizeWeb.Size = new System.Drawing.Size(156, 23);
            this.btnResizeWeb.TabIndex = 2;
            this.btnResizeWeb.Text = "重置窗口大小";
            this.btnResizeWeb.UseVisualStyleBackColor = true;
            this.btnResizeWeb.Click += new System.EventHandler(this.btnResizeWeb_Click);
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(85, 10);
            this.cbGroup.Margin = new System.Windows.Forms.Padding(0, 4, 3, 3);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(156, 20);
            this.cbGroup.TabIndex = 1;
            // 
            // btnTestProxy
            // 
            this.btnTestProxy.Location = new System.Drawing.Point(7, 66);
            this.btnTestProxy.Name = "btnTestProxy";
            this.btnTestProxy.Size = new System.Drawing.Size(75, 23);
            this.btnTestProxy.TabIndex = 2;
            this.btnTestProxy.Text = "测试代理";
            this.btnTestProxy.UseVisualStyleBackColor = true;
            this.btnTestProxy.Click += new System.EventHandler(this.btnTestProxy_Click);
            // 
            // btnOpenWeb
            // 
            this.btnOpenWeb.Location = new System.Drawing.Point(7, 37);
            this.btnOpenWeb.Name = "btnOpenWeb";
            this.btnOpenWeb.Size = new System.Drawing.Size(75, 23);
            this.btnOpenWeb.TabIndex = 2;
            this.btnOpenWeb.Text = "打开环境";
            this.btnOpenWeb.UseVisualStyleBackColor = true;
            this.btnOpenWeb.Click += new System.EventHandler(this.btnOpenWeb_Click);
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(166, 37);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(75, 23);
            this.btnJump.TabIndex = 2;
            this.btnJump.Text = "跳转Tiktok";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnCloseWeb
            // 
            this.btnCloseWeb.Location = new System.Drawing.Point(85, 37);
            this.btnCloseWeb.Name = "btnCloseWeb";
            this.btnCloseWeb.Size = new System.Drawing.Size(75, 23);
            this.btnCloseWeb.TabIndex = 2;
            this.btnCloseWeb.Text = "关闭环境";
            this.btnCloseWeb.UseVisualStyleBackColor = true;
            this.btnCloseWeb.Click += new System.EventHandler(this.btnCloseWeb_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbTitleCategory);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(421, 180);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "视频上传";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbTitleCategory
            // 
            this.cbTitleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTitleCategory.FormattingEnabled = true;
            this.cbTitleCategory.Location = new System.Drawing.Point(65, 8);
            this.cbTitleCategory.Name = "cbTitleCategory";
            this.cbTitleCategory.Size = new System.Drawing.Size(180, 20);
            this.cbTitleCategory.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(170, 151);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "上传";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "标题类别";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(89, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "填充标题";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "跳转上传页";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(269, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 92);
            this.panel3.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(695, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 162);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbWait,
            this.lbLog});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(2, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1320, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbWait
            // 
            this.lbWait.Image = global::TikTokBrowse.Properties.Resources.load_30_128;
            this.lbWait.Name = "lbWait";
            this.lbWait.Size = new System.Drawing.Size(16, 16);
            this.lbWait.Visible = false;
            // 
            // lbLog
            // 
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(68, 17);
            this.lbLog.Text = "正常使用中";
            // 
            // 选择
            // 
            this.选择.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.选择.DataPropertyName = "IsChoose";
            this.选择.FalseValue = "false";
            this.选择.Frozen = true;
            this.选择.HeaderText = "#";
            this.选择.Name = "选择";
            this.选择.ReadOnly = true;
            this.选择.TrueValue = "true";
            this.选择.Width = 20;
            // 
            // 序号
            // 
            this.序号.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.序号.DataPropertyName = "Index";
            this.序号.Frozen = true;
            this.序号.HeaderText = "#";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 20;
            // 
            // 环境ID
            // 
            this.环境ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.环境ID.DataPropertyName = "ContainerCode";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.环境ID.DefaultCellStyle = dataGridViewCellStyle4;
            this.环境ID.FillWeight = 104.8951F;
            this.环境ID.Frozen = true;
            this.环境ID.HeaderText = "环境ID";
            this.环境ID.Name = "环境ID";
            this.环境ID.ReadOnly = true;
            this.环境ID.Width = 80;
            // 
            // 环境名称
            // 
            this.环境名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.环境名称.DataPropertyName = "ContainerName";
            this.环境名称.FillWeight = 95.1049F;
            this.环境名称.Frozen = true;
            this.环境名称.HeaderText = "环境名称";
            this.环境名称.Name = "环境名称";
            this.环境名称.ReadOnly = true;
            this.环境名称.Width = 160;
            // 
            // 代理状态
            // 
            this.代理状态.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.代理状态.DataPropertyName = "ProxyStatus";
            this.代理状态.Frozen = true;
            this.代理状态.HeaderText = "代理状态";
            this.代理状态.Name = "代理状态";
            this.代理状态.ReadOnly = true;
            this.代理状态.Width = 80;
            // 
            // 窗口
            // 
            this.窗口.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.窗口.DataPropertyName = "ContainerPosition";
            this.窗口.Frozen = true;
            this.窗口.HeaderText = "窗口";
            this.窗口.Name = "窗口";
            this.窗口.ReadOnly = true;
            this.窗口.Width = 70;
            // 
            // 环境状态
            // 
            this.环境状态.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.环境状态.DataPropertyName = "ContainerStatus";
            this.环境状态.Frozen = true;
            this.环境状态.HeaderText = "环境状态";
            this.环境状态.Name = "环境状态";
            this.环境状态.ReadOnly = true;
            this.环境状态.Width = 150;
            // 
            // 进度
            // 
            this.进度.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.进度.DataPropertyName = "VideoProgress";
            this.进度.HeaderText = "进度";
            this.进度.Name = "进度";
            this.进度.ReadOnly = true;
            this.进度.Width = 70;
            // 
            // 博主
            // 
            this.博主.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.博主.DataPropertyName = "BloggerName";
            this.博主.HeaderText = "博主";
            this.博主.Name = "博主";
            this.博主.ReadOnly = true;
            this.博主.Width = 70;
            // 
            // 粉丝数
            // 
            this.粉丝数.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.粉丝数.DataPropertyName = "FollowerNumber";
            this.粉丝数.HeaderText = "粉丝数";
            this.粉丝数.Name = "粉丝数";
            this.粉丝数.ReadOnly = true;
            this.粉丝数.Width = 70;
            // 
            // LIKE数
            // 
            this.LIKE数.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LIKE数.DataPropertyName = "LikeNumber";
            this.LIKE数.HeaderText = "LIKE数";
            this.LIKE数.Name = "LIKE数";
            this.LIKE数.ReadOnly = true;
            this.LIKE数.Width = 70;
            // 
            // 评论数
            // 
            this.评论数.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.评论数.DataPropertyName = "CommentNumber";
            this.评论数.HeaderText = "评论数";
            this.评论数.Name = "评论数";
            this.评论数.ReadOnly = true;
            this.评论数.Width = 70;
            // 
            // 标签
            // 
            this.标签.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.标签.DataPropertyName = "Tag";
            this.标签.HeaderText = "标签";
            this.标签.Name = "标签";
            this.标签.ReadOnly = true;
            this.标签.Width = 150;
            // 
            // 行为
            // 
            this.行为.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.行为.DataPropertyName = "Behavior";
            this.行为.HeaderText = "行为";
            this.行为.Name = "行为";
            this.行为.ReadOnly = true;
            this.行为.Width = 150;
            // 
            // 发表评论
            // 
            this.发表评论.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.发表评论.HeaderText = "发表评论";
            this.发表评论.MinimumWidth = 100;
            this.发表评论.Name = "发表评论";
            this.发表评论.ReadOnly = true;
            // 
            // 视频路径
            // 
            this.视频路径.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.视频路径.DataPropertyName = "VideoFileName";
            this.视频路径.HeaderText = "视频路径";
            this.视频路径.Name = "视频路径";
            this.视频路径.ReadOnly = true;
            this.视频路径.Width = 200;
            // 
            // 上传进度
            // 
            this.上传进度.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.上传进度.DataPropertyName = "VideoUploadBar";
            this.上传进度.HeaderText = "上传进度";
            this.上传进度.Name = "上传进度";
            this.上传进度.ReadOnly = true;
            this.上传进度.Width = 80;
            // 
            // 视频标题
            // 
            this.视频标题.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.视频标题.DataPropertyName = "VideoTitle";
            this.视频标题.HeaderText = "视频标题";
            this.视频标题.Name = "视频标题";
            this.视频标题.ReadOnly = true;
            this.视频标题.Width = 200;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1324, 579);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gird)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panFunc.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gird;
        private System.Windows.Forms.Button btnChangeGroup;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbWait;
        private System.Windows.Forms.ToolStripStatusLabel lbLog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnOpenWeb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnNextVedio;
        private System.Windows.Forms.Button btnPreviousVideo;
        private System.Windows.Forms.Button btnGetVideoBar;
        private System.Windows.Forms.Button btnGetBloggerData;
        private System.Windows.Forms.Button btnCloseScreen;
        private System.Windows.Forms.Button btnOpenScreen;
        private System.Windows.Forms.Button btnResizeWeb;
        private System.Windows.Forms.Button btnTestProxy;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Button btnCloseWeb;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAutoWork;
        private System.Windows.Forms.Button btnFollower;
        private System.Windows.Forms.Panel panFunc;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbTitleCategory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 选择;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 环境ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 环境名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 代理状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 窗口;
        private System.Windows.Forms.DataGridViewTextBoxColumn 环境状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 进度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 博主;
        private System.Windows.Forms.DataGridViewTextBoxColumn 粉丝数;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIKE数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 评论数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 标签;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行为;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发表评论;
        private System.Windows.Forms.DataGridViewTextBoxColumn 视频路径;
        private System.Windows.Forms.DataGridViewTextBoxColumn 上传进度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 视频标题;
    }
}

