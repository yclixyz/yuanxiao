namespace Gugubao.Award.Main
{
    partial class FrmItemEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemAdd));
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbLevel = new System.Windows.Forms.Label();
            this.CbLevel = new System.Windows.Forms.ComboBox();
            this.LBImageUrl = new System.Windows.Forms.Label();
            this.PBImage = new System.Windows.Forms.PictureBox();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PBImage)).BeginInit();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(53, 32);
            this.LbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(56, 16);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "名称：";
            // 
            // TbName
            // 
            this.TbName.Font = new System.Drawing.Font("宋体", 12F);
            this.TbName.Location = new System.Drawing.Point(155, 32);
            this.TbName.Margin = new System.Windows.Forms.Padding(4);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(377, 26);
            this.TbName.TabIndex = 1;
            // 
            // LbLevel
            // 
            this.LbLevel.AutoSize = true;
            this.LbLevel.Location = new System.Drawing.Point(56, 93);
            this.LbLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbLevel.Name = "LbLevel";
            this.LbLevel.Size = new System.Drawing.Size(56, 16);
            this.LbLevel.TabIndex = 2;
            this.LbLevel.Text = "等级：";
            // 
            // CbLevel
            // 
            this.CbLevel.FormattingEnabled = true;
            this.CbLevel.Location = new System.Drawing.Point(155, 89);
            this.CbLevel.Margin = new System.Windows.Forms.Padding(4);
            this.CbLevel.Name = "CbLevel";
            this.CbLevel.Size = new System.Drawing.Size(377, 24);
            this.CbLevel.TabIndex = 3;
            this.CbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // LBImageUrl
            // 
            this.LBImageUrl.AutoSize = true;
            this.LBImageUrl.Location = new System.Drawing.Point(53, 145);
            this.LBImageUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBImageUrl.Name = "LBImageUrl";
            this.LBImageUrl.Size = new System.Drawing.Size(56, 16);
            this.LBImageUrl.TabIndex = 4;
            this.LBImageUrl.Text = "图片：";
            // 
            // PBImage
            // 
            this.PBImage.Image = ((System.Drawing.Image)(resources.GetObject("PBImage.Image")));
            this.PBImage.Location = new System.Drawing.Point(155, 145);
            this.PBImage.Margin = new System.Windows.Forms.Padding(4);
            this.PBImage.Name = "PBImage";
            this.PBImage.Size = new System.Drawing.Size(379, 376);
            this.PBImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBImage.TabIndex = 5;
            this.PBImage.TabStop = false;
            this.PBImage.Click += new System.EventHandler(this.PBImage_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(279, 544);
            this.BtnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(100, 31);
            this.BtnConfirm.TabIndex = 6;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmLevelAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 591);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.PBImage);
            this.Controls.Add(this.LBImageUrl);
            this.Controls.Add(this.CbLevel);
            this.Controls.Add(this.LbLevel);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItemEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "奖品修改";
            ((System.ComponentModel.ISupportInitialize)(this.PBImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbLevel;
        private System.Windows.Forms.ComboBox CbLevel;
        private System.Windows.Forms.Label LBImageUrl;
        private System.Windows.Forms.PictureBox PBImage;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}