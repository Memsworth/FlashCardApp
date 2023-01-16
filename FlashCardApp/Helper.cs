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
}