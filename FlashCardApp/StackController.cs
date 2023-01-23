using System.Data;
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

    internal List<T> DisplayXCards<T>(int amount) where T : FlashCard => _dbConnection.Query<T>(
        $"SELECT TOP {amount} * FROM FlashCardTb WHERE StackId = @Id",
        new { Id = CurrentStackId }).ToList();

    internal string GetStackName() => Helper.GetString("Enter the stack you want to work with");

    internal void SetStackId(string languageNameInput)
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

    internal void CreateFlashCard()
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

    internal void EditFlashCard()
    {
        Console.Write("Select flashCardId to change: ");
        int.TryParse(Console.ReadLine(), out int flashCardId);
        
        var item = Helper.GetString("enter an updated word");
        
        Console.Write("Enter 1 to change Front Word. 2 to change Back Word: ");
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
    
    
    internal void DeleteFlashCard()
    {
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

    internal List<T> GetStackFlashCard<T>() where T : FlashCard => _dbConnection
        .Query<T>("SELECT * FROM FlashCardTb WHERE StackId = @Id", new { Id = CurrentStackId }).ToList();

    internal List<T> GetLanguageStack<T>() where T : LanguageStackModel =>
        _dbConnection.Query<T>("SELECT * FROM LanguageStackTb").ToList();
}