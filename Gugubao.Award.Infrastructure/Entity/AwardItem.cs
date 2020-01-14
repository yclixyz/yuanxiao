using System;
using System.Collections.Generic;
using System.Text;

namespace Gugubao.Award.Infrastructure
{
    public class AwardItem : BaseEntity
    {
        public string Name { get; set; }

        public long LevelId { get; set; }

        public string ImageUrl { get; set; }

        public AwardLevel Level { get; set; }
    }
}
