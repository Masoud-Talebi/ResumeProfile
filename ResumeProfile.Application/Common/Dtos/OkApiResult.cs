namespace ResumeProfile.Application.Common.Dtos;

public class OkApiResult<T>
{
    public static OkApiResult<T> Ok(T data, int code = 200)
    {
        return new OkApiResult<T>
        {
            Success = true,
            Data = data,
            Code = code
        };
    }

    public static OkApiResult<T> Fail(string errorMessage, int code)
    {
        return new OkApiResult<T>
        {
            Success = false,
            Data = (T)(object)errorMessage, // چون Data جنریک هست
            Code = code
        };
    }

    public bool Success { get; set; }
    public T Data { get; set; }
    public int Code { get; set; }
    public string? Message { get; set; } = ".عملیات با موفقیت انجام شد";
}