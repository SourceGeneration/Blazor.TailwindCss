using System.Text.RegularExpressions;

namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal partial class InsetStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (key.Equals("inset") ||
            key.Equals("top") ||
            key.Equals("left") ||
            key.Equals("right") ||
            key.Equals("bottom"))
        {
            if (!byte.TryParse(value, out byte v))
            {
                if (GetPercentageRegex().IsMatch(value))
                {
                    var index = value.IndexOf('/');
                    var a = value.Substring(0, index);
                    var b = value.Substring(index + 1);
                    if (byte.TryParse(a, out byte v1) && byte.TryParse(b, out byte v2))
                    {
                        var p = (double)v1 * 100 / v2;
                        writer.Write(name, $"{key}:{p:f2}%");
                        return true;
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
            }

            if (v == 0)
                writer.Write(name, $"{key}:{v * 0.25}px");
            else
                writer.Write(name, $"{key}:{v * 0.25}rem");
            return true;
        }
        return false;

    }


    private static Regex? _getPercentageRegex;
    private static Regex GetPercentageRegex()
    {
        return _getPercentageRegex ??= new Regex(@"^\d{1,2}/\d{1,2}$", RegexOptions.Compiled);
    }
}
