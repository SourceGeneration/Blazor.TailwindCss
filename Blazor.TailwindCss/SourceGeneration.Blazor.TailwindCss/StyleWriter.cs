using System.Text;

namespace SourceGeneration.Blazor.TailwindCss;

internal sealed class StyleWriter(string? screen = null)
{
    private readonly string? Screen = screen;
    private readonly StringBuilder _builder = new(1024 * 64);

    private bool _important = false;
    internal void SetImportant(bool important)
    {
        _important = important;
    }

    public void Write(string name, params string[] styles)
    {
        if (styles == null || styles.Length == 0)
            return;

        _builder.Append('.');
        if (Screen != null)
        {
            _builder.Append(Screen);
            _builder.Append("\\:");
        }
        if (name.Contains('/') || name.Contains('.'))
        {
            _builder.Append(name.ToString().Replace("/", "\\/").Replace(".", "\\."));
        }
        else
        {
            _builder.Append(name);
        }
        if (_important)
        {
            _builder.Append("\\!");
        }
        _builder.Append('{');

        foreach (var style in styles)
        {
            var s = style.Trim();
            if (_important)
            {
                if (s.EndsWith(";"))
                {
                    s = s.Substring(0, s.Length - 1);
                }
                _builder.Append(s);
                _builder.Append(" !important;");
            }
            else
            {
                _builder.Append(style);
                if (!s.EndsWith(";"))
                {
                    _builder.Append(';');
                }
            }
        }
        _builder.Append('}');
    }

    public int Length => _builder.Length;

    public override string ToString()
    {
        return _builder.ToString();
    }
}
