using System;
using System.Collections.Generic;
using System.Text;

namespace Gugubao.Award.Infrastructure
{
    public class AwardLevelEvent
    {
        /// <summary>
        /// 奖品等级变更事件
        /// </summary>
        public event EventHandler<AwardLevel> LevelNotifyHandler;

        public void LevelNotifyExcute(object sender, AwardLevel e)
        {
            if (LevelNotifyHandler != null)
            {
                LevelNotifyHandler.Invoke(sender, e);
            }
        }
    }
}
