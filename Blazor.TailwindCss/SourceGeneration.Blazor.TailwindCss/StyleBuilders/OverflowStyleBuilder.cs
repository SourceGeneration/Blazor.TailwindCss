namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class OverflowStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("overflow"))
            return false;

        if (value.Equals("auto"))
            writer.Write(name, "overflow:auto");
        else if (value.Equals("hidden"))
            writer.Write(name, "overflow:hidden");
        else if (value.Equals("clip"))
            writer.Write(name, "overflow:clip");
        else if (value.Equals("visible"))
            writer.Write(name, "overflow:visible");
        else if (value.Equals("scroll"))
            writer.Write(name, "position:scroll");
        else
            return false;

        return true;
    }

}
