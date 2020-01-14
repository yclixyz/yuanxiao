using Gugubao.Award.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Gugubao.Award.Infrastructure.StartAward;

namespace Gugubao.Award.Main
{
    public partial class FrmMain : Form
    {
        private Point _formPoint = new Point();
        private AwardLevel _awardLevel;
        private readonly AwardLevelEvent _awardLevelEventHandler;
        private readonly IMemoryCache _cache;
        private readonly StartAward startAward = new StartAward();
        private delegate void InvokeCallback(string msg);
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public FrmMain(IMemoryCache cache, AwardLevelEvent awardLevelEventHandler)
        {
            _awardLevelEventHandler = awardLevelEventHandler;
            _awardLevelEventHandler.LevelNotifyHandler += AwardLevelEventHandler_NotifyHandler;

            _cache = cache;
            startAward.AwardingNotifyHandler += StartAward_AwardingNotifyHandler;
            startAward.AwardedNotifyHandler += StartAward_AwardedNotifyHandler;
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            this.Hide();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (this.BtnStart.Text == "开始")
            {
                cancellationTokenSource = new CancellationTokenSource();

                Task.Run(() =>
                {
                    startAward.Go(cancellationTokenSource, _awardLevel);
                });

                this.BtnStart.Text = "暂停";
            }
            else
            {
                cancellationTokenSource.Cancel();

                this.BtnStart.Text = "开始";
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (_awardLevel != null)
            {
                ReloadIndexAward();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-_formPoint.X, -_formPoint.Y);
                Location = myPosittion;
            }
        }


        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            _formPoint.X = e.X;
            _formPoint.Y = e.Y;
        }

        private void StartAward_AwardingNotifyHandler(Account account)
        {
            AwardChange(account);
        }

        private void StartAward_AwardedNotifyHandler(Account account)
        {
            AwardChange(account);

            if (this.LBAwardNo.InvokeRequired)
            {
                NotifyHandler msgCallback = new NotifyHandler(StartAward_AwardedNotifyHandler);
                this.LBAwardNo.Invoke(msgCallback, new object[] { account });
            }
            else
            {
                using AwardDbConetxt context = new AwardDbConetxt();

                var awardNo = context.AwardRecord.Include(c => c.AwardItem).Count(c => c.AwardItem.LevelId == _awardLevel.Id).ToString();

                this.LBAwardNo.Text = $"已抽取：{awardNo}位";
            }
        }

        private void AwardLevelEventHandler_NotifyHandler(object sender, AwardLevel e)
        {
            _awardLevel = e;

            ReloadIndexAward();
        }

        private void AwardChange(Account account)
        {
            if (this.LbName.InvokeRequired)
            {
                NotifyHandler msgCallback = new NotifyHandler(StartAward_AwardingNotifyHandler);
                this.LbName.Invoke(msgCallback, new object[] { account });
            }
            else
            {
                this.LbName.Text = account.Name;
            }

            if (this.LbPhone.InvokeRequired)
            {
                NotifyHandler msgCallback = new NotifyHandler(StartAward_AwardingNotifyHandler);
                this.LbPhone.Invoke(msgCallback, new object[] { account });
            }
            else
            {
                this.LbPhone.Text = Regex.Replace(account.CellPhone, @"(?<=^(\d){3})\d{4}", "****"); ;
            }

            if (this.PbHeadUrl.InvokeRequired)
            {
                NotifyHandler msgCallback = new NotifyHandler(StartAward_AwardingNotifyHandler);
                this.PbHeadUrl.Invoke(msgCallback, new object[] { account });
            }
            else
            {
                var bitMap = _cache.Get(account.Id);

                if (bitMap == null)
                {
                    this.PbHeadUrl.Image = _cache.Get("ggb") as Bitmap;
                }

                this.PbHeadUrl.Image = bitMap as Bitmap; //Image.FromFile(account.HeadImageLocalUrl);
            }
        }

        private void ReloadIndexAward()
        {
            using AwardDbConetxt context = new AwardDbConetxt();

            this.PbLevel.Image = Image.FromFile(context.AwardItem.FirstOrDefault(c => c.LevelId == _awardLevel.Id).ImageUrl);

            var awardNo = context.AwardRecord.Include(c => c.AwardItem).Count(c => c.AwardItem.LevelId == _awardLevel.Id).ToString();

            this.LBAwardNo.Text = $"已抽取：{awardNo}位";

            this.LbLevel.Text = _awardLevel.Name;

            this.PbHeadUrl.Image = _cache.Get("ggb") as Bitmap;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;

            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Hide();//esc关闭窗体
                        break;
                }
            }
            return false;
        }

        #region 双击全屏，再次双击恢复 
        //private bool m_IsFullScreen = false;//标记是否全屏

        //private void FormMain_DoubleClick(object sender, EventArgs e)
        //{
        //    m_IsFullScreen = !m_IsFullScreen;//点一次全屏，再点还原。  
        //    this.SuspendLayout();
        //    if (m_IsFullScreen)//全屏 ,按特定的顺序执行
        //    {
        //        SetFormFullScreen(m_IsFullScreen);
        //        this.FormBorderStyle = FormBorderStyle.None;
        //        this.WindowState = FormWindowState.Maximized;
        //        this.Activate();//
        //    }
        //    else//还原，按特定的顺序执行——窗体状态，窗体边框，设置任务栏和工作区域
        //    {
        //        this.WindowState = FormWindowState.Normal;
        //        this.FormBorderStyle = FormBorderStyle.None;
        //        SetFormFullScreen(m_IsFullScreen);
        //        this.Activate();
        //    }
        //    this.ResumeLayout(false);
        //}

        ///// <summary>  
        ///// 设置全屏或这取消全屏  
        ///// </summary>  
        ///// <param name="fullscreen">true:全屏 false:恢复</param>  
        ///// <param name="rectOld">设置的时候，此参数返回原始尺寸，恢复时用此参数设置恢复</param>  
        ///// <returns>设置结果</returns>  
        //private bool SetFormFullScreen(Boolean fullscreen)//, ref Rectangle rectOld
        //{
        //    Rectangle rectOld = Rectangle.Empty;
        //    int hwnd = NativeMethods.FindWindow("Shell_TrayWnd", null);

        //    if (hwnd == 0) return false;

        //    if (fullscreen)//全屏
        //    {
        //        //ShowWindow(hwnd, SW_HIDE);//隐藏任务栏
        //        NativeMethods.SystemParametersInfo(NativeMethods.SPI_GETWORKAREA, 0, ref rectOld, NativeMethods.SPIF_UPDATEINIFILE);//get屏幕范围
        //        Rectangle rectFull = Screen.PrimaryScreen.Bounds;//全屏范围
        //        NativeMethods.SystemParametersInfo(NativeMethods.SPI_SETWORKAREA, 0, ref rectFull, NativeMethods.SPIF_UPDATEINIFILE);//窗体全屏幕显示
        //    }
        //    else//还原 
        //    {
        //        NativeMethods.ShowWindow(hwnd, NativeMethods.SW_SHOW);//显示任务栏
        //        NativeMethods.SystemParametersInfo(NativeMethods.SPI_SETWORKAREA, 0, ref rectOld, NativeMethods.SPIF_UPDATEINIFILE);//窗体还原
        //    }
        //    return true;
        //}


        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    this.panelEnhanced1.Width = this.Width;
        //    this.panelEnhanced1.Height = this.Height;

        //    base.OnSizeChanged(e);
        //} 
        #endregion
    }
}
