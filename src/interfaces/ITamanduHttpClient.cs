using System.Reflection.Metadata;
using TamanduAPI.Http.Enums;
using TamanduAPI.Http.Models;

namespace TamanduAPI.Http.Interfaces;

public interface ITamanduHttpClient
{
    /// <summary>
    /// Estabelece túnel de conexão TCP com servidores que utilizam TLS. Mais informações em: https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods/CONNECT
    /// </summary>
    /// <param name="uri">URI do servidor</param>
    /// <param name="httpVersion">Versao do protocolo, padrão 1.1</param>
    /// <param name="host">Host opcional. Exemplo: server.example.com:80</param>
    /// <param name="proxyAuthorization">Autorizacao proxy. Exemplo: basic aGVsbG86d29ybGQ=</param>
    /// <returns>Booleano indicando se o túnel foi criado ou não</returns>
    public bool Connect(string uri, HttpVersion? httpVersion = HttpVersion.HTTP_11, string? host = null, string? proxyAuthorization = null);
    public HttpResponse Options(string uri, HttpVersion? httpVersion = HttpVersion.HTTP_11, string? pages = "*");
    public List<HttpResponse> Trace(string uri);
    /// <summary>
    /// Função que realiza requisição Http com verbo GET
    /// </summary>
    /// <param name="uri">URI da qual deseja-se realizar a requisição</param>
    /// <param name="header">Dicionário com os pares chave-valor para os cabeçalhos da requisição (opcional)</param>
    /// <param name="queryString">String de consulta adicional que pode ser fornecida neste verbo</param>
    /// <returns>Objeto HttpResponse com status code, body e header</returns>
    public HttpResponse Get(string uri, Dictionary<string, string>? header = null, string? queryString = null);
    /// <summary>
    /// Função que realiza requisição Http com verbo GET de forma assíncrona. Deve ser invocada precedida do operador "await"
    /// </summary>
    /// <param name="uri">URI da qual deseja-se realizar a requisição</param>
    /// <param name="header">Dicionário com os pares chave-valor para os cabeçalhos da requisição (opcional)</param>
    /// <param name="queryString">String de consulta adicional que pode ser fornecida neste verbo</param>
    /// <returns>Task de objeto HttpResponse (pode ser resolvida pelo operador "await") com status code, body e header</returns>
    public Task<HttpResponse> GetAsync(string uri, Dictionary<string, string>? header = null, string? queryString = null);
    public HttpResponse Post<T>(string uri, T? package, Dictionary<string, string>? header = null);
    public Task<HttpResponse> PostAsync<T>(string uri, T? package, Dictionary<string, string>? header = null);
    public HttpResponse Put<T>(string uri, T entirePackage, Dictionary<string, string>? header = null);
    public Task<HttpResponse> PutAsync<T>(string uri, T entirePackage, Dictionary<string, string>? header = null);
    public HttpResponse Patch<T>(string uri, T partialPackage, Dictionary<string, string>? header = null);
    public Task<HttpResponse> PatchAsync<T>(string uri, T partialPackage, Dictionary<string, string>? header = null);
    public HttpResponse Delete(string uri, string queryString, Dictionary<string, string>? header = null);
    public Task<HttpResponse> DeleteAsync(string uri, string queryString, Dictionary<string, string>? header = null);
}