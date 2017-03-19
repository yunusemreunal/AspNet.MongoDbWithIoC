using System;
using KutuphaneAppWithIoC.Core.Services.Interfaces;

namespace KutuphaneAppWithIoC.Core.Structure
{
    public class ServiceBase : IService
    {
        public ServiceResult Result { get; set; }

        protected ServiceBase()
        {
            SetResultAsSuccess();
        }

        internal void SetResultAsFail(ServiceResultCode code, Exception exception)
        {
            Result = new ServiceResult(ServiceResultType.Fail, exception, code);
        }

        internal void SetResultAsFail(ServiceResultCode code, string message)
        {
            Result = new ServiceResult(ServiceResultType.Fail, message, code);
        }

        internal void SetResultAsSuccess(ServiceResultCode code, string message)
        {
            Result = new ServiceResult(ServiceResultType.Success, message, code);
        }

        internal void SetResultAsSuccess(string message, object data)
        {
            Result = new ServiceResult(ServiceResultType.Success, null, message, ServiceResultCode.Success, data);
        }

        internal void SetResultAsSuccess(ServiceResultCode code)
        {
            Result = new ServiceResult(ServiceResultType.Success, code);
        }

        internal void SetResultAsSuccess()
        {
            Result = new ServiceResult(ServiceResultType.Success, ServiceResultCode.Success);
        }
    }
}
