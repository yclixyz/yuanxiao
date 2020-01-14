

/*******************************************************************************
* Copyright (C) gugubao
* 
* Author: yclixyz
* Create Date: 2020年1月3日
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Gugubao.Award.Infrastructure
{
    /// <summary>
    /// 数据库连接
    /// </summary>
    public class AwardDbConetxt : DbContext
    {
        #region DbSet
        /// <summary>
        /// Account
        /// </summary>
        public DbSet<Account> Account { get; set; }
        /// <summary>
        /// AwardItem
        /// </summary>
        public DbSet<AwardItem> AwardItem { get; set; }
        /// <summary>
        /// AwardLevel
        /// </summary>
        public DbSet<AwardLevel> AwardLevel { get; set; }
        /// <summary>
        /// AwardRecord
        /// </summary>
        public DbSet<AwardRecord> AwardRecord { get; set; }
        /// <summary>
        /// Group
        /// </summary>
        public DbSet<Group> Group { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource={Path.Combine("award.db")}");

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
