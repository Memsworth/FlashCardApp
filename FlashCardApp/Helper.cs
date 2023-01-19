namespace FlashCardApp;

public static class Helper
{
    

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
    
    
    public static void StackMenu()
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Current working stack: ");
        Console.WriteLine("Type 0 to Close Application.");
        Console.WriteLine("Type X to change current stack.");
        Console.WriteLine("Type V to view all flashcards in stack   .");
        Console.WriteLine("Type A to view X amount of cards in stack.");
        Console.WriteLine("Type C to create a flashcard in current stack.");
        Console.WriteLine("Type E to edit a flashcard.");
        Console.WriteLine("Type D to delete a flashcard.");
        Console.WriteLine("---------------------------------------------");
    }
}