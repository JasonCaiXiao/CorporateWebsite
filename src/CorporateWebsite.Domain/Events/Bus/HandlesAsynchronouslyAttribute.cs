using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebsite.Domain.Events.Bus
{
    // 如果事件处理器添加了该属性，表示以异步的方式处理事件
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class HandlesAsynchronouslyAttribute : Attribute
    {
    }
}
