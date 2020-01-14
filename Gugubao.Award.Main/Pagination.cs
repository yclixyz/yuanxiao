using Gugubao.Award.Infrastructure;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gugubao.Award.Main
{
    public partial class Pagination : UserControl
    {
        private PageObject pageObject;

        [Browsable(false)]
        public PageObject PageObject
        {
            get
            {
                if (pageObject == null)
                {
                    pageObject = new PageObject();
                    this.pageObject.PageCurrent = 1;
                }

                return pageObject;
            }
        }

        public event EventHandler<TEventArgs<PageObject>> PageIndexChanged;

        public Pagination()
        {
            InitializeComponent();

            pageObject = new PageObject();
        }

        protected void OnPageIndexChanged(TEventArgs<PageObject> e)
        {
            PageIndexChanged?.Invoke(this, e);

            if (e.Data != null)
            {
                this.pageObject = e.Data;

                if (this.pageObject.PageCurrent < 1)
                {
                    this.pageObject.PageCurrent = 1;
                }

                this.btnFirst.Enabled = this.btnPrevious.Enabled = (this.pageObject.PageCurrent > 1);
                this.btnNext.Enabled = this.btnLast.Enabled = (this.pageObject.PageCurrent < this.pageObject.PageCount);

                if (this.pageObject.PageCount > 0)
                {
                    this.nudPage.Maximum = this.pageObject.PageCount;
                }
                this.nudPage.Enabled = (this.pageObject.PageCount > 0);

                this.lbInfo.Text = string.Format("共 {0} 条数据/共 {1} 页/当前第 {2} 页", this.pageObject.RowCount, this.pageObject.PageCount, this.pageObject.PageCurrent);
            }
        }

        public void Search()
        {
            if (this.nudPage.Value != 1)
            {
                this.nudPage.Value = 1;
            }
            else
            {
                this.Go(1);
            }
        }
        public new void Refresh()
        {
            this.Go(this.pageObject.PageCurrent);
        }
        private void Go(int pageIndex)
        {
            this.pageObject.PageCurrent = pageIndex;
            this.OnPageIndexChanged(new TEventArgs<PageObject>(this.pageObject));
        }

        #region 翻页事件
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            int pageIndex = 1;

            if (this.pageObject.PageCount != 0)
            {
                this.nudPage.Value = pageIndex;
            }
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            if (this.pageObject.PageCount != 0)
            {
                var pageIndex = this.pageObject.PageCount;
                this.nudPage.Value = pageIndex;
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            int pageIndex = this.pageObject.PageCurrent;

            if (this.pageObject.PageCount != 0)
            {
                if (pageIndex == 1)
                {
                    MessageBox.Show("当前已经是第一页了！");
                    return;
                }
                pageIndex--;
                if (pageIndex != 0)
                {
                    this.nudPage.Value = pageIndex;
                }
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            int pageIndex = this.pageObject.PageCurrent;

            if (this.pageObject.PageCount != 0)
            {
                if (pageIndex == this.pageObject.PageCount)
                {
                    MessageBox.Show("当前已经是最后一页了！");
                    return;
                }
                pageIndex++;
                if (pageIndex <= this.pageObject.PageCount)
                {
                    this.nudPage.Value = pageIndex;
                }
            }
        }
        #endregion

        private void NudPage_ValueChanged(object sender, EventArgs e)
        {
            int currentPage = (int)this.nudPage.Value;
            this.Go(currentPage);
        }
    }
}
