using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gugubao.Award.Infrastructure
{
    /// <summary>
    /// 范型事件参数，与 EventHandler<T> 结合使用
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class TEventArgs<T> : EventArgs
    {
        public T Data { get; set; }

        public TEventArgs(T data)
        {
            this.Data = data;
        }
    }
}
