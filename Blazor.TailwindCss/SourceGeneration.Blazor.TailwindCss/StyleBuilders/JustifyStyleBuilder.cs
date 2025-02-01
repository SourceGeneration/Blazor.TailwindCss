namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class JustifyStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("justify"))
            return false;

        string? style;

        if (value.Equals("start"))
        {
            style = "justify-content:flex-start";
        }
        else if (value.Equals("end"))
        {
            style = "justify-content:flex-end";
        }
        else if (value.Equals("center"))
        {
            style = "justify-content:flex-center";
        }
        else if (value.Equals("between"))
        {
            style = "justify-content:space-between";
        }
        else if (value.Equals("around"))
        {
            style = "justify-content:space-around";
        }
        else if (value.Equals("evenly"))
        {
            style = "justify-content:space-evenly";
        }
        else if (value.Equals("stretch"))
        {
            style = "justify-content:stretch";
        }
        else if (value.Equals("items-"))
        {
            value = value.Substring(6);
            if (value.Equals("start"))
            {
                style = "justify-items: start";
            }
            else if (value.Equals("end"))
            {
                style = "justify-items: end";
            }
            else if (value.Equals("center"))
            {
                style = "justify-items: center";
            }
            else if (value.Equals("stretch"))
            {
                style = "justify-items: stretch";
            }
            else if (value.Equals("normal"))
            {
                style = "justify-items: normal";
            }
            else
            {
                return false;
            }
        }
        else if (value.Equals("self-"))
        {
            value = value.Substring(5);
            if (value.Equals("auto"))
            {
                style = "justify-self: auto";
            }
            else if (value.Equals("start"))
            {
                style = "justify-self: start";
            }
            else if (value.Equals("end"))
            {
                style = "justify-self: end";
            }
            else if (value.Equals("center"))
            {
                style = "justify-self: center";
            }
            else if (value.Equals("stretch"))
            {
                style = "justify-self: stretch";
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

        writer.Write(name, style);
        return true;
    }
}
