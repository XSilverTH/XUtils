namespace XUtils;

public class Print
{
    public static int Menu(string[] options, string text = "What do you want to do?", bool? hasBack = false)
    {
        #region Printing the menu

        Console.Write(text);
        var i = 1;
        if (options.Length <= 8)
        {
            foreach (var option in options)
                Console.Write($"{(i == 1 ? " (" : ", ")}{i++}.{option}");
            Console.WriteLine(hasBack is null ? ")" : (bool)hasBack ? $", {i}.Back)" : $", {i}.Exit)");
        }
        else
        {
            Console.WriteLine();
            foreach (var option in options)
                Console.WriteLine($"{i++}.{option}");
            Console.WriteLine((bool)hasBack ? i + ".Back" : i + ".Exit");
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
                ((inputS > 0 && inputS <= options.Length + 1) || (hasBack != null && inputS == i)))
                return inputS;
            if ((hasBack == true && input == "back") || (hasBack == false && input == "exit"))
                return i;
            foreach (var option in options)
            {
                if (input == option.ToLower())
                    return q;

                q++;
            }

            Console.WriteLine("Invalid input");
        }

        #endregion Getting an input
    }

    public static void WDelay(string text, int delay, char separator = '^')
    {
        var parts = text.Split(separator);
        foreach (var part in parts)
        {
            Console.Write(part);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
    }

    public static string Input(string text, bool nl = true)
    {
        Console.Write(text + (nl ? "\n" : ""));
        return Console.ReadLine();
    }
}