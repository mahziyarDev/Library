namespace Library.Common.Exception;

public class BadRequestException : System.Exception
{
    public BadRequestException(string msg) : base(msg) {}
}