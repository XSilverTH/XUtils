namespace XUtils;

public class Xonsole
{

    public static int Menu(string prompt, string[] options, int delayMilliseconds = 0, char separator = '^',
        ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        #region Printing the menu

        Write(prompt, delayMilliseconds, separator, foregroundColor, backgroundColor);
        var i = 1;
        if (options.Length <= 8)
        {
            foreach (var option in options)
                Write($"{(i == 1 ? " (" : ", ")}{i++}.{option}", delayMilliseconds, separator, foregroundColor, backgroundColor);
            Console.WriteLine(")");
        }
        else
        {
            Console.WriteLine();
            foreach (var option in options)
                WriteLine($"{i++}.{option}", delayMilliseconds, separator, foregroundColor, backgroundColor);
        }

        #endregion Printing the menu

        #region Getting an input

        int q;
        while (true)
        {
            q = 1;
            var input = Console.ReadLine().ToLower();
            int inputS;
            if (int.TryParse(input, out inputS) &&
                inputS > 0 && inputS <= options.Length + 1)
                return inputS;
            foreach (var option in options)
            {
                if (input == option.Replace("^","").ToLower())
                    return q;

                q++;
            }

            Console.WriteLine("Invalid input");
        }

        #endregion Getting an input
    }
    public static string Input(string text, bool nl = true, int delayMilliseconds = 0, char separator = '^',
        ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Write(text + (nl ? "\n" : ""), delayMilliseconds, separator, foregroundColor, backgroundColor);
        return Console.ReadLine();
    }

    public static void WriteLine(string text, int delayMilliseconds = 0, char separator = '^',
        ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        var originalForegroundColor = Console.ForegroundColor;
        var originalBackgroundColor = Console.BackgroundColor;

        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backgroundColor;
        
        var parts = text.Split(separator);
        foreach (var part in parts)
        {
            Console.Write(part);
            if (delayMilliseconds > 0)
                Thread.Sleep(delayMilliseconds);
        }

        Console.WriteLine();

        Console.ForegroundColor = originalForegroundColor;
        Console.BackgroundColor = originalBackgroundColor;
    }
    
    public static void Write(string text, int delayMilliseconds = 0, char separator = '^',
        ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        var originalForegroundColor = Console.ForegroundColor;
        var originalBackgroundColor = Console.BackgroundColor;

        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backgroundColor;

        var parts = text.Split(separator);
        bool first = true;
        foreach (var part in parts)
        {
            Console.Write(part);
            if (delayMilliseconds > 0 && !first)
                Thread.Sleep(delayMilliseconds);
            first = false;
        }

        Console.ForegroundColor = originalForegroundColor;
        Console.BackgroundColor = originalBackgroundColor;
    }

   
}