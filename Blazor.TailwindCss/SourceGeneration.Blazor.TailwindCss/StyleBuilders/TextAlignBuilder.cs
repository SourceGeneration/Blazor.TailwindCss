namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class TextAlignBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("text"))
        {
            return false;
        }

        string[]? style;
        if (value.Equals("center"))
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
        else
        {
            return false;
        }

        writer.Write(name, style);

        return true;
    }

}
