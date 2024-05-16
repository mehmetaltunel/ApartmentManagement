namespace ApartmentManagement.Core.ResponseManager;

public class BaseResponseModel
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; }

    public BaseResponseModel()
    {
        Errors = new List<string>();
    }
}

public class BaseResponseModel<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; }

    public BaseResponseModel()
    {
        Errors = new List<string>();
    }
}

