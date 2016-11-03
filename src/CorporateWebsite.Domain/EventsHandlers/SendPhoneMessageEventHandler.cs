using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateWebsite.Domain.Events;
using CorporateWebsite.Domain.Events.Bus;

namespace CorporateWebsite.Domain.EventsHandlers
{
    /// <summary>
    /// 手机短信的事件处理方式
    /// </summary>
    [HandlesAsynchronously]
    public class SendPhoneMessageEventHandler : IEventHandler<OrderGeneratorEvent>
    {
        /// <summary>
        /// 订单生成时触事件处理
        /// </summary>
        /// <param name="evt"></param>
        public void Handle(OrderGeneratorEvent evt)
        {
        }
    }
}
