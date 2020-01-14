namespace Gugubao.Award.Main
{
    partial class FrmAwardRecord
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
            this.CbLevel = new System.Windows.Forms.ComboBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pagination1 = new Gugubao.Award.Main.Pagination();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CbLevel
            // 
            this.CbLevel.FormattingEnabled = true;
            this.CbLevel.Location = new System.Drawing.Point(12, 31);
            this.CbLevel.Name = "CbLevel";
            this.CbLevel.Size = new System.Drawing.Size(121, 24);
            this.CbLevel.TabIndex = 0;
            this.CbLevel.SelectedIndexChanged += CbLevel_SelectedIndexChanged;
            this.CbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(182, 28);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 29);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(12, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(663, 290);
            this.dataGridView1.TabIndex = 2;
            // 
            // pagination1
            // 
            this.pagination1.Location = new System.Drawing.Point(12, 381);
            this.pagination1.Margin = new System.Windows.Forms.Padding(4);
            this.pagination1.Name = "pagination1";
            this.pagination1.Size = new System.Drawing.Size(662, 43);
            this.pagination1.TabIndex = 3;
            // 
            // FrmAwardRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 437);
            this.Controls.Add(this.pagination1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.CbLevel);
            this.Load += FrmAwardRecord_Load;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAwardRecord";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中奖记录";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ComboBox CbLevel;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Pagination pagination1;
    }
}