using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gugubao.Award.Infrastructure
{
    /// <summary>
    /// 分页实体类
    /// </summary>
    [Serializable]
    public class PageObject
    {
        /// <summary>
        /// 当前页码，默认为第1页
        /// </summary>
        public int PageCurrent { get; set; } = 1;

        /// <summary>
        /// 每页显示数据个数，默认为12个
        /// </summary>
        public int PageSize { get; set; } = 12;

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int RowCount { get; set; }

        public PageObject()
        {
            this.PageCurrent = 1;
        }

        public PageObject(int pageSize)
        {
            this.PageCurrent = 1;
            this.PageSize = pageSize;
        }
    }
}
