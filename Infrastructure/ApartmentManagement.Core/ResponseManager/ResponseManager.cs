
namespace ApartmentManagement.Core.ResponseManager;

public static class ResponseManager
{
    public static BaseResponseModel Ok(object data, string message = "Success")
    {
        return new BaseResponseModel
        {
            Success = true,
            Message = message,
            Data = data,
            StatusCode = 200
        };
    }

    public static BaseResponseModel BadRequest(string message, List<string> errors = null)
    {
        return new BaseResponseModel
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>(),
            StatusCode = 400
        };
    }

    public static BaseResponseModel Unauthorized(string message, List<string> errors = null)
    {
        return new BaseResponseModel
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>(),
            StatusCode = 401
        };
    }

    public static BaseResponseModel InternalServerError(string message, List<string> errors = null)
    {
        return new BaseResponseModel
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>(),
            StatusCode = 500
        };
    }

    // Generic versiyonlar
    public static BaseResponseModel<T> Ok<T>(T data, string message = "İşlem başarılı")
    {
        return new BaseResponseModel<T>
        {
            Success = true,
            Message = message,
            Data = data,
            StatusCode = 200
        };
    }

    public static BaseResponseModel<T> BadRequest<T>(string message, List<string> errors = null)
    {
        return new BaseResponseModel<T>
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>(),
            StatusCode = 400
        };
    }

    public static BaseResponseModel<T> Unauthorized<T>(string message, List<string> errors = null)
    {
        return new BaseResponseModel<T>
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>(),
            StatusCode = 401
        };
    }

    public static BaseResponseModel<T> InternalServerError<T>(string message, List<string> errors = null)
    {
        return new BaseResponseModel<T>
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>(),
            StatusCode = 500
        };
    }
}