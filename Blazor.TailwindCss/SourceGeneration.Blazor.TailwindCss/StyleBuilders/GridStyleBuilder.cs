namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class GridStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("grid"))
            return false;

        if (value.Length == 0)
        {
            writer.Write(name, "display:grid");
            return true;
        }

        if (value.StartsWith("cols-"))
        {
            if (!byte.TryParse(value.Substring(5), out byte v))
                return false;

            writer.Write(name, $"grid-template-columns:repeat({v}, minmax(0, 1fr))");
            return true;
        }

        return false;
    }
}
