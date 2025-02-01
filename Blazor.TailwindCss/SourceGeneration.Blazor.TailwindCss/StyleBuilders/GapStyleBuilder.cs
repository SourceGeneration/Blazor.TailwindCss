namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class GapStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("gap"))
            return false;

        if (!byte.TryParse(value, out byte v))
            return false;

        writer.Write(name, $"gap:{v * 0.25}rem");
        return true;
    }
}
