using CodeMechanic.Advanced.Regex;

namespace BlazorHtmx.Services;

public class CurlOptions
{
    public string bearer_token { get; set; } = string.Empty;

    public string execution_method { get; set; } = string.Empty;

    // public List<string> headers { get; set; }
    public string raw_headers { get; set; } = string.Empty;

    public string[] Headers => raw_headers.Extract(CurlRegex.Find(CurlRegex.HEADERS));

    public string uri { get; set; } = string.Empty;
    // public static CurlOptions None = new();
}