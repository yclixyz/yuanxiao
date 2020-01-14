using System;

namespace Gugubao.Award.Main
{
    partial class FrmSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSet));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中奖记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.奖品设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.奖品等级设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.组设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSyncAccount = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CBLevel = new System.Windows.Forms.ComboBox();
            this.LBLevel = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.pagination1 = new Gugubao.Award.Main.Pagination();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看ToolStripMenuItem,
            this.开始ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中奖记录ToolStripMenuItem,
            this.toolStripMenuItem3});
            this.查看ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 中奖记录ToolStripMenuItem
            // 
            this.中奖记录ToolStripMenuItem.Name = "中奖记录ToolStripMenuItem";
            this.中奖记录ToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.中奖记录ToolStripMenuItem.Text = "中奖记录";
            this.中奖记录ToolStripMenuItem.Click += 中奖记录ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.奖品设置ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.奖品等级设置ToolStripMenuItem,
            this.toolStripSeparator2,
            this.组设置ToolStripMenuItem,
            this.toolStripSeparator1});
            this.开始ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.开始ToolStripMenuItem.Text = "编辑";
            // 
            // 奖品设置ToolStripMenuItem
            // 
            this.奖品设置ToolStripMenuItem.Name = "奖品设置ToolStripMenuItem";
            this.奖品设置ToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.奖品设置ToolStripMenuItem.Text = "奖品设置";
            this.奖品设置ToolStripMenuItem.Click += new System.EventHandler(this.奖品设置ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // 奖品等级设置ToolStripMenuItem
            // 
            this.奖品等级设置ToolStripMenuItem.Name = "奖品等级设置ToolStripMenuItem";
            this.奖品等级设置ToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.奖品等级设置ToolStripMenuItem.Text = "奖品等级设置";
            this.奖品等级设置ToolStripMenuItem.Click += new System.EventHandler(this.奖品等级设置ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // 组设置ToolStripMenuItem
            // 
            this.组设置ToolStripMenuItem.Name = "组设置ToolStripMenuItem";
            this.组设置ToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.组设置ToolStripMenuItem.Text = "组设置";
            this.组设置ToolStripMenuItem.Click += new System.EventHandler(this.组设置ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.联系我们ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.帮助ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.帮助ToolStripMenuItem.Text = "帮助";

            // 
            // 联系我们ToolStripMenuItem
            // 
            this.联系我们ToolStripMenuItem.Name = "联系我们ToolStripMenuItem";
            this.联系我们ToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.联系我们ToolStripMenuItem.Text = "联系我们";
            this.联系我们ToolStripMenuItem.Click += new System.EventHandler(this.联系我们ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSyncAccount);
            this.groupBox1.Controls.Add(this.pagination1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1005, 450);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参与用户";
            // 
            // BtnSyncAccount
            // 
            this.BtnSyncAccount.Location = new System.Drawing.Point(895, 25);
            this.BtnSyncAccount.Name = "BtnSyncAccount";
            this.BtnSyncAccount.Size = new System.Drawing.Size(95, 30);
            this.BtnSyncAccount.TabIndex = 2;
            this.BtnSyncAccount.Text = "刷新客户";
            this.BtnSyncAccount.UseVisualStyleBackColor = true;
            this.BtnSyncAccount.Click += new System.EventHandler(this.BtnSyncAccount_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(984, 323);
            this.dataGridView1.TabIndex = 0;
            // 
            // CBLevel
            // 
            this.CBLevel.Font = new System.Drawing.Font("宋体", 19F);
            this.CBLevel.FormattingEnabled = true;
            this.CBLevel.Location = new System.Drawing.Point(499, 518);
            this.CBLevel.Name = "CBLevel";
            this.CBLevel.Size = new System.Drawing.Size(202, 33);
            this.CBLevel.TabIndex = 4;
            this.CBLevel.SelectedIndexChanged += new System.EventHandler(this.CBLevel_SelectedIndexChanged);
            this.CBLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // LBLevel
            // 
            this.LBLevel.BackColor = System.Drawing.SystemColors.Control;
            this.LBLevel.Font = new System.Drawing.Font("宋体", 19F);
            this.LBLevel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LBLevel.Location = new System.Drawing.Point(319, 521);
            this.LBLevel.Name = "LBLevel";
            this.LBLevel.Size = new System.Drawing.Size(174, 34);
            this.LBLevel.TabIndex = 5;
            this.LBLevel.Text = "选择奖品等级";
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("宋体", 12F);
            this.BtnStart.Location = new System.Drawing.Point(736, 517);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(97, 34);
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "开始抽奖";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // pagination1
            // 
            this.pagination1.Location = new System.Drawing.Point(0, 400);
            this.pagination1.Margin = new System.Windows.Forms.Padding(5);
            this.pagination1.Name = "pagination1";
            this.pagination1.Size = new System.Drawing.Size(990, 36);
            this.pagination1.TabIndex = 1;
            // 
            // FrmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 606);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.LBLevel);
            this.Controls.Add(this.CBLevel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FrmSet_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 奖品设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 奖品等级设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 组设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系我们ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBLevel;
        private System.Windows.Forms.Label LBLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Pagination pagination1;
        private System.Windows.Forms.Button BtnSyncAccount;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中奖记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Button BtnStart;
    }
}