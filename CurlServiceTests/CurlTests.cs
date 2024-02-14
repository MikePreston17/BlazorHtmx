using CodeMechanic.Diagnostics;
using CodeMechanic.Todoist;

namespace TestProject1;

[TestClass]
public class CurlTests
{
    [TestMethod]
    public void CanEatTurkey()
    {
        string projectDirectory = (Directory
            .GetParent(Environment.CurrentDirectory)
            ?.Parent?.Parent?.FullName);
        string filename = "todoist.rest";
        string filepath = Path.Combine(projectDirectory, filename);
        string curl = File.ReadAllText(filepath);
        var svc = new TodoistService();
        var options = svc.RunCommand(curl);
        options.Dump("options");
    }
}