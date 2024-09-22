namespace XUtils;

public class Text
{
    public static string[] ToArgs(string input)
    {
        var characters = input.ToCharArray();
        var inQuotedSection = false;

        for (var index = 0; index < characters.Length; index++)
            if (characters[index] == '"')
                inQuotedSection = !inQuotedSection;
            else if (!inQuotedSection && characters[index] == ' ')
                characters[index] = '\n';

        return new string(characters).Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }
}