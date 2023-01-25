using System.Data;
using Dapper;
using FlashCardApp.Models.DBO;

namespace FlashCardApp;

public static class Helper
{
    
    public static string GetStackName() => Helper.GetString("Enter the stack you want to work with");

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
    
    public static FlashCard CreateCard()
    {
        var frontWord = Helper.GetString("Enter a front word for the flashcard");
        var backWord = Helper.GetString($"Enter a back word for {frontWord}");
        return new FlashCard(frontWord, backWord);
    }
    
    
    public static void StackMenu(string languageName)
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Current working stack: {languageName}");
        Console.WriteLine("Type 0 to go back.");
        Console.WriteLine("Type X to change current stack.");
        Console.WriteLine("Type V to view all flashcards in stack   .");
        Console.WriteLine("Type A to view X amount of cards in stack.");
        Console.WriteLine("Type C to create a flashcard in current stack.");
        Console.WriteLine("Type E to edit a flashcard.");
        Console.WriteLine("Type D to delete a flashcard.");
        Console.WriteLine("---------------------------------------------");
    }
    
    public static List<T> GetLanguageStack<T>(IDbConnection connection) where T : LanguageStackModel =>
        connection.Query<T>("SELECT * FROM LanguageStackTb").ToList();
    
    
    public static void LanguageMenu()
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("\nLanguage control menu");
        Console.WriteLine("What would you like to do?\n");
        Console.WriteLine("Type 0 to go back.");
        Console.WriteLine("Type 1 to add stack.");
        Console.WriteLine("Type 2 to delete stack");
        Console.WriteLine("Type 3 to edit stack.");
        Console.WriteLine("---------------------------------------------");
    }
}