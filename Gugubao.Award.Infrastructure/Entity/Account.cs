using System;
using System.Collections.Generic;
using System.Text;

namespace Gugubao.Award.Infrastructure
{
    public class Account : BaseEntity
    {
        public string CellPhone { get; set; }

        public string Name { get; set; }

        public string OpenId { get; set; }

        public string HeadImageUrl { get; set; }

        public string HeadImageLocalUrl { get; set; }

        public string NickName { get; set; }

        public bool HasPrized { get; set; }

        public long GroupId { get; set; }

        public Group Group { get; set; }

    }
}
