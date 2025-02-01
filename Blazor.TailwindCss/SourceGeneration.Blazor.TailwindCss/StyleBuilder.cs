namespace SourceGeneration.Blazor.TailwindCss;

internal abstract class StyleBuilder
{
    public abstract bool TryBuild(string name, string key, string value, StyleWriter writer);

    protected static bool ParseFloatingRemValue(string value, out string? remValue)
    {
        if (float.TryParse(value, out var b))
        {
            remValue = b == 0 ? "0px" : $"{b * 0.25:n2}rem";
            return true;
        }
        remValue = null;
        return false;
    }

    protected static bool ParseIngeterRemValue(string value, out string? remValue)
    {
        if (byte.TryParse(value, out var b))
        {
            remValue = b == 0 ? "0px" : $"{b * 0.25}rem";
            return true;
        }
        remValue = null;
        return false;
    }
}
