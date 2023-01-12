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
        FlashCardController = new FlashCardController(new FlashCardModel("1" ,"1"));
    }

    public void AddLanguageStack()
    {
        string languageName;
        do
        {
            Console.Write("Enter language stack name: ");
            languageName = Console.ReadLine()!;
        } while (string.IsNullOrEmpty(languageName));

        var languageStack = new LanguageStackModel(languageName);
        _dbConnection.Execute("INSERT INTO LanguageStackTb (LanguageName) VALUES (@LanguageName)", languageStack);
    }
    public void CreateFlashCard()
    {
        var item = FlashCardController.CreateCard();
        //TODO: insert flashcard into stack 
    }
    public void EditFlashCard(FlashCardModel model)
    {
        var item = FlashCardController.EditFlashCard(model);
        //TODO: change model place with item and insert back
    }
    public void DeleteFlashCard(int id)
    {
        //TODO: Where id is equal query, delete
    }

    public void ViewAllFlashCards()
    {
        
    }
}