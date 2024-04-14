using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    /// <summary>
    /// Transaction management aspect. If there is problem in the process, rollback all jobs
    /// </summary>
    
    //Todo - Add async version of transactionAspect from updated sources
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception ex)
                {
                    transactionScope.Dispose();
                    ex.ToString();
                    throw;
                }
            }
        }
    }
}
