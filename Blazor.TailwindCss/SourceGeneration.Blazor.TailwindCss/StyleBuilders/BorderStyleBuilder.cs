namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class BorderStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("border"))
        {
            return false;
        }

        if(value.Length == 0)
        {
            writer.Write(name, "border-width:1px");
            return true;
        }

        if (value.StartsWith("t-"))
        {
            value = value.Substring(2);
            if (byte.TryParse(value, out var b))
            {
                writer.Write(name, $"border-top-width:{b}px");
                return true;
            }
        }
        else if (value.StartsWith("b-"))
        {
            value = value.Substring(2);
            if (byte.TryParse(value, out var b))
            {
                writer.Write(name, $"border-bottom-width:{b}px");
                return true;
            }
        }
        else if (value.StartsWith("l-"))
        {
            value = value.Substring(2);
            if (byte.TryParse(value, out var b))
            {
                writer.Write(name, $"border-left-width:{b}px");
                return true;
            }
        }
        else if (value.StartsWith("r-"))
        {
            value = value.Substring(2);
            if (byte.TryParse(value, out var b))
            {
                writer.Write(name, $"border-right-width:{b}px");
                return true;
            }
        }
        else if (value.Equals("solid"))
        {
            writer.Write(name, "border-style:solid");
        }
        else if (value.Equals("dashed"))
        {
            writer.Write(name, "border-style:dashed");
        }
        else if (value.Equals("dotted"))
        {
            writer.Write(name, "border-style:dotted");
        }
        else if (value.Equals("double"))
        {
            writer.Write(name, "border-style:double");
        }
        else if (value.Equals("hidden"))
        {
            writer.Write(name, "border-style:hidden");
        }
        else if (value.Equals("none"))
        {
            writer.Write(name, "border-style:none");
        }
        else
        {
            if (byte.TryParse(value, out var b))
            {
                writer.Write(name, $"border-width:{b}px");
                return true;
            }

            if (TwColors.TryGetColorStyle(value, out string? color))
            {
                writer.Write(name, $"border-color:{color}");
                return true;
            }
        }

        return false;
    }

}
