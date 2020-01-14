namespace Gugubao.Award.Main
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelEnhanced1 = new PanelEnhanced();
            this.BtnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBAwardNo = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.PbLevel = new System.Windows.Forms.PictureBox();
            this.PbHeadUrl = new System.Windows.Forms.PictureBox();
            this.LbPhone = new System.Windows.Forms.Label();
            this.LbLevel = new System.Windows.Forms.Label();
            this.LbName = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHeadUrl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelEnhanced1.BackgroundImage")));
            this.panelEnhanced1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelEnhanced1.Controls.Add(this.BtnClose);
            this.panelEnhanced1.Controls.Add(this.panel1);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1664, 1024);
            this.panelEnhanced1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.panelEnhanced1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(5)))), ((int)(((byte)(8)))));
            this.BtnClose.Location = new System.Drawing.Point(1473, 79);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(135, 60);
            this.BtnClose.TabIndex = 22;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += BtnClose_Click;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.LBAwardNo);
            this.panel1.Controls.Add(this.BtnStart);
            this.panel1.Controls.Add(this.PbLevel);
            this.panel1.Controls.Add(this.PbHeadUrl);
            this.panel1.Controls.Add(this.LbPhone);
            this.panel1.Controls.Add(this.LbLevel);
            this.panel1.Controls.Add(this.LbName);
            this.panel1.Location = new System.Drawing.Point(865, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 564);
            this.panel1.TabIndex = 0;
            // 
            // LBAwardNo
            // 
            this.LBAwardNo.AutoSize = true;
            this.LBAwardNo.BackColor = System.Drawing.Color.Transparent;
            this.LBAwardNo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.LBAwardNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(81)))));
            this.LBAwardNo.Location = new System.Drawing.Point(709, 468);
            this.LBAwardNo.Name = "LBAwardNo";
            this.LBAwardNo.Size = new System.Drawing.Size(149, 31);
            this.LBAwardNo.TabIndex = 26;
            this.LBAwardNo.Text = "已抽取：0位";
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Transparent;
            this.BtnStart.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnStart.FlatAppearance.BorderSize = 0;
            this.BtnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStart.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.BtnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(5)))), ((int)(((byte)(8)))));
            this.BtnStart.Location = new System.Drawing.Point(104, 455);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(447, 106);
            this.BtnStart.TabIndex = 19;
            this.BtnStart.Text = "开始";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += BtnStart_Click;
            // 
            // PbLevel
            // 
            this.PbLevel.BackColor = System.Drawing.Color.Transparent;
            this.PbLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PbLevel.Location = new System.Drawing.Point(11, 10);
            this.PbLevel.Name = "PbLevel";
            this.PbLevel.Size = new System.Drawing.Size(249, 251);
            this.PbLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLevel.TabIndex = 20;
            this.PbLevel.TabStop = false;
            // 
            // PbHeadUrl
            // 
            this.PbHeadUrl.BackColor = System.Drawing.Color.Transparent;
            this.PbHeadUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbHeadUrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PbHeadUrl.Location = new System.Drawing.Point(392, 10);
            this.PbHeadUrl.Name = "PbHeadUrl";
            this.PbHeadUrl.Size = new System.Drawing.Size(249, 251);
            this.PbHeadUrl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbHeadUrl.TabIndex = 21;
            this.PbHeadUrl.TabStop = false;
            // 
            // LbPhone
            // 
            this.LbPhone.BackColor = System.Drawing.Color.Transparent;
            this.LbPhone.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.LbPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(81)))));
            this.LbPhone.Location = new System.Drawing.Point(395, 318);
            this.LbPhone.Name = "LbPhone";
            this.LbPhone.Size = new System.Drawing.Size(246, 31);
            this.LbPhone.TabIndex = 25;
            // 
            // LbLevel
            // 
            this.LbLevel.AutoSize = true;
            this.LbLevel.BackColor = System.Drawing.Color.Transparent;
            this.LbLevel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.LbLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(81)))));
            this.LbLevel.Location = new System.Drawing.Point(94, 279);
            this.LbLevel.Name = "LbLevel";
            this.LbLevel.Size = new System.Drawing.Size(86, 31);
            this.LbLevel.TabIndex = 23;
            this.LbLevel.Text = "特等奖";
            // 
            // LbName
            // 
            this.LbName.BackColor = System.Drawing.Color.Transparent;
            this.LbName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.LbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(81)))));
            this.LbName.Location = new System.Drawing.Point(396, 279);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(245, 31);
            this.LbName.TabIndex = 24;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 1024);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抽取一等奖";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelEnhanced1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHeadUrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LBAwardNo;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.PictureBox PbLevel;
        private System.Windows.Forms.PictureBox PbHeadUrl;
        private System.Windows.Forms.Label LbPhone;
        private System.Windows.Forms.Label LbLevel;
        private System.Windows.Forms.Label LbName;
    }
}

