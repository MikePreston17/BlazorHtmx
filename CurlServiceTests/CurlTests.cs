using System.Text.RegularExpressions;
using CodeMechanic.Diagnostics;
using CodeMechanic.FileSystem;
using CodeMechanic.Todoist;
using Newtonsoft.Json;

namespace TestProject1;

[TestClass]
public class CurlTests
{
    private readonly string projectDirectory;
    private readonly string env_path;
    private readonly string api_key;

    public CurlTests()
    {
        projectDirectory = (Directory
            .GetParent(Environment.CurrentDirectory)
            ?.Parent?.Parent?.FullName);

        env_path = Path.Combine(projectDirectory, ".env");

        DotEnv.Load(env_path).Dump("dotenv");

        api_key = Environment.GetEnvironmentVariable("TODOIST_API_KEY").Dump("keeeee!");
    }

    [TestMethod]
    public async Task CanGetAllProjects()
    {
        string filename = "todoist.rest";
        string filepath = Path.Combine(projectDirectory, filename);
        string file_text = File.ReadAllText(filepath);

        // Update the curl string to always have the most updated bearer token (and not a sample, like most tutorials)
        string curl =
                Regex.Replace(
                    file_text
                    , @"Bearer \$?\w+"
                    , "Bearer " + api_key
                )
            ;

        Console.WriteLine(curl);

        // have the service create the httpclient, not the dev.
        var svc = new TodoistService();
        var options = svc.GetClient(curl);

        var all_tasks = options
            .Select(o => svc.GetContentAsync(o.uri, o.bearer_token));

        // run as normal (dev's job-ish)
        var responses = await Task.WhenAll(all_tasks);

        Console.WriteLine($"{responses.Length} of {all_tasks.Count()} curls completed ");

        var json_files = SaveAsJsonFiles(responses);

        var results = DeserializeEverything(json_files);
        results.Item1.Count.Dump("# of tasks");
        results.Item2.Count.Dump("# of projects");
        
    }

    private static ( List<TodoistTask>, List<TodoistProject> ) DeserializeEverything(IEnumerable<string> json_files)
    {
        List<TodoistProject> projects = new();
        List<TodoistTask> todoist_tasks = new();
        foreach (var file_path in json_files)
        {
            Console.WriteLine("Deserializing json from path '" + file_path + "'");
            string json = File.ReadAllText(file_path);


            if (json.Contains("showProject?"))
            {
                projects = json.Deserialize<TodoistProject>();
            }

            if (json.Contains("showTask?"))
            {
                todoist_tasks = json.Deserialize<TodoistTask>();
            }
        }

        return (todoist_tasks, projects);
    }

    private IEnumerable<string> SaveAsJsonFiles(string[] responses)
    {
        string output_folder = Path.Combine(projectDirectory, "samples");
        if (!Directory.Exists(output_folder))
            Directory.CreateDirectory(output_folder);

        foreach (var line in responses)
        {
            string save_path = Path.Combine(projectDirectory, output_folder,
                "response" + Guid.NewGuid().ToString() + ".json");
            Console.WriteLine($"saving to :>> '{save_path}'");

            File.WriteAllText(save_path, line);
            yield return save_path;
        }
    }
}