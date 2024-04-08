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
    public Dictionary<string,string>? Headers 
    { 
        get => _headers;
        set => _headers = value;   
    }
    private Dictionary<string, string>? _headers;
    public string? Body 
    {
        get => _body;
        set
        {
            if(value?.Length < 2)
                throw new ArgumentException("Body must have, at least 2 characters \"{\" and \"}\"");
            _body = value;
        }
    }
    private string? _body;
}