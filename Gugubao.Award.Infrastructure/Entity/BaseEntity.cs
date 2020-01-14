using System;
using System.Collections.Generic;
using System.Text;

namespace Gugubao.Award.Infrastructure
{
    public class BaseEntity
    {
        public long Id { get; set; } = SnowflakeId.Default().NextId();

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime ModifyTime { get; set; } = DateTime.Now;
    }
}
