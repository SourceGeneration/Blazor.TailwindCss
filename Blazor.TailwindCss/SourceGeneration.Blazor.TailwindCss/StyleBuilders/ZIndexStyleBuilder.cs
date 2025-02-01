namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class ZIndexStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("z"))
            return false;

        string? style;
        if (value.Equals("auto"))
        {
            style = "z-index:auto";
        }
        else if (byte.TryParse(value, out var v))
        {
            style = $"z-index:{v * 10}";
        }
        else
        {
            return false;
        }

        writer.Write(name, style);
        return true;
    }

}
