using Gugubao.Award.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gugubao.Award.Main
{
	public partial class FrmItemEdit : Form
	{
		private string imageFilePath = null;
		private readonly AwardItem _AwardItem;

		public FrmItemEdit(AwardItem awardItem)
		{
			_AwardItem = awardItem;

			InitializeComponent();

			using AwardDbConetxt dbConetxt = new AwardDbConetxt();

			this.TbName.Text = awardItem.Name;

			this.PBImage.Image = Image.FromFile(awardItem.ImageUrl);

			var existlevelIds = dbConetxt.AwardItem.Select(x => x.LevelId).ToList();

			existlevelIds.Remove(awardItem.LevelId);

			var levels = dbConetxt.AwardLevel.Where(x => !existlevelIds.Contains(x.Id)).ToList();

			this.CbLevel.DisplayMember = "Name";

			this.CbLevel.ValueMember = "Id";

			this.CbLevel.DataSource = levels;

			this.CbLevel.SelectedValue = awardItem.LevelId;
		}

		private void BtnConfirm_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TbName.Text))
			{
				MessageBox.Show("请填写奖品名称");
				this.TbName.Text = _AwardItem.Name;
				return;
			}

			using AwardDbConetxt context = new AwardDbConetxt();

			var levelId = Convert.ToInt64(this.CbLevel.SelectedValue);

			if (context.AwardItem.Where(c => c.Id != _AwardItem.Id).Any(c => c.Name == this.TbName.Text || c.LevelId == levelId))
			{
				MessageBox.Show("已存在该奖项，无法修改");

				this.TbName.Text = _AwardItem.Name;
				return;
			}

			var awardItem = context.AwardItem.First(c => c.Id == _AwardItem.Id);

			awardItem.Name = this.TbName.Text;

			awardItem.LevelId = levelId;

			if (!string.IsNullOrEmpty(imageFilePath) && Path.GetFullPath(imageFilePath) != Path.GetFullPath(_AwardItem.ImageUrl))
			{
				var fileName = Path.GetFileName(imageFilePath);

				var allFilesPath = Directory.GetFiles("images");

				for (int i = 0; i < allFilesPath.Length; i++)
				{
					if (Path.GetFileName(allFilesPath[i]) == fileName)
					{
						fileName = Guid.NewGuid().ToString() + fileName;
					}
				}

				awardItem.ImageUrl = Path.Combine("images", fileName);
			}
			context.Update(awardItem);

			context.SaveChanges();

			imageFilePath = null;

			this.DialogResult = DialogResult.OK;

			this.Close();
		}

		private void PBImage_Click(object sender, EventArgs e)
		{
			////文件类型过滤
			this.openFileDialog1.Filter = "图像文件(*.jpg,*.bmp,*.gif,*.png)|*.jpg;*.bmp;*.gif;*.png";
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//得到文件路径全名
				imageFilePath = openFileDialog1.FileName;

				this.PBImage.Image = Image.FromFile(imageFilePath);
			}
		}
	}
}
