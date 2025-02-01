namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class AlignItemsStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("items"))
            return false;

        if (value.Equals("start"))
        {
            writer.Write(name, "align-items:flex-start");
            return true;
        }
        if (value.Equals("end"))
        {
            writer.Write(name, "align-items:flex-end");
            return true;
        }
        if (value.Equals("center"))
        {
            writer.Write(name, "align-items:center");
            return true;
        }
        if (value.Equals("baseline"))
        {
            writer.Write(name, "align-items:baseline");
            return true;
        }
        if (value.Equals("stretch"))
        {
            writer.Write(name, "align-items:stretch");
            return true;
        }

        return false;
    }
}
