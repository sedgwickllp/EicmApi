namespace Eicm.Core.Extensions
{
    public class CommonResult<T> : ICommonResult<T>
    {
        public CommonResult(bool resultCode)
        {
            ResultCode = resultCode;
        }
        public CommonResult(T payload, bool resultCode)
        {
            Payload = payload;
            ResultCode = resultCode;
        }

        public CommonResult(T payload, bool resultCode, string message)
        {
            Payload = payload;
            ResultCode = resultCode;
            Message = message;
        }

        public T Payload { get; }
        public string Message { get; }
        public bool ResultCode { get; }

    }
}