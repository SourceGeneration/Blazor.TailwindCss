namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class MaxHeightStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("max") || !value.StartsWith("h-"))
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
            writer.Write(name, $"max-height:{d}rem");
            return true;
        }
        else
        {
            string? style;
            if (value.Equals("none"))
                style = "max-height:none";
            else if (value.Equals("min"))
                style = "max-height:min-content";
            else if (value.Equals("max"))
                style = "max-height:max-content";
            else if (value.Equals("xs"))
                style = "max-height:20rem";
            else if (value.Equals("sm"))
                style = "max-height:24rem";
            else if (value.Equals("md"))
                style = "max-height:28rem";
            else if (value.Equals("lg"))
                style = "max-height:32rem";
            else if (value.Equals("xl"))
                style = "max-height:36rem";
            else if (value.Equals("2xl"))
                style = "max-height:42rem";
            else if (value.Equals("3xl"))
                style = "max-height:48rem";
            else if (value.Equals("4xl"))
                style = "max-height:56rem";
            else if (value.Equals("5xl"))
                style = "max-height:64rem";
            else if (value.Equals("6xl"))
                style = "max-height:72rem";
            else if (value.Equals("7xl"))
                style = "max-height:80rem";
            else if (value.Equals("8xl"))
                style = "max-height:90rem";
            else if (value.Equals("9xl"))
                style = "max-height:100rem";
            else
                return false;

            writer.Write(name, style);
            return true;
        }
    }
}
