namespace FlashCardApp;

public static class Helper
{
    public static string LanguageNameInput()
    {
        string languageName;
        do
        {
            Console.Write("Enter language stack name: ");
            languageName = Console.ReadLine()!;
        } while (string.IsNullOrEmpty(languageName));

        return languageName;
    }

    public static string GetString(string message)
    {
        string input;
        do
        {
            Console.Write($"{message}: ");
            input = Console.ReadLine()!;
        } while (string.IsNullOrEmpty(input));

        return input;
    }
}