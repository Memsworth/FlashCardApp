using System.Data;
using ConsoleTableExt;
using Dapper;

namespace FlashCardApp;

public class StackController
{
    private readonly IDbConnection _dbConnection;
    private int CurrentStackId { get; set; }
    
    public StackController(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void StackManager()
    { 
        ViewAllLanguageStacks();
        var languageName = GetStackName();
        SetStackId(languageName);
        while (true)
        {
            
            Helper.StackMenu(languageName);
            switch (Console.ReadLine())
            {
                case "0":
                    return;
                case "X":
                    languageName = GetStackName();
                    SetStackId(languageName);
                    break;
                case "V":
                    ViewStackFlashCards();
                    break;
                case "A":
                    Console.Write("Enter amount: ");
                    int.TryParse(Console.ReadLine(), out int amount);
                    DisplayXCards(amount);
                    break;
                case "C":
                    CreateFlashCard();
                    break;
                case "E":
                    EditFlashCard();
                    break;
                case "D":
                    DeleteFlashCard();
                    break;
                default:
                    Console.WriteLine("Wrong input. Try again.");
                    break;
            }
        }
    }

    private void DisplayXCards(int amount)
    {
        var items = _dbConnection.Query<FlashCardDTO>("SELECT TOP @Amount FROM FlashCardTb WHERE StackId = @Id", new {Amount = amount ,Id = CurrentStackId}).ToList();
        ConsoleTableBuilder.From(items).ExportAndWriteLine();
    }

    private string GetStackName() => Helper.GetString("Enter the stack you want to work with");

    private void SetStackId(string languageNameInput)
    {
        try
        {
            var item = _dbConnection.QueryFirst<LanguageStackModel>(
                "SELECT * FROM LanguageStackTb WHERE LanguageName = @languageName",
                new { languageName = languageNameInput });

            CurrentStackId = item.StackId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private void CreateFlashCard()
    {
        var item = Helper.CreateCard();
        try
        {
            _dbConnection.Execute(
                "INSERT INTO FlashCardTb (StackId , FrontWord, BackWord) VALUES (@StackId, @FrontWord, @BackWord)",
                new {StackId = CurrentStackId, FrontWord = item.FrontWord, BackWord = item.BackWord});
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    private void EditFlashCard()
    {
        ViewAllLanguageStacks();
        Console.Write("Select flashCardId to change: ");
        int.TryParse(Console.ReadLine(), out int flashCardId);
        var item = Helper.GetString("enter an updated word");
        Console.Write("Enter 1 to change Front Word. 2 to change Back Word");
        int.TryParse(Console.ReadLine(), out int choice);
        switch (choice)
        {
            case 1:
                try
                {
                    _dbConnection.Execute(
                        "UPDATE FlashCardTb SET FrontWord = @frontWord WHERE FlashCardId = @flashcardId",
                        new { frontWord = item, flashcardId = flashCardId });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                break;
            case 2:
                try
                {
                    _dbConnection.Execute(
                        "UPDATE FlashCardTb SET BackWord = @backWord WHERE FlashCardId = @flashcardId",
                        new { backWord = item, flashcardId = flashCardId });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                break;
            default:
                Console.WriteLine("wrong command");
                break;
        }
    }
    
    
    private void DeleteFlashCard()
    {
        var items = _dbConnection.Query<FlashCardDeleteDTO>("SELECT * FROM FlashCardTb WHERE StackId = @Id", new {Id = CurrentStackId}).ToList();
        ConsoleTableBuilder.From(items).ExportAndWriteLine();
        Console.Write("Enter flashcardID to delete: ");
        int.TryParse(Console.ReadLine(), out int flashCardId);
        try
        {
            _dbConnection.Execute("Delete from FlashCardTb WHERE FlashCardId = @Id AND StackId = @stackId",
                new { Id = flashCardId, stackId = CurrentStackId });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ViewStackFlashCards()
    {
        var items = _dbConnection.Query<FlashCardDTO>("SELECT * FROM FlashCardTb WHERE StackId = @Id", new {Id = CurrentStackId}).ToList();
        ConsoleTableBuilder.From(items).ExportAndWriteLine();
    }

    private void ViewAllLanguageStacks()
    {
        var items = _dbConnection.Query<LanguageStackDTO>("SELECT * FROM LanguageStackTb").ToList();
        ConsoleTableBuilder.From(items).ExportAndWriteLine();
    }
}

public class FlashCardDeleteDTO
{
    public int FlashCardId { get; private set; }
    public string FrontWord { get; private set; }
    public string BackWord { get; private set; }

    public FlashCardDeleteDTO(int flashCardId,  FlashCard flashCard)
    {
        FlashCardId = flashCardId;
        FrontWord = flashCard.FrontWord;
        BackWord = flashCard.BackWord;
    }

    public FlashCardDeleteDTO()
    {
            
    }
}