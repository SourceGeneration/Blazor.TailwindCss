namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class SpaceStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("space") || value[1] != '-')
        {
            return false;
        }

        if (!byte.TryParse(value.Substring(2), out var v))
        {
            return false;
        }

        if (value[0] == 'x')
        {
            var d = v * 0.25;
            writer.Write($"space-x-{v}>*:not([hidden])~:not([hidden])", $"margin-left:{d}rem");
            return true;
        }
        else if (value[0] == 'y')
        {
            var d = v * 0.25;
            writer.Write($"space-y-{v}>*:not([hidden])~:not([hidden])", $"margin-top:{d}rem");
            return true;
        }
        else
        {
            return false;
        }

    }
}
