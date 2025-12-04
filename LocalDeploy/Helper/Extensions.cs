namespace LocalDeploy.Helper;

public static class Extensions
{
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        enumerable.ToList().ForEach(action);
    }

    public static string SafeTag(this Control control)
    {
        return control.Tag?.ToString() ?? string.Empty;
    }
}