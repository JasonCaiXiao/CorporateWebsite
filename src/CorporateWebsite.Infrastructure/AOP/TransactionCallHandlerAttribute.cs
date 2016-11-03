using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CorporateWebsite.Infrastructure.AOP
{
    /// <summary>
    /// 事务机制属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionCallHandlerAttribute : Attribute
    {
    }
}
