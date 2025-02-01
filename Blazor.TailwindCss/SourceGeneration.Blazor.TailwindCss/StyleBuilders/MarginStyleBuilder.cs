namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class MarginStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (key[0] != 'm')
        {
            return false;
        }

        string? d;
        if (value.Equals("auto"))
        {
            d = "auto";
        }
        else if (!ParseFloatingRemValue(value, out d))
        {
            return false;
        }

        if (key.Length == 1)
        {
            writer.Write(name, $"margin:{d}");
            return true;
        }
        else if (key.Length == 2)
        {
            string[]? style;
            var p = key[1];
            if (p == 'x')
            {
                style = [$"margin-left:{d}", $"margin-right:{d}"];
            }
            else if (p == 'y')
            {
                style = [$"margin-top:{d}", $"margin-bottom:{d}"];
            }
            else if (p == 't')
            {
                style = [$"margin-top:{d}"];
            }
            else if (p == 'b')
            {
                style = [$"margin-bottom:{d}"];
            }
            else if (p == 'l')
            {
                style = [$"margin-left:{d}"];
            }
            else if (p == 'r')
            {
                style = [$"margin-right:{d}"];
            }
            else
            {
                return false;
            }

            writer.Write(name, style);
            return true;
        }
        else
        {
            return false;
        }
    }
}
