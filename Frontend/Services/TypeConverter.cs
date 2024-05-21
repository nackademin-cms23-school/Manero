namespace Frontend.Services;

public class TypeConverter
{
    public static string StringArrayToString(string[] array)
    {
        return string.Join("", array);
    }
}
