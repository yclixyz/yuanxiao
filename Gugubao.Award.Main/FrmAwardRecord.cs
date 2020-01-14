using Gugubao.Award.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
    public partial class FrmAwardRecord : Form
    {
        private long levelId;

        public FrmAwardRecord()
        {
            InitializeComponent();
            this.pagination1.PageIndexChanged += Pagination1_PageIndexChanged;
        }

        private void FrmAwardRecord_Load(object sender, System.EventArgs e)
        {
            using AwardDbConetxt dbConetxt = new AwardDbConetxt();

            var levels = dbConetxt.AwardLevel.ToList();

            this.CbLevel.DisplayMember = "Name";

            this.CbLevel.ValueMember = "Id";

            this.CbLevel.DataSource = levels;

            this.pagination1.Search();
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.pagination1.Search();
        }

        private void Pagination1_PageIndexChanged(object sender, TEventArgs<PageObject> e)
        {
            using AwardDbConetxt conetxt = new AwardDbConetxt();

            var pageObject = e.Data;

            var accounts = conetxt.AwardRecord
                .Include(c => c.AwardItem)
                .Include(c => c.Account)
                .Where(c => c.AwardItem.LevelId == levelId)
                .OrderByDescending(c => c.CreateTime)
                .Skip((pageObject.PageCurrent - 1) * pageObject.PageSize)
                .Take(pageObject.PageSize)
                .ToList();

            var source = accounts.Select(c => new { c.Account.Name, c.Account.CellPhone, AwardItemName = c.AwardItem.Name }).ToList();

            var rowCount = source.Count;
            pageObject.RowCount = rowCount;
            pageObject.PageCount = Convert.ToInt32(Math.Ceiling((double)rowCount / pageObject.PageSize));

            this.dataGridView1.DataSource = source;

            this.dataGridView1.Columns[nameof(Account.Name)].HeaderText = "名称";
            this.dataGridView1.Columns[nameof(Account.CellPhone)].HeaderText = "手机号";
            this.dataGridView1.Columns["AwardItemName"].HeaderText = "奖品";

            e.Data = pageObject;
        }


        private void CbLevel_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            levelId = long.Parse(this.CbLevel.SelectedValue.ToString());
            this.pagination1.Search();
        }
    }
}
