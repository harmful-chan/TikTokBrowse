
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开环境ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭环境ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.重置窗口大小 = new System.Windows.Forms.ToolStripMenuItem();
            this.大屏模式 = new System.Windows.Forms.ToolStripMenuItem();
            this.开启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.上一个视频toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下一个视频ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.获取视频数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取视频进度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.点赞ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.评论ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关注ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析视频权重ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跳转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtConfigFileName = new System.Windows.Forms.TextBox();
            this.btnConfigFilePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbWait = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.btnChangeGroup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gird = new System.Windows.Forms.DataGridView();
            this.发表评论 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.行为 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.标签 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.评论数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIKE数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.粉丝数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.博主 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.环境状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.进度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.窗口 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.gridMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gird)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开环境ToolStripMenuItem,
            this.关闭环境ToolStripMenuItem,
            this.toolStripSeparator1,
            this.重置窗口大小,
            this.大屏模式,
            this.toolStripSeparator3,
            this.上一个视频toolStripMenuItem,
            this.下一个视频ToolStripMenuItem,
            this.toolStripSeparator5,
            this.获取视频数据ToolStripMenuItem,
            this.获取视频进度ToolStripMenuItem,
            this.toolStripSeparator4,
            this.点赞ToolStripMenuItem,
            this.评论ToolStripMenuItem,
            this.关注ToolStripMenuItem,
            this.分析视频权重ToolStripMenuItem,
            this.跳转ToolStripMenuItem});
            this.gridMenuStrip.Name = "gridMenuStrip";
            this.gridMenuStrip.Size = new System.Drawing.Size(149, 314);
            // 
            // 打开环境ToolStripMenuItem
            // 
            this.打开环境ToolStripMenuItem.Name = "打开环境ToolStripMenuItem";
            this.打开环境ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打开环境ToolStripMenuItem.Text = "打开环境";
            this.打开环境ToolStripMenuItem.Click += new System.EventHandler(this.打开环境ToolStripMenuItem_Click);
            // 
            // 关闭环境ToolStripMenuItem
            // 
            this.关闭环境ToolStripMenuItem.Name = "关闭环境ToolStripMenuItem";
            this.关闭环境ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.关闭环境ToolStripMenuItem.Text = "关闭环境";
            this.关闭环境ToolStripMenuItem.Click += new System.EventHandler(this.关闭环境ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // 重置窗口大小
            // 
            this.重置窗口大小.Name = "重置窗口大小";
            this.重置窗口大小.Size = new System.Drawing.Size(148, 22);
            this.重置窗口大小.Text = "重置窗口大小";
            this.重置窗口大小.Click += new System.EventHandler(this.重置窗口大小_Click);
            // 
            // 大屏模式
            // 
            this.大屏模式.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.大屏模式.Name = "大屏模式";
            this.大屏模式.Size = new System.Drawing.Size(148, 22);
            this.大屏模式.Text = "大屏模式";
            // 
            // 开启ToolStripMenuItem
            // 
            this.开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            this.开启ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.开启ToolStripMenuItem.Text = "开启";
            this.开启ToolStripMenuItem.Click += new System.EventHandler(this.开启ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // 上一个视频toolStripMenuItem
            // 
            this.上一个视频toolStripMenuItem.Name = "上一个视频toolStripMenuItem";
            this.上一个视频toolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.上一个视频toolStripMenuItem.Text = "上一个视频";
            this.上一个视频toolStripMenuItem.Click += new System.EventHandler(this.上一个视频toolStripMenuItem_Click);
            // 
            // 下一个视频ToolStripMenuItem
            // 
            this.下一个视频ToolStripMenuItem.Name = "下一个视频ToolStripMenuItem";
            this.下一个视频ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.下一个视频ToolStripMenuItem.Text = "下一个视频";
            this.下一个视频ToolStripMenuItem.Click += new System.EventHandler(this.下一个视频ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // 获取视频数据ToolStripMenuItem
            // 
            this.获取视频数据ToolStripMenuItem.Name = "获取视频数据ToolStripMenuItem";
            this.获取视频数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.获取视频数据ToolStripMenuItem.Text = "获取视频数据";
            this.获取视频数据ToolStripMenuItem.Click += new System.EventHandler(this.获取视频数据ToolStripMenuItem_Click);
            // 
            // 获取视频进度ToolStripMenuItem
            // 
            this.获取视频进度ToolStripMenuItem.Name = "获取视频进度ToolStripMenuItem";
            this.获取视频进度ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.获取视频进度ToolStripMenuItem.Text = "获取视频进度";
            this.获取视频进度ToolStripMenuItem.Click += new System.EventHandler(this.获取视频进度ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // 点赞ToolStripMenuItem
            // 
            this.点赞ToolStripMenuItem.Name = "点赞ToolStripMenuItem";
            this.点赞ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.点赞ToolStripMenuItem.Text = "点赞";
            this.点赞ToolStripMenuItem.Click += new System.EventHandler(this.点赞ToolStripMenuItem_Click);
            // 
            // 评论ToolStripMenuItem
            // 
            this.评论ToolStripMenuItem.Name = "评论ToolStripMenuItem";
            this.评论ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.评论ToolStripMenuItem.Text = "评论";
            this.评论ToolStripMenuItem.Click += new System.EventHandler(this.评论ToolStripMenuItem_Click);
            // 
            // 关注ToolStripMenuItem
            // 
            this.关注ToolStripMenuItem.Name = "关注ToolStripMenuItem";
            this.关注ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.关注ToolStripMenuItem.Text = "关注";
            this.关注ToolStripMenuItem.Click += new System.EventHandler(this.关注ToolStripMenuItem_Click_1);
            // 
            // 分析视频权重ToolStripMenuItem
            // 
            this.分析视频权重ToolStripMenuItem.Name = "分析视频权重ToolStripMenuItem";
            this.分析视频权重ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.分析视频权重ToolStripMenuItem.Text = "分析视频权重";
            this.分析视频权重ToolStripMenuItem.Click += new System.EventHandler(this.分析视频权重ToolStripMenuItem_Click);
            // 
            // 跳转ToolStripMenuItem
            // 
            this.跳转ToolStripMenuItem.Name = "跳转ToolStripMenuItem";
            this.跳转ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.跳转ToolStripMenuItem.Text = "跳转";
            this.跳转ToolStripMenuItem.Click += new System.EventHandler(this.跳转ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(1122, 426);
            this.panel1.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnConfigFilePath);
            this.tabPage2.Controls.Add(this.txtConfigFileName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1110, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtConfigFileName
            // 
            this.txtConfigFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConfigFileName.Location = new System.Drawing.Point(89, 11);
            this.txtConfigFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtConfigFileName.Name = "txtConfigFileName";
            this.txtConfigFileName.ReadOnly = true;
            this.txtConfigFileName.Size = new System.Drawing.Size(397, 21);
            this.txtConfigFileName.TabIndex = 5;
            this.txtConfigFileName.Text = "D:\\Desktop\\config.json";
            // 
            // btnConfigFilePath
            // 
            this.btnConfigFilePath.Location = new System.Drawing.Point(491, 10);
            this.btnConfigFilePath.Name = "btnConfigFilePath";
            this.btnConfigFilePath.Size = new System.Drawing.Size(35, 23);
            this.btnConfigFilePath.TabIndex = 6;
            this.btnConfigFilePath.Text = "...";
            this.btnConfigFilePath.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "配置文件路径";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1110, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbWait,
            this.lbLog});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(3, 371);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1104, 22);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnChangeGroup);
            this.flowLayoutPanel1.Controls.Add(this.cbGroup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1104, 29);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(81, 4);
            this.cbGroup.Margin = new System.Windows.Forms.Padding(0, 4, 3, 3);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(159, 20);
            this.cbGroup.TabIndex = 1;
            // 
            // btnChangeGroup
            // 
            this.btnChangeGroup.Location = new System.Drawing.Point(3, 3);
            this.btnChangeGroup.Name = "btnChangeGroup";
            this.btnChangeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnChangeGroup.TabIndex = 0;
            this.btnChangeGroup.Text = "获取环境";
            this.btnChangeGroup.UseVisualStyleBackColor = true;
            this.btnChangeGroup.Click += new System.EventHandler(this.btnChangeGroup_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gird);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(1104, 339);
            this.panel2.TabIndex = 11;
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
            this.序号,
            this.Column2,
            this.Column3,
            this.窗口,
            this.进度,
            this.环境状态,
            this.博主,
            this.粉丝数,
            this.LIKE数,
            this.评论数,
            this.标签,
            this.行为,
            this.发表评论});
            this.gird.ContextMenuStrip = this.gridMenuStrip;
            this.gird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gird.Location = new System.Drawing.Point(4, 0);
            this.gird.Name = "gird";
            this.gird.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            this.gird.RowTemplate.Height = 20;
            this.gird.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gird.Size = new System.Drawing.Size(1100, 339);
            this.gird.TabIndex = 10;
            this.gird.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gird_RowPostPaint);
            // 
            // 发表评论
            // 
            this.发表评论.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.发表评论.HeaderText = "发表评论";
            this.发表评论.MinimumWidth = 100;
            this.发表评论.Name = "发表评论";
            this.发表评论.ReadOnly = true;
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
            // 标签
            // 
            this.标签.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.标签.DataPropertyName = "Tag";
            this.标签.HeaderText = "标签";
            this.标签.Name = "标签";
            this.标签.ReadOnly = true;
            this.标签.Width = 150;
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
            // LIKE数
            // 
            this.LIKE数.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LIKE数.DataPropertyName = "LikeNumber";
            this.LIKE数.HeaderText = "LIKE数";
            this.LIKE数.Name = "LIKE数";
            this.LIKE数.ReadOnly = true;
            this.LIKE数.Width = 70;
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
            // 博主
            // 
            this.博主.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.博主.DataPropertyName = "BloggerName";
            this.博主.HeaderText = "博主";
            this.博主.Name = "博主";
            this.博主.ReadOnly = true;
            this.博主.Width = 70;
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
            this.进度.Frozen = true;
            this.进度.HeaderText = "进度";
            this.进度.Name = "进度";
            this.进度.ReadOnly = true;
            this.进度.Width = 70;
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
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "ContainerName";
            this.Column3.FillWeight = 95.1049F;
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "环境名称";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "ContainerCode";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.FillWeight = 104.8951F;
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "环境ID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // 序号
            // 
            this.序号.Frozen = true;
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 54;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1118, 422);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.Tag = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1122, 426);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.gridMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gird)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip gridMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 打开环境ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭环境ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 下一个视频ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取视频数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 获取视频进度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 点赞ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 评论ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关注ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重置窗口大小;
        private System.Windows.Forms.ToolStripMenuItem 大屏模式;
        private System.Windows.Forms.ToolStripMenuItem 开启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上一个视频toolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 分析视频权重ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 跳转ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gird;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 窗口;
        private System.Windows.Forms.DataGridViewTextBoxColumn 进度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 环境状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 博主;
        private System.Windows.Forms.DataGridViewTextBoxColumn 粉丝数;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIKE数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 评论数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 标签;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行为;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发表评论;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnChangeGroup;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbWait;
        private System.Windows.Forms.ToolStripStatusLabel lbLog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfigFilePath;
        private System.Windows.Forms.TextBox txtConfigFileName;
    }
}

