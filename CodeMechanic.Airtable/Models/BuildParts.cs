namespace CodeMechanic.Airtable.Models;

public class BuildParts
{
    public NugBuild Build { get; set; } = new();
    public List<NugPart> items { get; set; } = new();
}