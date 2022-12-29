namespace NekoSpace.SlstGen.Utils;

public static class Extensions
{
    public static string? NullOrNotEmpty(this string str)
    {
        return string.IsNullOrEmpty(str) ? null : str;
    }

    public static bool? NullOrTrue(this bool? val)
    {
        return val.GetValueOrDefault(false) ? true : null;
    }

    public static bool? NullOrTrue(this bool val)
    {
        return val ? true : null;
    }
}