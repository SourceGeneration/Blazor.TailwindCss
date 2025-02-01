namespace SourceGeneration.Blazor.TailwindCss.StyleBuilders;

internal class DisplayStyleBuilder : StyleBuilder
{
    public override bool TryBuild(string name, string key, string value, StyleWriter writer)
    {
        if (key.Equals("hidden") && value.Length == 0)
        {
            writer.Write(name, "display:none");
            return true;
        }
        else if (key.Equals("block") && value.Length == 0)
        {
            writer.Write(name, "display:block");
            return true;
        }
        else if (key.Equals("inline"))
        {
            if(value.Length == 0)
            {
                writer.Write(name, "display:inline");
                return true;
            }
            else if (value.Equals("block"))
            {
                writer.Write(name, "display:inline-block");
                return true;
            }
        }
        return false;
    }
}
