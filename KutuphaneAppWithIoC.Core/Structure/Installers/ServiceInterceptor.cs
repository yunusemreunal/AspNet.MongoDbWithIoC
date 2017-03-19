using System;
using System.Transactions;
using Castle.DynamicProxy;
using KutuphaneAppWithIoC.Core.Services.Interfaces;

namespace KutuphaneAppWithIoC.Core.Structure.Installers
{
    public class ServiceInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {

            var methodInfo = invocation.MethodInvocationTarget;

            try
            {
                var hasTransactAttribute = Attribute.GetCustomAttribute(methodInfo, typeof(HandleTransaction));
                if (hasTransactAttribute != null)
                {
                    using (var transcaction = new TransactionScope())
                    {
                        invocation.Proceed();
                        transcaction.Complete();
                    }
                }
                else
                {
                    invocation.Proceed();
                }
            }
            catch (Exception ex)
            {
                if (UnitOfWork.CurrentSession.Transaction != null)
                    UnitOfWork.CurrentSession.Transaction.Dispose();

                var service = (ServiceBase)invocation.InvocationTarget;
                service.SetResultAsFail(ServiceResultCode.Fail, ex);
            }
        }
    }
}