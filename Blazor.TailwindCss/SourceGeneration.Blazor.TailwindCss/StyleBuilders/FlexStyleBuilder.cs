namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class FlexStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("flex"))
            return false;

        string? style;
        if (value.Length == 0)
        {
            style = $"display:flex";
        }
        else if (value.Equals("1"))
        {
            style = $"flex:1 1 0%";
        }
        else if (value.Equals("auto"))
        {
            style = $"flex:1 1 auto";
        }
        else if (value.Equals("row"))
        {
            style = $"flex-direction:row";
        }
        else if (value.Equals("row-reverse"))
        {
            style = $"flex-direction:row-reverse";
        }
        else if (value.Equals("col"))
        {
            style = $"flex-direction:column";
        }
        else if (value.Equals("col-reverse"))
        {
            style = $"flex-direction:column-reverse";
        }
        else if (value.Equals("wrap"))
        {
            style = $"flex-wrap:wrap";
        }
        else if (value.Equals("nowrap"))
        {
            style = $"flex-wrap:nowrap";
        }
        else
        {
            return false;
        }

        writer.Write(name, style);
        return false;
    }

}