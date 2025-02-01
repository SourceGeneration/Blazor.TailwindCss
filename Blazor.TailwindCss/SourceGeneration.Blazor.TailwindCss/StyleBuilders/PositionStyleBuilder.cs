namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class PositionStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (value.Length != 0)
            return false;

        if (key.Equals("absolute"))
            writer.Write(name, "position:absolute");
        else if (key.Equals("relative"))
            writer.Write(name, "position:relative");
        else if (key.Equals("static"))
            writer.Write(name, "position:static");
        else if (key.Equals("fixed"))
            writer.Write(name, "position:fixed");
        else if (key.Equals("sticky"))
            writer.Write(name, "position:sticky");
        else
            return false;

        return true;
    }
}
