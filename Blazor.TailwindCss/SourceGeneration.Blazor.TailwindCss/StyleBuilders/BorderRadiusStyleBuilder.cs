namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class BorderRadiusStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("rounded"))
        {
            return false;
        }

        string? style;
        if (value.Length == 0)
        {
            style = "border-radius:0.25rem";
        }
        else if (value.Equals("none"))
        {
            style = "border-radius:0px";
        }
        else if (value.Equals("sm"))
        {
            style = "border-radius:0.125rem";
        }
        else if (value.Equals("md"))
        {
            style = "border-radius:0.375rem";
        }
        else if (value.Equals("lg"))
        {
            style = "border-radius:0.5rem";
        }
        else if (value.Equals("xl"))
        {
            style = "border-radius:0.75rem";
        }
        else if (value.Equals("2xl"))
        {
            style = "border-radius:1rem";
        }
        else if (value.Equals("3xl"))
        {
            style = "border-radius:1.5rem";
        }
        else if (value.Equals("4xl"))
        {
            style = "border-radius:2rem";
        }
        else
        {
            return false;
        }

        writer.Write(name, style);
        return true;
    }
}
