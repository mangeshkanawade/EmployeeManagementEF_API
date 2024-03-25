namespace EmployeeManagementEF.Shared
{
    public class Result<T>
    {
        public ResultType Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Result() { }
        public List<string> Errors { get; private set; }
        public Result(ResultType status, string message, T result)
        {
            Status = status;
            Message = message;
            Data = result;
        }
        public Result(ResultType status, string message)
        {
            Status = status;
            Message = message;
        }
        public static Result<T> Failure(string message)
        {
            return new Result<T>(ResultType.Fail, message);
        }

        public static Result<T> Success(T value)
        {
            return new Result<T> { Status = ResultType.Success, Data = value };
        }

    }

    public enum ResultType
    {
        Success = 1, Fail = 2, NotFound = 3
    }
}
