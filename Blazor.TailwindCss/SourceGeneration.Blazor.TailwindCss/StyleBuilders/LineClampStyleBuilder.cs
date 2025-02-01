namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class LineClampStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("line"))
        {
            return false;
        }

        if (!value.StartsWith("clamp-"))
        {
            return false;
        }

        value = value.Substring(6);

        if (value.Equals("none"))
        {
            writer.Write(name, ["overflow:visible", "display:block", "-webkit-box-orient:horizontal"]);
            return true;
        }

        if (!byte.TryParse(value, out byte v))
        {
            return false;
        }

        writer.Write(name, ["overflow:hidden", "display:-webkit-box", "-webkit-box-orient:vertical", $"-webkit-line-clamp:{v}"]);
        return true;
    }

}