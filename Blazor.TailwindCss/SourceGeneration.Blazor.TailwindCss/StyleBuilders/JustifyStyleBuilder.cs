namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class JustifyStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("justify"))
            return false;

        string? style;

        if (value.Equals("start"))
        {
            style = "justify-content:flex-start";
        }
        else if (value.Equals("end"))
        {
            style = "justify-content:flex-end";
        }
        else if (value.Equals("center"))
        {
            style = "justify-content:flex-center";
        }
        else if (value.Equals("between"))
        {
            style = "justify-content:space-between";
        }
        else if (value.Equals("around"))
        {
            style = "justify-content:space-around";
        }
        else if (value.Equals("evenly"))
        {
            style = "justify-content:space-evenly";
        }
        else if (value.Equals("stretch"))
        {
            style = "justify-content:stretch";
        }
        else
        {
            return false;
        }

        writer.Write(name, style);
        return true;
    }
}
