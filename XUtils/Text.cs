namespace XUtils;

public class Text
{
    public static string[] ToArgs(string input)
    {
        var parmChars = input.ToCharArray();
        var inQuote = false;
        for (var index = 0; index < parmChars.Length; index++)
        {
            if (parmChars[index] == '"')
                inQuote = !inQuote;
            if (!inQuote && parmChars[index] == ' ')
                parmChars[index] = '\n';
        }

        return new string(parmChars).Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }
}