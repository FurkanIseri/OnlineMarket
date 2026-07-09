namespace OnlineMarketApp.Infrastructere.Extensions
{
    public static class HttpRequestExtensions
    {
        // URL bağlantısını şekli şemalini değiştirir.
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue
            ? $"{request.Path}{request.QueryString}"
            : request.Path.ToString();
        }
    }
}