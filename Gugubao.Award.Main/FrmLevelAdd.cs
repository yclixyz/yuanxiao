using Gugubao.Award.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gugubao.Award.Main
{
    public partial class FrmLevelAdd : Form
    {
        public FrmLevelAdd()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TbName.Text.Trim()))
            {
                MessageBox.Show("奖品等级名称不能为空");
                return;
            }

            using AwardDbConetxt context = new AwardDbConetxt();

            if (context.AwardLevel.Any(c => c.Name == this.TbName.Text))
            {
                MessageBox.Show("已存在该奖品等级，请勿重复添加");
                return;
            }
            context.AwardLevel.Add(new AwardLevel
            {
                Name = this.TbName.Text,
            });

            context.SaveChanges();

            this.TbName.Text = "";

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
