namespace Eicm.Core.Extensions
{
    public interface ICommonResult<T>
    {
        T Payload { get; }
        bool ResultCode { get; }
        string Message { get; }
    }
}