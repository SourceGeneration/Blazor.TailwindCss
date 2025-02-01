using SourceGeneration.Blazor.TailwindCss.StyleBuilders;
using System.Text;
using System.Text.RegularExpressions;

namespace SourceGeneration.Blazor.TailwindCss;

internal sealed partial class CssRenderer
{
    private static readonly List<StyleBuilder> _builders =
    [
        new PaddingStyleBuilder(),
        new MarginStyleBuilder(),
        new WidthStyleBuilder(),
        new HeightStyleBuilder(),
        new MaxWidthStyleBuilder(),
        new MaxHeightStyleBuilder(),
        new ZIndexStyleBuilder(),

        new FlexStyleBuilder(),
        new GridStyleBuilder(),
        new GapStyleBuilder(),
        new AlignItemsStyleBuilder(),
        new JustifyStyleBuilder(),
        new SpaceStyleBuilder(),

        new DisplayStyleBuilder(),
        new PositionStyleBuilder(),
        new OverflowStyleBuilder(),
        new InsetStyleBuilder(),

        new TextStyleBuilder(),
        new LeadingStyleBuilder(),
        new LineClampStyleBuilder(),
        new FontStyleBuilder(),

        new CursorStyleBuilder(),

        new BgColorStyleBuilder(),
        new BorderStyleBuilder(),
        new ShadowStyleBuilder(),
        new RoundedStyleBuilder(),

        new ScrollStyleBuilder(),
    ];

    public static string Analyze(string directory)
    {
        List<string> classes = [];

        Regex regex = ClassRegex();

        foreach (var file in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
        {
            var ext = Path.GetExtension(file);
            if (ext != ".razor" && ext != ".cs")
                continue;

            var content = File.ReadAllText(file);

            var matches = regex.Matches(content);
            foreach (Match match in matches)
            {
                var value = match.Groups[2].Value;
                foreach (var cl in value.Split([' '], StringSplitOptions.RemoveEmptyEntries))
                {
                    if (string.IsNullOrWhiteSpace(cl))
                        continue;

                    var c = cl.Trim();
                    if (!classes.Contains(c))
                        classes.Add(c);
                }

            }
        }

        return BuildStyle(classes)?.ToString() ?? string.Empty;
    }

    private static string? BuildStyle(List<string> classes)
    {
        if (classes.Count == 0)
            return default;

        StyleWriter df = new();
        StyleWriter xs = new("xs");
        StyleWriter sm = new("sm");
        StyleWriter md = new("md");
        StyleWriter lg = new("lg");
        StyleWriter xl = new("xl");

        StyleWriter? current = null;
        foreach (var styleBuilder in _builders)
        {
            foreach (var @class in new List<string>(classes))
            {
                var s = ParseClass(@class);

                if (s.Pseudo == null || s.Pseudo.Length == 0)
                {
                    current = df;
                }
                else if (s.Pseudo.Length == 2)
                {
                    if (s.Pseudo.Equals("xs"))
                    {
                        current = xs;
                    }
                    else if (s.Pseudo.Equals("sm"))
                    {
                        current = sm;
                    }
                    else if (s.Pseudo.Equals("md"))
                    {
                        current = md;
                    }
                    else if (s.Pseudo.Equals("lg"))
                    {
                        current = lg;
                    }
                    else if (s.Pseudo.Equals("xl"))
                    {
                        current = xl;
                    }
                }

                if (current == null)
                {
                    continue;
                }

                current.SetImportant(s.Important);
                if (styleBuilder.TryBuild(s.Name, s.Key, s.Value, current))
                {
                    classes.Remove(@class);
                }
                current.SetImportant(false);
            }

            if (classes.Count == 0)
                break;
        }

        StringBuilder writer = new(1024 * 64);

        //writer.Append("*, ::after, ::before{box-sizing:border-box;border-width:0;border-style:solid;border-color:#e5e7eb}::after, ::before{--tw-content:''}:host, html{line-height:1.5;-webkit-text-size-adjust:100%;-moz-tab-size:4;tab-size:4;font-family:ui-sans-serif, system-ui, sans-serif, \"Apple Color Emoji\", \"Segoe UI Emoji\", \"Segoe UI Symbol\", \"Noto Color Emoji\";font-feature-settings:normal;font-variation-settings:normal;-webkit-tap-highlight-color:transparent}body{margin:0;line-height:inherit}hr{height:0;color:inherit;border-top-width:1px}abbr:where([title]){-webkit-text-decoration:underline dotted;text-decoration:underline dotted}h1, h2, h3, h4, h5, h6{font-size:inherit;font-weight:inherit}a{color:inherit;text-decoration:inherit}b, strong{font-weight:bolder}code, kbd, pre, samp{font-family:ui-monospace, SFMono-Regular, Menlo, Monaco, Consolas, \"Liberation Mono\", \"Courier New\", monospace;font-feature-settings:normal;font-variation-settings:normal;font-size:1em}small{font-size:80%}sub, sup{font-size:75%;line-height:0;position:relative;vertical-align:baseline}sub{bottom:-.25em}sup{top:-.5em}table{text-indent:0;border-color:inherit;border-collapse:collapse}button, input, optgroup, select, textarea{font-family:inherit;font-feature-settings:inherit;font-variation-settings:inherit;font-size:100%;font-weight:inherit;line-height:inherit;letter-spacing:inherit;color:inherit;margin:0;padding:0}button, select{text-transform:none}button, input:where([type=button]), input:where([type=reset]), input:where([type=submit]){-webkit-appearance:button;background-color:transparent;background-image:none}:-moz-focusring{outline:auto}:-moz-ui-invalid{box-shadow:none}progress{vertical-align:baseline}::-webkit-inner-spin-button, ::-webkit-outer-spin-button{height:auto}[type=search]{-webkit-appearance:textfield;outline-offset:-2px}::-webkit-search-decoration{-webkit-appearance:none}::-webkit-file-upload-button{-webkit-appearance:button;font:inherit}summary{display:list-item}blockquote, dd, dl, figure, h1, h2, h3, h4, h5, h6, hr, p, pre{margin:0}fieldset{margin:0;padding:0}legend{padding:0}menu, ol, ul{list-style:none;margin:0;padding:0}dialog{padding:0}textarea{resize:vertical}input::placeholder, textarea::placeholder{opacity:1;color:#9ca3af}[role=button], button{cursor:pointer}:disabled{cursor:default}audio, canvas, embed, iframe, img, object, svg, video{display:block;vertical-align:middle}img, video{max-width:100%;height:auto}[hidden]{display:none}*, ::before, ::after{--tw-border-spacing-x:0;--tw-border-spacing-y:0;--tw-translate-x:0;--tw-translate-y:0;--tw-rotate:0;--tw-skew-x:0;--tw-skew-y:0;--tw-scale-x:1;--tw-scale-y:1;--tw-pan-x:;--tw-pan-y:;--tw-pinch-zoom:;--tw-scroll-snap-strictness:proximity;--tw-gradient-from-position:;--tw-gradient-via-position:;--tw-gradient-to-position:;--tw-ordinal:;--tw-slashed-zero:;--tw-numeric-figure:;--tw-numeric-spacing:;--tw-numeric-fraction:;--tw-ring-inset:;--tw-ring-offset-width:0px;--tw-ring-offset-color:#fff;--tw-ring-color:rgb(59 130 246 / 0.5);--tw-ring-offset-shadow:0 0 #0000;--tw-ring-shadow:0 0 #0000;--tw-shadow:0 0 #0000;--tw-shadow-colored:0 0 #0000;--tw-blur:;--tw-brightness:;--tw-contrast:;--tw-grayscale:;--tw-hue-rotate:;--tw-invert:;--tw-saturate:;--tw-sepia:;--tw-drop-shadow:;--tw-backdrop-blur:;--tw-backdrop-brightness:;--tw-backdrop-contrast:;--tw-backdrop-grayscale:;--tw-backdrop-hue-rotate:;--tw-backdrop-invert:;--tw-backdrop-opacity:;--tw-backdrop-saturate:;--tw-backdrop-sepia:;--tw-contain-size:;--tw-contain-layout:;--tw-contain-paint:;--tw-contain-style:}::backdrop{--tw-border-spacing-x:0;--tw-border-spacing-y:0;--tw-translate-x:0;--tw-translate-y:0;--tw-rotate:0;--tw-skew-x:0;--tw-skew-y:0;--tw-scale-x:1;--tw-scale-y:1;--tw-pan-x:;--tw-pan-y:;--tw-pinch-zoom:;--tw-scroll-snap-strictness:proximity;--tw-gradient-from-position:;--tw-gradient-via-position:;--tw-gradient-to-position:;--tw-ordinal:;--tw-slashed-zero:;--tw-numeric-figure:;--tw-numeric-spacing:;--tw-numeric-fraction:;--tw-ring-inset:;--tw-ring-offset-width:0px;--tw-ring-offset-color:#fff;--tw-ring-color:rgb(59 130 246 / 0.5);--tw-ring-offset-shadow:0 0 #0000;--tw-ring-shadow:0 0 #0000;--tw-shadow:0 0 #0000;--tw-shadow-colored:0 0 #0000;--tw-blur:;--tw-brightness:;--tw-contrast:;--tw-grayscale:;--tw-hue-rotate:;--tw-invert:;--tw-saturate:;--tw-sepia:;--tw-drop-shadow:;--tw-backdrop-blur:;--tw-backdrop-brightness:;--tw-backdrop-contrast:;--tw-backdrop-grayscale:;--tw-backdrop-hue-rotate:;--tw-backdrop-invert:;--tw-backdrop-opacity:;--tw-backdrop-saturate:;--tw-backdrop-sepia:;--tw-contain-size:;--tw-contain-layout:;--tw-contain-paint:;--tw-contain-style:}");
        writer.Append(df);
        if (xs.Length > 0)
        {
            writer.Append("@media (max-width: 600px){");
            writer.Append(xs);
            writer.Append('}');
        }
        if (sm.Length > 0)
        {
            writer.Append("@media (min-width: 600px){");
            writer.Append(sm);
            writer.Append('}');
        }
        if (md.Length > 0)
        {
            writer.Append("@media (min-width: 768px){");
            writer.Append(md);
            writer.Append('}');
        }
        if (lg.Length > 0)
        {
            writer.Append("@media (min-width: 1024px){");
            writer.Append(lg);
            writer.Append('}');
        }
        if (xl.Length > 0)
        {
            writer.Append("@media (min-width: 1280px){");
            writer.Append(xl);
            writer.Append('}');
        }
        return writer.ToString();
    }

    private static ClassStruct ParseClass(string @class)
    {
        string? pseudo, value;
        string key;
        bool important = false;

        var index = @class.IndexOf(':');
        if (index >= 0)
        {
            pseudo = @class.Substring(0, index);
        }
        else
        {
            pseudo = default;
        }

        var name = @class.Substring(index + 1);
        if (name.Length > 0 && name.Last() == '!')
        {
            important = true;
            name = name.Substring(0, name.Length - 1);
        }
        index = name.IndexOf('-');
        if (index >= 0)
        {
            key = name.Substring(0, index);
            value = name.Substring(index + 1);
        }
        else
        {
            key = name;
            value = default;
        }

        return new ClassStruct(pseudo, name, key, value ?? string.Empty, important);
    }

    private readonly ref struct ClassStruct(string? pseudo, string name, string key, string value, bool important)
    {
        public readonly string? Pseudo = pseudo;
        public readonly string Name = name;
        public readonly string Key = key;
        public readonly string Value = value;
        public readonly bool Important = important;
    }


    private static Regex? _classRegex;

    private static Regex ClassRegex()
    {
        return _classRegex ??= new(@"(\s[Cc]lass=|CssBuilder\.Class\()""([^""]+)""[\s>\)]");
    }
}
