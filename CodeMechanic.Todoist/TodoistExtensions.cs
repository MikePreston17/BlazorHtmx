using Newtonsoft.Json;

namespace CodeMechanic.Todoist;

public static class TodoistExtensions
{
    public static List<T> Deserialize<T>(this string line) // where T : class
    {
        return JsonConvert.DeserializeObject<List<T>>(line);
        // return System.Text.Json.JsonSerializer.Deserialize<List<T>>(line);
    }

    // // Find matching tasks, completed tasks and more.
    // public static TodoistStats UpdateStats(this TodoistStats current_stats)
    // {
    //     var projects = current_stats.TodoistProjects;
    //     var tasks_matching_projects = 
    // }
}