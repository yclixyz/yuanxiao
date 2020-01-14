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
    public partial class FrmLevelEdit : Form
    {
        AwardLevel _awardLevel;
        public FrmLevelEdit(AwardLevel awardLevel)
        {
            _awardLevel = awardLevel;
            InitializeComponent();
            this.TbName.Text = _awardLevel.Name;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TbName.Text.Trim()))
            {
                MessageBox.Show("奖品等级名称不能为空");
                return;
            }

            using AwardDbConetxt context = new AwardDbConetxt();

            if (context.AwardLevel.Where(c => c.Id != _awardLevel.Id).Any(c => c.Name == this.TbName.Text))
            {
                MessageBox.Show("已存在该奖品等级，请勿重复添加");
                return;
            }

            var awardLvel = context.AwardItem.First(c => c.Id == _awardLevel.Id);

            awardLvel.Name = this.TbName.Text;

            context.Update(awardLvel);

            context.SaveChanges();

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
