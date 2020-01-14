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
    public partial class FrmLevel : Form
    {
        public FrmLevel()
        {
            InitializeComponent();

            LoadData();

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

            this.dataGridView1.Columns[nameof(AwardLevel.Id)].Visible = false;
            this.dataGridView1.Columns[nameof(AwardLevel.Name)].HeaderText = "奖品等级";
            this.dataGridView1.Columns[nameof(AwardLevel.CreateTime)].HeaderText = "创建时间";
            this.dataGridView1.Columns[nameof(AwardLevel.CreateTime)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            this.DialogResult =DialogResult.OK;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new FrmLevelAdd().ShowDialog())
            {
                LoadData();
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

                var item = context.AwardLevel.FirstOrDefault(x => x.Id == id);

                FrmLevelEdit frmLevelEdit = new FrmLevelEdit(item);

                if (DialogResult.OK == frmLevelEdit.ShowDialog())
                {
                    this.LoadData();
                }
            }
            else if (option == "删除")
            {
                using AwardDbConetxt context = new AwardDbConetxt();

                var item = context.AwardLevel.FirstOrDefault(x => x.Id == id);

                context.AwardLevel.Remove(item);

                context.SaveChanges();

                this.LoadData();
            }
        }

        private void LoadData()
        {
            using AwardDbConetxt context = new AwardDbConetxt();

            var leves = context.AwardLevel.Select(c => new { c.Id, c.Name, CreateTime = c.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") }).ToList();

            this.dataGridView1.DataSource = leves;
        }
    }
}
