namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class ScrollStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("scroll"))
            return false;

        string? style;
        if (value.Equals("auto"))
        {
            style = "scroll-behavior:auto";
        }
        else if (value.Equals("smooth"))
        {
            style = "scroll-behavior:smooth";
        }
        else
        {
            return false;
        }

        writer.Write(name, style);
        return true;
    }

}