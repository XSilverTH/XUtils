using System.Text.Json;

namespace XUtils;

public class FileManager
{
    public static void Save(object thing, string fileName)
    {
        File.WriteAllText(fileName, JsonSerializer.Serialize(thing));
    }

    public static T? Load<T>(string fileName)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(File.ReadAllText(fileName));
        }
        catch (Exception)
        {
            return default;
        }
    }
}