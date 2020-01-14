using Gugubao.Award.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gugubao.Award.Infrastructure
{
    public class StartAward
    {
        /// <summary>
        /// 跨线程修改UI线程的委托
        /// </summary>
        /// <param name="account">中奖人员信息</param>
        public delegate void NotifyHandler(Account account);

        /// <summary>
        /// 抽奖过程变更通知事件
        /// </summary>
        public event NotifyHandler AwardingNotifyHandler;

        /// <summary>
        /// 中奖通知事件
        /// </summary>
        public event NotifyHandler AwardedNotifyHandler;

        public Task Go(CancellationTokenSource cancellationTokenSource, AwardLevel awardLevel)
        {
            using AwardDbConetxt context = new AwardDbConetxt();

            // 所有客户
            var allAccounts = context.Account.ToList();

            var random = new Random();

            while (!cancellationTokenSource.IsCancellationRequested)
            {
                var randomNo = random.Next(0, allAccounts.Count);

                AwardingNotify(allAccounts[randomNo]);

                Thread.Sleep(10);

                continue;
            }

            // 停止抽奖，获取实际中奖人员
            if (cancellationTokenSource.IsCancellationRequested)
            {
                // 获取未中奖的公司内部人员
                var groups = context.Group.ToList();
                var internalGroup = groups.First(c => c.Name == "Internal");
                var internalAccountsUnPrized = allAccounts.Where(c => c.GroupId == internalGroup.Id && !c.HasPrized).ToList();

                // 所有的未中奖人员列表
                var allAccountsUnPrized = allAccounts.Where(c => !c.HasPrized).ToList();

                // 中奖人员
                var awardedAccount = BuildAwardedAccount(allAccounts, allAccountsUnPrized, internalAccountsUnPrized, awardLevel, random);

                // 标记当前用户为已中奖
                var entity = context.Account.First(c => c.Id == awardedAccount.Id);
                entity.HasPrized = true;
                context.Account.Update(entity);

                var awardItem = context.AwardItem.FirstOrDefault(c => c.LevelId == awardLevel.Id);

                var awardItemId = 0L;

                if (awardItem != null)
                {
                    awardItemId = awardItem.Id;
                }

                var awardRecord = new AwardRecord
                {
                    AccountId = entity.Id,
                    AwardItemId = awardItemId,
                };

                context.AwardRecord.Add(awardRecord);

                context.SaveChanges();

                AwardedNotify(awardedAccount);
            }

            return Task.CompletedTask;
        }

        private void AwardingNotify(Account account)
        {
            AwardingNotifyHandler?.Invoke(account);
        }

        private void AwardedNotify(Account account)
        {
            AwardedNotifyHandler?.Invoke(account);
        }

        private Account BuildAwardedAccount(List<Account> allAccounts, List<Account> allAccountsUnPrized, List<Account> internalAccountsUnPrized, AwardLevel awardLevel, Random random)
        {
            // 如果当前是特等奖且设置了内部人员，如果未设置内部人员，则全局获取一位幸运观众
            if (awardLevel.Name == "特等奖" && internalAccountsUnPrized.Count > 0)
            {
                var randomNo = random.Next(0, internalAccountsUnPrized.Count);

                var awardedAccount = internalAccountsUnPrized[randomNo];

                return awardedAccount;
            }
            else
            {
                // 如果已经全部中奖
                if (allAccountsUnPrized.Count == 0)
                {
                    var randomNo = random.Next(0, allAccounts.Count);

                    var awardedAccount = allAccounts[randomNo];

                    return awardedAccount;
                }
                else
                {
                    var randomNo = random.Next(0, allAccountsUnPrized.Count);

                    var awardedAccount = allAccountsUnPrized[randomNo];

                    return awardedAccount;
                }
            }
        }
    }
}
