using System;

namespace KutuphaneAppWithIoC.Core.Services.Interfaces
{
    public class ServiceResult
    {

        public object Data { get; set; }

        public string Message { get; private set; }

        public ServiceResultType ResultType { get; private set; }
        public Exception Exception { get; private set; }
        public ServiceResultCode Code { get; private set; }
        public ServiceResult(ServiceResultType resultType, ServiceResultCode code)
        {
            ResultType = resultType;
            Code = code;
        }

        public ServiceResult(ServiceResultType resultType, string message, ServiceResultCode code)
        {
            ResultType = resultType;
            Message = message;
            Code = code;
        }

        public ServiceResult(ServiceResultType resultType, Exception exception, string message, ServiceResultCode code)
        {
            ResultType = resultType;
            Exception = exception;
            Message = message;
            Code = code;
        }

        public ServiceResult(ServiceResultType resultType, Exception exception, string message, ServiceResultCode code, object data)
        {
            ResultType = resultType;
            Exception = exception;
            Message = message;
            Code = code;
            Data = data;
        }

        public ServiceResult(ServiceResultType resultType, Exception exception, ServiceResultCode code)
        {
            ResultType = resultType;
            Exception = exception;
            Code = code;

        }
    }
}