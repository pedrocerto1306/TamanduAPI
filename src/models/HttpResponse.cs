using TamanduAPI.Http.Enums;

namespace TamanduAPI.Http.Models;

public class HttpResponse
{
    public HttpStatusCode StatusCode 
    {
        get => _statusCode;
        set
        {
            if(!Enum.IsDefined(typeof(HttpStatusCode), value))
                throw new ArgumentException("Status Code must be between 100 and 511");
            _statusCode = value;
        }
    }
    private HttpStatusCode _statusCode;
    private Dictionary<string,string>? Headers { get; }
    private string? Body { get; }
}