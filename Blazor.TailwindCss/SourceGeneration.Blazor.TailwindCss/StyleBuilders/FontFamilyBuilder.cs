namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class FontFamilyBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("font"))
            return false;

        if (value.Equals("sans"))
            writer.Write(name, "font-family: ui-sans-serif, system-ui, sans-serif, \"Apple Color Emoji\", \"Segoe UI Emoji\", \"Segoe UI Symbol\", \"Noto Color Emoji\"");
        else if (value.Equals("serif"))
            writer.Write(name, "font-family: ui-serif, Georgia, Cambria, \"Times New Roman\", Times, serif");
        else if (value.Equals("mono"))
            writer.Write(name, "font-family: ui-monospace, SFMono-Regular, Menlo, Monaco, Consolas, \"Liberation Mono\", \"Courier New\", monospace");
        else
            return false;

        return true;
    }
}
