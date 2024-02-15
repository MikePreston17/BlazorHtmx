// using CodeMechanic.Advanced.Regex;
// using CodeMechanic.Diagnostics;
// using CodeMechanic.Types;
//
// namespace BlazorHtmx.Services;
//
// public interface ITodoistService
// {
//     Task<CurlOptions> RunCommand(string curl, CurlRegex curlRegex);
// }
//
// public class TodoistService : ITodoistService
// {
//     public TodoistService()
//     {
//     }
//
//     public async Task<CurlOptions> RunCommand(string curl, CurlRegex curlRegex)
//     {
//         Console.WriteLine(curl);
//         var regex = CurlRegex.Find(curlRegex);
//         // regex.Dump("regex");
//         var curlOptions = curl.Extract<CurlOptions>(regex)
//             .FirstOrDefault()
//             .Dump("extraction")
//             .ToMaybe()
//             .IfNone(new CurlOptions());
//
//         curlOptions.Dump(nameof(curlOptions));
//         return curlOptions;
//     }
//
//     // public async Task<string> GetProjectsAsync(string apiKey = "")
//     // {
//     //     string uri = "https://api.todoist.com/rest/v2/projects";
//     //     using HttpClient http = new HttpClient();
//     //     http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
//     //     var response = await http.GetAsync(uri);
//     //     response.EnsureSuccessStatusCode();
//     //     var content = await response.Content.ReadAsStringAsync();
//     //     Console.WriteLine("content :>> " + content);
//     //     return content;
//     // }
//     //
//     // public async Task<object?> PostTodoistAsync(string api_key = "")
//     // {
//     //     using HttpClient http = new HttpClient();
//     //
//     //     var task = new TodoistTask
//     //     {
//     //     };
//     //
//     //     string todoist_task = JsonConvert.SerializeObject(task);
//     //     var requestContent = new StringContent(todoist_task, Encoding.UTF8, "application/json");
//     //     var response = await http.PostAsync("companies", requestContent);
//     //     response.EnsureSuccessStatusCode();
//     //     var content = await response.Content.ReadAsStringAsync();
//     //     var created_item = JsonConvert.DeserializeObject(content, new JsonSerializerSettings()
//     //     {
//     //     });
//     //     return created_item;
//     // }
// }
//
// public static class TodoistCurls
// {
//     public static Func<string, string> GetMethod = (string token) => $"""
//                         $ curl -X GET \
//                   https://api.todoist.com/rest/v2/projects \
//                   -H "Authorization: Bearer { token}     "          
//                  """ ;
//
//     public static Func<string, string, string> PostMethod = (string token, string data) => $"""
//                         
//                     $ curl "https://api.todoist.com/rest/v2/projects" \
//                         -X POST \
//                         --data '{ data} ' \
//                         -H "Content-Type: application/json" \
//                         -H "X-Request-Id: $(uuidgen)" \
//                         -H "Authorization: Bearer { token} "         
//                  """ ;
// }
//
// public class TodoistTask
// {
// }
//
// public class TodoistProject
// {
//     public string name { get; set; } = string.Empty;
// }