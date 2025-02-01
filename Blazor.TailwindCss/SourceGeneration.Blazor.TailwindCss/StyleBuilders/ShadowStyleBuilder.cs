namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class ShadowStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (!key.Equals("shadow"))
        {
            return false;
        }

        string[] styles;
        if (value.Length == 0)
        {
            const string format = "0 1px 3px 0 {0}, 0 1px 2px -1px {0}";
            var shadow = $"--tw-shadow:{string.Format(format, "rgb(0 0 0 / 0.1)")}";
            var shadow_colored = $"--tw-shadow-colored:{string.Format(format, "var(--tw-shadow-color)")}";
            styles = [shadow, shadow_colored, "box-shadow:var(--tw-shadow)"];
        }
        else if (value.Equals("sm"))
        {
            const string format = "0 1px 2px 0 {0}";
            var shadow = $"--tw-shadow:{string.Format(format, "rgb(0 0 0 / 0.05)")}";
            var shadow_colored = $"--tw-shadow-colored:{string.Format(format, "var(--tw-shadow-color)")}";
            styles = [shadow, shadow_colored, "box-shadow:var(--tw-shadow)"];
        }
        else if (value.Equals("md"))
        {
            const string format = "0 4px 6px -1px {0}, 0 2px 4px -2px {0}";
            var shadow = $"--tw-shadow:{string.Format(format, "rgb(0 0 0 / 0.1)")}";
            var shadow_colored = $"--tw-shadow-colored:{string.Format(format, "var(--tw-shadow-color)")}";
            styles = [shadow, shadow_colored, "box-shadow:var(--tw-shadow)"];
        }
        else if (value.Equals("lg"))
        {
            const string format = "0 10px 15px -3px {0}, 0 4px 6px -4px {0}";
            var shadow = $"--tw-shadow:{string.Format(format, "rgb(0 0 0 / 0.1)")}";
            var shadow_colored = $"--tw-shadow-colored:{string.Format(format, "var(--tw-shadow-color)")}";
            styles = [shadow, shadow_colored, "box-shadow:var(--tw-shadow)"];
        }
        else if (value.Equals("xl"))
        {
            const string format = "0 20px 25px -5px {0}, 0 8px 10px -6px {0}";
            var shadow = $"--tw-shadow:{string.Format(format, "rgb(0 0 0 / 0.1)")}";
            var shadow_colored = $"--tw-shadow-colored:{string.Format(format, "var(--tw-shadow-color)")}";
            styles = [shadow, shadow_colored, "box-shadow:var(--tw-shadow)"];
        }
        else if (value.Equals("2xl"))
        {
            const string format = "0 25px 50px -12px {0}";
            var shadow = $"--tw-shadow:{string.Format(format, "rgb(0 0 0 / 0.25)")}";
            var shadow_colored = $"--tw-shadow-colored:{string.Format(format, "var(--tw-shadow-color)")}";
            styles = [shadow, shadow_colored, "box-shadow:var(--tw-shadow)"];
        }
        else if (value.Equals("inner"))
        {
            const string format = "inset 0 2px 4px 0 {0}";
            var shadow = $"--tw-shadow:{string.Format(format, "rgb(0 0 0 / 0.05)")}";
            var shadow_colored = $"--tw-shadow-colored:{string.Format(format, "var(--tw-shadow-color)")}";
            styles = [shadow, shadow_colored, "box-shadow:var(--tw-shadow)"];
        }
        else if (value.Equals("none"))
        {
            styles = ["box-shadow:0 0 #0000"];
        }
        else if (TwColors.TryGetColorStyle(value, out string? color))
        {
            styles = [$"--tw-shadow-color:{color}", "--tw-shadow:var(--tw-shadow-colored)"];
        }
        else
        {
            return false;
        }

        writer.Write(name, styles);

        return true;
    }
}
