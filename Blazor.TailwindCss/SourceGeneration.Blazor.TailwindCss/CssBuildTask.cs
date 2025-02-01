using Microsoft.Build.Framework;

namespace SourceGeneration.Blazor.TailwindCss;

public class CssBuildTask : Microsoft.Build.Utilities.Task
{
    [Required] public string? ProjectDir { get; set; }
    [Required] public string? CssOuput { get; set; }

    public override bool Execute()
    {
        if (string.IsNullOrWhiteSpace(ProjectDir) ||
            string.IsNullOrWhiteSpace(CssOuput))
            return false;

        var styles = CssRenderer.Analyze(ProjectDir!);
        File.WriteAllText(Path.Combine(CssOuput, "tailwind.css"), styles);

        return true;
    }
}
