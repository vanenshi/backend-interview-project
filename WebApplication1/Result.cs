using System.Net;

namespace backend_interview_project
{
    public class Result<T>
    {
        public  bool IsSuccess { get; set; }

        public  T Data { get; set; }

        public   string Message { get; set; }

        public  HttpStatusCode Status { get; set; }

        public static Result<T> Success(T value, string message = "عملیات موفقیت آمیز بود.")
            => new Result<T> { IsSuccess = true, Data = value, Message = message, Status = HttpStatusCode.OK };

        public static Result<T> Failure(string error, HttpStatusCode status = HttpStatusCode.NotAcceptable)
            => new Result<T> { IsSuccess = false, Message = error, Status = status };
    }

    public class Result
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public HttpStatusCode Status { get; set; }
    }
}
