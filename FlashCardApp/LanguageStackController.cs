using System.Data;
using Dapper;

namespace FlashCardApp;

public class LanguageStackController
{
    private readonly IDbConnection _dbConnection;
    public FlashCardController FlashCardController { get; }
    public LanguageStackController(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        FlashCardController = new FlashCardController();
    }

    public void AddLanguageStack()
    {
        var languageName = Helper.LanguageNameInput();
        var languageStack = new LanguageStackModel(languageName);
        try
        {
            _dbConnection.Execute("INSERT INTO LanguageStackTb (LanguageName) VALUES (@LanguageName)", languageStack);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void DeleteLanguageStack()
    {
        var languageName = Helper.LanguageNameInput();
        try
        {
            _dbConnection.Execute("Delete from LanguageStackTb WHERE LanguageName = @languageName",
                new { languageName = languageName });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void EditLanguageStack()
    {
        Console.Write("The language stack you want to replace:");
        var oldLanguageName = Helper.LanguageNameInput();
        Console.Write("The new language stack:");
        var newLanguageName = Helper.LanguageNameInput();
        try
        {
            _dbConnection.Execute(
                "UPDATE LanguageStackTb SET LanguageName = @newLanguage WHERE LanguageName = @oldLanguage",
                new { newLanguage = newLanguageName, oldLanguage = oldLanguageName });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    
    public void CreateFlashCard(int stackId)
    {
        var item = FlashCardController.CreateCard();
        try
        {
            _dbConnection.Execute(
                "INSERT INTO FlashCardTb (StackId , FrontWord, BackWord) VALUES (@StackId, @FrontWord, @BackWord)",
                new {StackId = stackId, FrontWord = item.FrontWord, BackWord = item.BackWord});
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    public void EditFlashCard(int flashCardId)
    {
        var item = Helper.GetString("enter the edited word");

        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void DeleteFlashCard(int flashCardId)
    {
        try
        {
            _dbConnection.Execute("Delete from FlashCardTb WHERE FlashCardId = @Id",
                new { Id = flashCardId });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ViewAllFlashCards()
    {
        
    }
}