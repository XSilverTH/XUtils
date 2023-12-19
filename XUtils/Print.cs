namespace XUtils;

public class Print
{
    public static void Header(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Clear();
        Console.WriteLine($"{title} Page\n{DateTime.Now.ToString("g")}\n{new string('*', 20)}");
        Console.ResetColor();
    }

    public static int Menu(string text, string[] options, bool? hasBack)
    {
        #region Printing the menu

        Console.Write(text == "d" ? "What do you want to do?" : text);
        int i = 1;
        if (options.Length <= 8)
        {
            foreach (string option in options)
                Console.Write($"{(i == 1 ? " (" : ", ")}{i++}.{option}");
            if (hasBack == true)
                Console.WriteLine($", {i}.Back)");
            else if (hasBack == false)
                Console.WriteLine($", {i}.Exit)");
            else
                Console.WriteLine(")");
        }
        else
        {
            Console.WriteLine();
            foreach (string option in options)
                Console.WriteLine($"{i++}.{option}");
            if (hasBack == true)
                Console.WriteLine(i + ".Back");
            else if (hasBack == false)
                Console.WriteLine(i + ".Exit");
        }

        #endregion Printing the menu

        #region Getting an input

        int q;
        while (true)
        {
            q = 1;
            string input = Console.ReadLine().ToLower();
            int inputS;
            if (int.TryParse(input, out inputS) &&
                ((inputS > 0 && inputS <= options.Length + 1) || (hasBack != null && inputS == i)))
                return inputS;
            if ((hasBack == true && input == "back") || (hasBack == false && input == "exit"))
                return i;
            foreach (string option in options)
            {
                if (input == option.ToLower())
                    return q;

                q++;
            }

            Console.WriteLine("Invalid input");
        }

        #endregion Getting an input
    }

    public static void WDelay(string text, int delay)
    {
        string[] parts = text.Split('^');
        foreach (string part in parts)
        {
            Console.Write(part);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
    }

    public static string Input(string text, bool nl = true)
    {
        Console.Write(text + (nl?"\n":""));
        return Console.ReadLine();
    }
}