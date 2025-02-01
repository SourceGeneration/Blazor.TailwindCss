namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class LeadingStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("leading"))
        {
            return false;
        }

        if (!byte.TryParse(value, out byte v))
        {
            return false;
        }

        writer.Write(name, $"line-height:{v * 0.25}rem");
        return true;
    }
}
