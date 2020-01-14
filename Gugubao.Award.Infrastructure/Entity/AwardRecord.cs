using System;
using System.Collections.Generic;
using System.Text;

namespace Gugubao.Award.Infrastructure
{
    public class AwardRecord : BaseEntity
    {
        public long AccountId { get; set; }

        public long AwardItemId { get; set; }

        public Account Account { get; set; }

        public AwardItem AwardItem { get; set; }

    }
}
