namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class HeightStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        string? style;

        if (!key.Equals("h"))
            return false;

        if (value.Equals("full"))
        {
            style = "height:100%";
        }
        else if (value.Equals("max"))
        {
            style = "height:max-content";
        }
        else if (value.Equals("min"))
        {
            style = "height:min-content";
        }
        else if (value.Equals("fit"))
        {
            style = "height:fit-content";
        }
        else if (value.Equals("auto"))
        {
            style = "height:auto";
        }
        else if (byte.TryParse(value, out var v))
        {
            style = $"height:{v * 0.25}rem";
        }
        else
        {
            return false;
        }

        writer.Write(name, style);
        return true;
    }

}
