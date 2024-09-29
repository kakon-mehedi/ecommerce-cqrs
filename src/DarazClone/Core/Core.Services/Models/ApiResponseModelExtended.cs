namespace DarazClone.Core.Services.Models;

public class ApiResponseModelExtended
{
    public string Message { get; set; } = string.Empty;
    public int HttpStatusCode { get; set; } = 200;
    public int TotalCount { get; private set; } = 0;
    public dynamic Data { get; private set; } = string.Empty;
    public List<ValidationError> Errors { get; set; }
    public bool IsSuccess => Errors.Count > 0 ? false : true; //{ get; private set; }


    public ApiResponseModelExtended()
    {
        Errors = new List<ValidationError>();
    }

    public ApiResponseModelExtended SetSuccess()
    {
        Errors = new List<ValidationError>();
        return this;
    }

    public ApiResponseModelExtended SetSuccess(dynamic data, int statusCode = 200)
    {
        Errors = new List<ValidationError>();
        Data = data;
        HttpStatusCode = statusCode;
        return this;
    }

    public ApiResponseModelExtended SetSuccess(dynamic data, string message, int statusCode = 0)
    {
        Errors = new List<ValidationError>();
        Data = data;
        Message = message;
        HttpStatusCode = statusCode;
        return this;
    }

    public ApiResponseModelExtended SetStatusCode(int statusCode)
    {
        HttpStatusCode = statusCode;
        return this;
    }

    public ApiResponseModelExtended SetError(string code, string errorMessage)
    {
        
        var validationError = new ValidationError
        {
            ErrorCode = code,
            ErrorMessage = errorMessage
        };

        Errors.Add(validationError);
        return this;
    }

    public ApiResponseModelExtended SetErrors(List<ValidationError> validationErrors)
    {
        Errors = validationErrors;
        return this;
    }

    public ApiResponseModelExtended SetMessage(string message)
    {
        Message = message;
        return this;
    }

    public ApiResponseModelExtended SetTotalCount(int count)
    {
        TotalCount = count;
        return this;
    }
}

public class ValidationError
{
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
}