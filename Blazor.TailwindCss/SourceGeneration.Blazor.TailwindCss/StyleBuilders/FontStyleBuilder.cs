namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class FontWeightBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("font"))
            return false;

        if (value.Equals("thin"))
            writer.Write(name, "font-weight:100");
        if (value.Equals("extralight"))
            writer.Write(name, "font-weight:200");
        if (value.Equals("light"))
            writer.Write(name, "font-weight:300");
        else if (value.Equals("normal"))
            writer.Write(name, "font-weight:400");
        else if (value.Equals("medium"))
            writer.Write(name, "font-weight:500");
        else if (value.Equals("semibold"))
            writer.Write(name, "font-weight:600");
        else if (value.Equals("bold"))
            writer.Write(name, "font-weight:700");
        else if (value.Equals("extrabold"))
            writer.Write(name, "font-weight:800");
        else if (value.Equals("black"))
            writer.Write(name, "font-weight:900");
        else
            return false;

        return true;
    }
}
