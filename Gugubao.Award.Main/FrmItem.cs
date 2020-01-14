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
	public partial class FrmItem : Form
	{
		public FrmItem()
		{
			InitializeComponent();

			this.SetData();

			this.dataGridView1.Columns["Id"].Visible = false;
			this.dataGridView1.Columns["Name"].HeaderText = "名称";
			this.dataGridView1.Columns["LevelName"].HeaderText = "奖品等级";

			this.dataGridView1.Columns.Add(new DataGridViewButtonColumn
			{
				UseColumnTextForButtonValue = true,
				HeaderText = "编辑",
				Text = "编辑"
			});

			this.dataGridView1.Columns.Add(new DataGridViewButtonColumn
			{
				UseColumnTextForButtonValue = true,
				HeaderText = "删除",
				Text = "删除"
			});
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			this.DialogResult = DialogResult.OK;
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			FrmItemAdd frmLevelAdd = new FrmItemAdd();

			if (DialogResult.OK == frmLevelAdd.ShowDialog())
			{
				this.SetData();
			}
		}

		private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var rowIndex = e.RowIndex;

			if (rowIndex < 0) return;

			DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];

			if (!(column is DataGridViewButtonColumn)) return;

			var option = (column as DataGridViewButtonColumn).Text;

			var row = dataGridView1.Rows[rowIndex];

			var id = (long)row.Cells[dataGridView1.Columns["Id"].Index].Value;

			if (option == "编辑")
			{
				using AwardDbConetxt context = new AwardDbConetxt();

				var item = context.AwardItem.FirstOrDefault(x => x.Id == id);

				FrmItemEdit frmLevelEdit = new FrmItemEdit(item);

				if (DialogResult.OK == frmLevelEdit.ShowDialog())
				{
					this.SetData();
				}
			}
			else if (option == "删除")
			{
				using AwardDbConetxt context = new AwardDbConetxt();

				var item = context.AwardItem.FirstOrDefault(x => x.Id == id);

				context.AwardItem.Remove(item);

				context.SaveChanges();

				this.SetData();
			}
		}

		private void SetData()
		{
			using AwardDbConetxt context = new AwardDbConetxt();

			var items = context.AwardItem.OrderBy(x => x.LevelId).Select(x => new
			{
				x.Id,
				x.Name,
				LevelName = x.Level.Name
			}).ToList();

			this.dataGridView1.DataSource = items;
		}
	}
}
