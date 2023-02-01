
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
            this.btnConnectPathSelect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGetGroup = new System.Windows.Forms.Button();
            this.btnChangeGroup = new System.Windows.Forms.Button();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbWait = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.gird = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.环境状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开环境ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭环境ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.登录指定网站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbConnectorFileName = new System.Windows.Forms.TextBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gird)).BeginInit();
            this.gridMenuStrip.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnectPathSelect
            // 
            this.btnConnectPathSelect.Location = new System.Drawing.Point(3, 3);
            this.btnConnectPathSelect.Name = "btnConnectPathSelect";
            this.btnConnectPathSelect.Size = new System.Drawing.Size(33, 23);
            this.btnConnectPathSelect.TabIndex = 3;
            this.btnConnectPathSelect.Text = "...";
            this.btnConnectPathSelect.UseVisualStyleBackColor = true;
            this.btnConnectPathSelect.Click += new System.EventHandler(this.btnConnectPathSelect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(3, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(156, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "启动连接器";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnConnect);
            this.flowLayoutPanel1.Controls.Add(this.btnGetGroup);
            this.flowLayoutPanel1.Controls.Add(this.btnChangeGroup);
            this.flowLayoutPanel1.Controls.Add(this.cbGroup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(683, 29);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnGetGroup
            // 
            this.btnGetGroup.Location = new System.Drawing.Point(165, 3);
            this.btnGetGroup.Name = "btnGetGroup";
            this.btnGetGroup.Size = new System.Drawing.Size(100, 23);
            this.btnGetGroup.TabIndex = 6;
            this.btnGetGroup.Text = "获取分组";
            this.btnGetGroup.UseVisualStyleBackColor = true;
            this.btnGetGroup.Click += new System.EventHandler(this.btnGetGroup_Click);
            // 
            // btnChangeGroup
            // 
            this.btnChangeGroup.Location = new System.Drawing.Point(271, 3);
            this.btnChangeGroup.Name = "btnChangeGroup";
            this.btnChangeGroup.Size = new System.Drawing.Size(100, 23);
            this.btnChangeGroup.TabIndex = 0;
            this.btnChangeGroup.Text = "获取环境";
            this.btnChangeGroup.UseVisualStyleBackColor = true;
            this.btnChangeGroup.Click += new System.EventHandler(this.btnChangeGroup_Click);
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(374, 4);
            this.cbGroup.Margin = new System.Windows.Forms.Padding(0, 4, 3, 3);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(159, 20);
            this.cbGroup.TabIndex = 1;
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.cbGroup_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbWait,
            this.lbLog});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(683, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbWait
            // 
            this.lbWait.Name = "lbWait";
            this.lbWait.Size = new System.Drawing.Size(0, 0);
            this.lbWait.Visible = false;
            // 
            // lbLog
            // 
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(68, 17);
            this.lbLog.Text = "正常使用中";
            // 
            // gird
            // 
            this.gird.AllowUserToAddRows = false;
            this.gird.AllowUserToDeleteRows = false;
            this.gird.AllowUserToResizeColumns = false;
            this.gird.AllowUserToResizeRows = false;
            this.gird.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gird.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gird.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gird.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gird.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.环境状态,
            this.备注});
            this.gird.ContextMenuStrip = this.gridMenuStrip;
            this.gird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gird.Location = new System.Drawing.Point(4, 58);
            this.gird.Name = "gird";
            this.gird.RowTemplate.Height = 23;
            this.gird.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gird.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gird.Size = new System.Drawing.Size(675, 346);
            this.gird.TabIndex = 10;
            this.gird.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.gird.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.FillWeight = 104.8951F;
            this.Column2.HeaderText = "环境ID";
            this.Column2.Name = "Column2";
            this.Column2.Width = 66;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.FillWeight = 95.1049F;
            this.Column3.HeaderText = "环境名称";
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // 环境状态
            // 
            this.环境状态.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.环境状态.HeaderText = "环境状态";
            this.环境状态.Name = "环境状态";
            this.环境状态.Width = 78;
            // 
            // 备注
            // 
            this.备注.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开环境ToolStripMenuItem,
            this.关闭环境ToolStripMenuItem,
            this.toolStripSeparator1,
            this.登录指定网站ToolStripMenuItem});
            this.gridMenuStrip.Name = "gridMenuStrip";
            this.gridMenuStrip.Size = new System.Drawing.Size(149, 76);
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
            // 登录指定网站ToolStripMenuItem
            // 
            this.登录指定网站ToolStripMenuItem.Name = "登录指定网站ToolStripMenuItem";
            this.登录指定网站ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.登录指定网站ToolStripMenuItem.Text = "登录指定网站";
            this.登录指定网站ToolStripMenuItem.Click += new System.EventHandler(this.登录指定网站ToolStripMenuItem_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.btnConnectPathSelect);
            this.flowLayoutPanel3.Controls.Add(this.lbConnectorFileName);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(683, 29);
            this.flowLayoutPanel3.TabIndex = 12;
            // 
            // lbConnectorFileName
            // 
            this.lbConnectorFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbConnectorFileName.Location = new System.Drawing.Point(42, 4);
            this.lbConnectorFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.lbConnectorFileName.Name = "lbConnectorFileName";
            this.lbConnectorFileName.ReadOnly = true;
            this.lbConnectorFileName.Size = new System.Drawing.Size(366, 21);
            this.lbConnectorFileName.TabIndex = 4;
            this.lbConnectorFileName.Text = "D:\\Program Files\\Hubstudio\\2.19.0.1\\hubstudio_connector.exe";
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 58);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(4, 346);
            this.panelLeft.TabIndex = 13;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(679, 58);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(4, 346);
            this.panelRight.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 426);
            this.Controls.Add(this.gird);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "脚本";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gird)).EndInit();
            this.gridMenuStrip.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConnectPathSelect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView gird;
        private System.Windows.Forms.Button btnChangeGroup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TextBox lbConnectorFileName;
        private System.Windows.Forms.Button btnGetGroup;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.ToolStripStatusLabel lbLog;
        private System.Windows.Forms.ToolStripStatusLabel lbWait;
        private System.Windows.Forms.ContextMenuStrip gridMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 打开环境ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭环境ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 登录指定网站ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 环境状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
    }
}

