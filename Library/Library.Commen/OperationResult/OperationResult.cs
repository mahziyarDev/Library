namespace Library.Common.OperationResult;

public class OperationResult<TData> 
{
    public string Code { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    public TData Data { get; set; }


    public OperationResult(string code, bool success, string message = null, TData data = default(TData))
    {
        Code = code;
        Success = success;
        Message = message;
        Data = data;
    }

}

public class OperationResult
{
    public string Code { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }


    public OperationResult(string code, bool success, string message = null)
    {
        Code = code;
        Success = success;
        Message = message;
    }

}