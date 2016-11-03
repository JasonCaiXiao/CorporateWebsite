using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;

namespace CorporateWebsite.Infrastructure.AOP
{
    /// <summary>
    ///  AOP事务处理
    /// </summary>
    public class TransactionCallHandler : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();//操作异常，自己回滚
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("信息异常,原因:" + ex.Message);
                }
            }
        }
    }
}
