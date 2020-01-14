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
	public partial class FrmItemAdd : Form
	{
		private string imageFilePath = null;

		public FrmItemAdd()
		{
			InitializeComponent();

			using AwardDbConetxt dbConetxt = new AwardDbConetxt();

			var existlevelIds = dbConetxt.AwardItem.Select(x => x.LevelId).ToList();

			var levels = dbConetxt.AwardLevel.Where(x => !existlevelIds.Contains(x.Id)).ToList();

			this.CbLevel.DisplayMember = "Name";

			this.CbLevel.ValueMember = "Id";

			this.CbLevel.DataSource = levels;

		}

		private void BtnConfirm_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TbName.Text))
			{
				MessageBox.Show("请填写奖品名称");

				return;
			}

			if (string.IsNullOrEmpty(imageFilePath))
			{
				MessageBox.Show("请上传奖品图片");

				return;
			}

			var fileName = Path.GetFileName(imageFilePath);

			var allFilesPath = Directory.GetFiles("images");

			for (int i = 0; i < allFilesPath.Length; i++)
			{
				if (Path.GetFileName(allFilesPath[i]) == fileName)
				{
					fileName = Guid.NewGuid().ToString() + fileName;
				}
			}

			using AwardDbConetxt dbConetxt = new AwardDbConetxt();

			var levelId = Convert.ToInt64(this.CbLevel.SelectedValue);

			if (dbConetxt.AwardItem.Any(c => c.Name == this.TbName.Text || c.LevelId == levelId))
			{
				MessageBox.Show("已存在该奖项，请勿重复添加");
				return;
			}

			dbConetxt.AwardItem.Add(new AwardItem
			{
				Name = this.TbName.Text,
				ImageUrl = Path.Combine("images", fileName),
				LevelId = levelId
			});

			dbConetxt.SaveChanges();

			File.Copy(imageFilePath, Path.Combine("images", fileName));

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
