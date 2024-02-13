using System.Text.RegularExpressions;
using CodeMechanic.Diagnostics;
using CodeMechanic.Types;

namespace BlazorHtmx.Services;

public static class CurlRegexExtensions
{
    public static IDictionary<string, Regex> known_curls =
        new Dictionary<string, Regex>();
}

public class CurlRegex : Enumeration
{
    //https://regex101.com/r/K4Bv8n/1
    public static CurlRegex GET = new CurlRegex(1, nameof(GET),
        @"^\s*\$?\s*curl\s*-X\s*(?<execution_method>GET|POST|DELETE)(?:\s*\\)?\s*(?<uri>https.*)(\s*\\)\s*-H\s*(?<raw_headers>[""]\w+:\s*Bearer\s*(?<bearer_token>.*)"")");

    // https://regex101.com/r/QAkG7A/1
    public static CurlRegex POST = new CurlRegex(2, nameof(POST),
        @"^\s*\$?\s*curl\s*""https.*\s*\\\s*-X\s*(?<execution_method>GET|POST|DELETE)\s*\\\s*(--data(?<json_data>.*))?(?:\\)?\s*(?<raw_headers>(-H\s*""(?<header_name>[a-zA-Z-]+):(?<header_value>.*|(\s*Bearer\s(?<bearer_token>[a-zA-Z\d]+)))""\s*\\?)\s*)*");

    // todo: https://regex101.com/r/qYhFGD/1
    public static CurlRegex HEADERS = new CurlRegex(3, nameof(HEADERS),
        @"(?<headers>(-H\s*""(?<header_name>[a-zA-Z-]+):\s*(Bearer\s*(?<bearer_token>[a-zA-Z\d]+))""\s*))");


    public readonly Regex compiled;


    public CurlRegex(int id, string name, string pattern) : base(id, name)
    {
        this.compiled = new Regex(pattern, RegexOptions.Compiled);
        CurlRegexExtensions.known_curls.Dump("dictionary so far");
        CurlRegexExtensions.known_curls.TryAdd(name, compiled);
        CurlRegexExtensions.known_curls.Dump();
    }


    public static Regex Find(CurlRegex selected)
    {
        string name = selected.Name;
        CurlRegexExtensions.known_curls.TryGetValue(name, out Regex compiled);
        return compiled ?? throw new Exception("Could not find regex with name " + name);
    }
}