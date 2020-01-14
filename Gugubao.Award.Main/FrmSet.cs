using Gugubao.Award.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gugubao.Award.Main
{
    public partial class FrmSet : Form
    {
        private readonly SerilogLogger _logger;
        private readonly AwardLevelEvent _awardLevelEventHandler;
        private readonly FrmMain _frmMain;
        private readonly IMemoryCache _cache;
        private readonly HttpClient _httpClient;
        private readonly HttpClientService httpClientService = new HttpClientService();

        public FrmSet(IMemoryCache cache, IHttpClientFactory httpClientFactory, FrmMain frmMain, AwardLevelEvent awardLevelEventHandler,SerilogLogger logger)
        {
            _awardLevelEventHandler = awardLevelEventHandler;
            _httpClient = httpClientFactory.CreateClient();
            _cache = cache;
            _frmMain = frmMain;
            _logger = logger;
            InitializeComponent();
            this.pagination1.PageIndexChanged += Pagination1_PageIndexChanged;
        }
        private void Pagination1_PageIndexChanged(object sender, TEventArgs<PageObject> e)
        {
            using AwardDbConetxt conetxt = new AwardDbConetxt();

            var pageObject = e.Data;

            var rowCount = conetxt.Account.Count();
            pageObject.RowCount = rowCount;
            pageObject.PageCount = Convert.ToInt32(Math.Ceiling((double)rowCount / pageObject.PageSize));

            e.Data = pageObject;
            var accounts = conetxt.Account
                .OrderByDescending(c => c.CreateTime)
                .Skip((pageObject.PageCurrent - 1) * pageObject.PageSize)
                .Take(pageObject.PageSize)
                .ToList();

            this.dataGridView1.DataSource = accounts;

            this.dataGridView1.Columns[nameof(Account.Group)].Visible = false;
            this.dataGridView1.Columns[nameof(Account.GroupId)].Visible = false;
            this.dataGridView1.Columns[nameof(Account.HeadImageUrl)].Visible = false;
            this.dataGridView1.Columns[nameof(Account.HeadImageLocalUrl)].Visible = false;
            this.dataGridView1.Columns[nameof(Account.HasPrized)].Visible = false;
            this.dataGridView1.Columns[nameof(Account.Id)].Visible = false;
            this.dataGridView1.Columns[nameof(Account.ModifyTime)].Visible = false;
            this.dataGridView1.Columns[nameof(Account.OpenId)].Visible = false;

            this.dataGridView1.Columns[nameof(Account.Name)].HeaderText = "姓名";
            this.dataGridView1.Columns[nameof(Account.Name)].DisplayIndex = 0;
            this.dataGridView1.Columns[nameof(Account.NickName)].HeaderText = "昵称";
            this.dataGridView1.Columns[nameof(Account.NickName)].DisplayIndex = 2;
            this.dataGridView1.Columns[nameof(Account.CellPhone)].HeaderText = "手机号";
            this.dataGridView1.Columns[nameof(Account.CellPhone)].DisplayIndex = 1;
            this.dataGridView1.Columns[nameof(Account.CreateTime)].HeaderText = "签到时间";
            this.dataGridView1.Columns[nameof(Account.CreateTime)].DisplayIndex = 3;

        }

        private void FrmSet_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnSyncAccount_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!CheckInitData())
            {
                MessageBox.Show("请完善抽奖的基本信息");
                return;
            }

            var screens = Screen.AllScreens;

            //若当前只有一块显示器
            if (Screen.AllScreens.Length < 2)
            {
                _frmMain.Location = new Point(screens[0].Bounds.Left, screens[0].Bounds.Top);
            }
            else
            {
                _frmMain.Location = new Point(screens[1].Bounds.Left, screens[1].Bounds.Top);
            }


            _frmMain.Show();
        }

        private void CBLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBLevel.SelectedItem is AwardLevel level)
            {
                if (CheckInitData())
                {
                    _awardLevelEventHandler.LevelNotifyExcute(sender, level);
                }
            }
        }

        private void 奖品设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItem frmItem = new FrmItem();

            if (DialogResult.OK == frmItem.ShowDialog())
            {
                LoadData();
            }
        }

        private void 奖品等级设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLevel frmLevel = new FrmLevel();

            if (DialogResult.OK == frmLevel.ShowDialog())
            {
                LoadData();
            }
        }

        private void 组设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGroup frmGroup = new FrmGroup();

            frmGroup.ShowDialog();
        }

        private void 联系我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmHelp().ShowDialog();
        }

        private void 中奖记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAwardRecord().ShowDialog();
        }

        private void LoadData()
        {
            httpClientService.LoadAccount(_cache, _httpClient,_logger);

            using (AwardDbConetxt dbConetxt = new AwardDbConetxt())
            {
                var levels = dbConetxt.AwardLevel.ToList();

                this.CBLevel.DataSource = levels;

                this.CBLevel.DisplayMember = "Name";

                this.CBLevel.ValueMember = "Id";
            }

            this.pagination1.Search();
        }

        private bool CheckInitData()
        {
            using AwardDbConetxt conetxt = new AwardDbConetxt();

            if (conetxt.Group.Count() == 0 || conetxt.AwardLevel.Count() == 0 || conetxt.AwardItem.Count() == 0 || conetxt.Account.Count() == 0)
            {
                return false;
            }

            var awardLevels = conetxt.AwardLevel.ToList();
            var awardItems = conetxt.AwardItem.ToList();

            // 如果设置了奖品等级没有设置对应的奖品，则不通过
            if (awardLevels.Count != awardItems.Count)
            {
                return false;
            }

            return true;
        }
    }
}
