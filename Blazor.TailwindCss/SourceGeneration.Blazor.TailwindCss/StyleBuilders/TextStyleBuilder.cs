namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class TextStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("text"))
        {
            return false;
        }

        string[]? style;
        if (value.Equals("xs"))
        {
            style = ["font-size:0.75rem", "line-height:1rem"];
        }
        else if (value.Equals("sm"))
        {
            style = ["font-size:0.875rem", "line-height:1.25rem"];
        }
        else if (value.Equals("md") || value.Equals("base"))
        {
            style = ["font-size:1rem", "line-height:1.5rem"];
        }
        else if (value.Equals("lg"))
        {
            style = ["font-size:1.125rem", "line-height:1.75rem"];
        }
        else if (value.Equals("xl"))
        {
            style = ["font-size:1.25rem", "line-height:1.75rem"];
        }
        else if (value.Equals("2xl"))
        {
            style = ["font-size:1.5rem", "line-height:2rem"];
        }
        else if (value.Equals("3xl"))
        {
            style = ["font-size:1.875rem", "line-height:2.25rem"];
        }
        else if (value.Equals("4xl"))
        {
            style = ["font-size:2.25rem", "line-height:2.5rem"];
        }
        else if (value.Equals("5xl"))
        {
            style = ["font-size:3rem", "line-height:1"];
        }
        else if (value.Equals("6xl"))
        {
            style = ["font-size:3.75rem", "line-height:1"];
        }
        else if (value.Equals("7xl"))
        {
            style = ["font-size:4.5rem", "line-height:1"];
        }
        else if (value.Equals("8xl"))
        {
            style = ["font-size:6rem", "line-height:1"];
        }
        else if (value.Equals("9xl"))
        {
            style = ["font-size:8rem", "line-height:1"];
        }
        else if (value.Equals("center"))
        {
            style = ["text-align:center"];
        }
        else if (value.Equals("left"))
        {
            style = ["text-align:left"];
        }
        else if (value.Equals("right"))
        {
            style = ["text-align:right"];
        }
        else if (value.Equals("justify"))
        {
            style = ["text-align:justify"];
        }
        else if (value.Equals("start"))
        {
            style = ["text-align:start"];
        }
        else if (value.Equals("end"))
        {
            style = ["text-align:end"];
        }
        else if (TwColors.TryGetColorStyle(value, out string? color))
        {
            style = [$"color:{color}"];
        }
        else
        {
            return false;
        }

        writer.Write(name, style);

        return true;
    }
}
