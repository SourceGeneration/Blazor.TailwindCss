namespace SourceGeneration.Blazor.TailwindCss;

internal static class AttributeHelper
{
    public static string? MergeClass(params string?[] classes)
    {
        if (classes == null || classes.Length == 0)
            return null;

        return string.Join(" ", classes.Where(x => x != null).SelectMany(x => x!.Split([' '], StringSplitOptions.RemoveEmptyEntries)).Select(x => x.Trim()).Distinct());
    }

    public static string? MergeStyle(params string?[] styles)
    {
        if (styles == null || styles.Length == 0)
            return null;

        return string.Join(";", styles.Where(x=>x != null).SelectMany(x => x!.Split([';'], StringSplitOptions.RemoveEmptyEntries)).Select(x => x.Trim()).Distinct());
    }
}