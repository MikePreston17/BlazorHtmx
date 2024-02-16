using CodeMechanic.Airtable.Models;

namespace CodeMechanic.Airtable;

public static class AirtableSerivceExtensions
{
    public static List<NugPart> FindNugParts(this NugBuild build)
    {
        return new();
        /*
        var related_tasks = build.NugBuilds
            .Join(build.NugParts
                , project => project.id
                , task => task.project_id
                , (project, task) => new { project, task })
            .Where(@t => @t.project.name == project.name)
            .Select(combo => combo.task);

        return related_tasks.ToList();
        */
    }
}