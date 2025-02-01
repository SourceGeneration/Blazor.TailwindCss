namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class MaxWidthStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("max") || !value.StartsWith("w-"))
        {
            return false;
        }

        value = value.Substring(2);
        if (value.Length == 0)
        {
            return false;
        }

        if (byte.TryParse(value, out var v))
        {
            var d = v * 0.25;
            writer.Write(name, $"max-width:{d}rem");
            return true;
        }
        else
        {
            string? style;
            if (value.Equals("none"))
                style = "max-width:none";
            else if (value.Equals("min"))
                style = "max-width:min-content";
            else if (value.Equals("max"))
                style = "max-width:max-content";
            else if (value.Equals("xs"))
                style = "max-width:20rem";
            else if (value.Equals("sm"))
                style = "max-width:24rem";
            else if (value.Equals("md"))
                style = "max-width:28rem";
            else if (value.Equals("lg"))
                style = "max-width:32rem";
            else if (value.Equals("xl"))
                style = "max-width:36rem";
            else if (value.Equals("2xl"))
                style = "max-width:42rem";
            else if (value.Equals("3xl"))
                style = "max-width:48rem";
            else if (value.Equals("4xl"))
                style = "max-width:56rem";
            else if (value.Equals("5xl"))
                style = "max-width:64rem";
            else if (value.Equals("6xl"))
                style = "max-width:72rem";
            else if (value.Equals("7xl"))
                style = "max-width:80rem";
            else if (value.Equals("8xl"))
                style = "max-width:90rem";
            else if (value.Equals("9xl"))
                style = "max-width:100rem";
            else
                return false;

            writer.Write(name, style);
            return true;
        }
    }
}
