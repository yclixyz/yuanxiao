using Gugubao.Award.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gugubao.Award.Main
{
	public partial class FrmGroup : Form
	{
		public FrmGroup()
		{
			InitializeComponent();

			SetData();

			this.listBox1.DisplayMember = "Display";
			this.listBox1.ValueMember = "Id";

			this.listBox2.DisplayMember = "Display";
			this.listBox2.ValueMember = "Id";
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			var item = listBox2.SelectedItem;

			if (item == null) { return; }

			var id = (long)((dynamic)item).Id;

			using AwardDbConetxt dbConetxt = new AwardDbConetxt();

			var account = dbConetxt.Account.FirstOrDefault(x => x.Id == id);

			if (item == null) return;

			var group = dbConetxt.Group.FirstOrDefault(x => x.Name == "External");

			if (group == null) return;

			account.Group = group;

			dbConetxt.Account.Update(account);

			dbConetxt.SaveChanges();

			this.SetData();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			var item = listBox1.SelectedItem;

			if (item == null) { return; }

			var id = (long)((dynamic)item).Id;

			using AwardDbConetxt dbConetxt = new AwardDbConetxt();

			var account = dbConetxt.Account.FirstOrDefault(x => x.Id == id);

			if (item == null) return;

			var group = dbConetxt.Group.FirstOrDefault(x => x.Name == "Internal");

			if (group == null) return;

			account.Group = group;

			dbConetxt.Account.Update(account);

			dbConetxt.SaveChanges();

			this.SetData();
		}

		private void SetData()
		{
			using AwardDbConetxt dbConetxt = new AwardDbConetxt();

			var accounts = dbConetxt.Account.Select(x => new
			{
				x.Id,
				Display = $"{x.Name}-{x.CellPhone}",
				GroupName = x.Group.Name
			}).ToList();

			this.listBox1.DataSource = accounts.Where(x => x.GroupName == "External").ToList();

			this.listBox2.DataSource = accounts.Where(x => x.GroupName == "Internal").ToList();
		}
	}
}
