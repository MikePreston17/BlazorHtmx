namespace CodeMechanic.Todoist;

public class TodoistTask
{
    public string id { get; set; } = string.Empty;

    public string assigner_id { get; set; } = string.Empty;

    public string assignee_id { get; set; } = string.Empty;

    public string project_id { get; set; } = string.Empty;

    public string section_id { get; set; } = string.Empty;

    public string parent_id { get; set; } = string.Empty;

    public int order { get; set; }

    public string content { get; set; } = string.Empty;

    public string description { get; set; } = string.Empty;

    public bool is_completed { get; set; }

    public string[] labels = new string[] { };

    public string priority { get; set; } = string.Empty;

    public string comment_count { get; set; } = string.Empty;

    public string creator_id { get; set; } = string.Empty;

    public string created_at { get; set; } = string.Empty;

    public Due due { get; set; } = new();

    public string url { get; set; } = string.Empty;

    public Duration duration { get; set; } = new();
}

// [JsonObject]
public class CompletedItems
{
    public List<CompletedTodoistTask> items { get; set; } = new();
}

public class CompletedTodoistTask
{
    public string completed_at { get; set; } = string.Empty;
    public string item_object { get; set; } = string.Empty;
    public string meta_data { get; set; } = string.Empty;

    public int note_count { get; set; } = 0;

    public string[] notes { get; set; } = new string[] { };
    public string task_id { get; set; } = string.Empty;
    public string user_id { get; set; } = string.Empty;
}

public class Due
{
    public string date { get; set; } = "2024-02-12";

    // public string friendly {get;set;} = "Feb 12";
    public string lang { get; set; } = "en";
    public string is_recurring { get; set; } = "false";
}

public class Duration
{
    public string amount { get; set; } = string.Empty;
    public string unit { get; set; } = string.Empty;
}