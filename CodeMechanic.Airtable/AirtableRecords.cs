using CodeMechanic.Airtable.Models;

namespace CodeMechanic.Airtable;

public class AirtableRecords
{
    public List<NugBuild> NugBuilds { get; set; } = new();
    public List<NugPart> NugParts { get; set; } = new();
    public List<NugPart> BuildParts { get; set; } = new();
}