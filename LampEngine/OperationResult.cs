namespace LampEngine
{
    public class OperationResult
    {
        public int ErrorCode { get; set;}

        public OperationResult(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public OperationResult(int errorCode, DTO dObject)
        {
            ErrorCode = errorCode;
        }
    }
}