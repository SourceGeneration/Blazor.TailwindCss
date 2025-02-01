namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class WidthStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("w"))
            return false;

        string? style;
        if (value.Equals("full"))
        {
            style = "width:100%";
        }
        else if (value.Equals("max"))
        {
            style = "width:max-content";
        }
        else if (value.Equals("min"))
        {
            style = "width:min-content";
        }
        else if (value.Equals("fit"))
        {
            style = "width:fit-content";
        }
        else if (value.Equals("auto"))
        {
            style = "width:auto";
        }
        else if (ParseFloatingRemValue(value, out var v))
        {
            style = $"width:{v}";
        }
        else
        {
            return false;
        }

        writer.Write(name, style);
        return true;
    }

}
