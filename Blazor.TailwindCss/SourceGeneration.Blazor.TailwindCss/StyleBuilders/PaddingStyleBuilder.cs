namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class PaddingStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!ParseFloatingRemValue(value, out var d))
        {
            return false;
        }

        if (key[0] != 'p')
        {
            return false;
        }

        if (key.Length == 1)
        {
            writer.Write(name, $"padding:{d}");
            return true;
        }

        if (key.Length == 2)
        {
            string[]? style;
            var p = key[1];
            if (p == 'x')
            {
                style = [$"padding-left:{d}", $"padding-right:{d}"];
            }
            else if (p == 'y')
            {
                style = [$"padding-top:{d}", $"padding-bottom:{d}"];
            }
            else if (p == 't')
            {
                style = [$"padding-top:{d}"];
            }
            else if (p == 'b')
            {
                style = [$"padding-bottom:{d}"];
            }
            else if (p == 'l')
            {
                style = [$"padding-left:{d}"];
            }
            else if (p == 'r')
            {
                style = [$"padding-right:{d}"];
            }
            else
            {
                return false;
            }

            writer.Write(name, style);
            return true;
        }
        return false;
    }
}
