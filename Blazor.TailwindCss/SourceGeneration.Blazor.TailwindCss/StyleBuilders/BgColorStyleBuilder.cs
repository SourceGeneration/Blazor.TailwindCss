namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class BgColorStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("bg"))
        {
            return false;
        }

        if (TwColors.TryGetColorStyle(value, out string? color))
        {
            writer.Write(name, $"background-color:{color}");
            return true;
        }

        return false;
    }
}
