namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class TextColorBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("text"))
        {
            return false;
        }

        string[]? style;
        if (TwColors.TryGetColorStyle(value, out string? color))
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
